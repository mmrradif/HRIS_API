using HRISdatabaseModels.DatabaseModels.AuthenticationAuthorization;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HRIS.Controllers.AuthenticationAuthorization
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : GenericController<User>
    {
        private readonly HRISdbContext db;
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 10000;

       // private readonly IUnitOfWork unitOfWork;

        public UserController(IAllInterfaces<User> allController, HRISdbContext db) : base(allController)
        {
            this.db = db;
            //this.unitOfWork = unitOfWork;
        }

        // Hash password

        public static string HashPassword(string password)
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[SaltSize]);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = key.GetBytes(HashSize);

            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hashBytes);
            return base64Hash;
        }

        //Verify Password

        public static bool VerifyPassword(string password, string base64Hash)
        {
            var hashBytes = Convert.FromBase64String(base64Hash);

            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = key.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            }
            return true;
        }

        //Log in 

        [HttpPost]
        public async Task<IActionResult> AuthenticateUser([FromBody] User data)
        {
            if (data == null)
                return BadRequest();

            var userToLogin = await db.tblUser.FirstOrDefaultAsync(x => x.UserName == data.UserName);

            if (userToLogin == null)
                return NotFound(new { Message = "User Not Found !!" });

            bool isPassVerified = VerifyPassword(data.Password, userToLogin.Password);

            userToLogin.Token = CreateJWTToken(userToLogin);

            return Ok(new 
            { 
                Message = "Login Success" ,
                Token = userToLogin.Token
            });
        }

        // Register/Sign up

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            // check username not to duplicate

            if (await IsUsernameExists(user.UserName))
                return BadRequest(new { Message = "Username Already Exist !!" });

            // check email not to duplicate

            if (await IsEmailExists(user.Email))
                return BadRequest(new { Message = "Email Already Exist !!" });

            // check password to be strong

            string passwordStrength = CheckPasswordStrength(user.Password);
            if (!string.IsNullOrEmpty(passwordStrength))
                return BadRequest(new { Message = passwordStrength });

            //user.Password = PasswordHasher.HashPassword(user.Password);

            var hashedPassword = HashPassword(user.Password);

            user.Password = hashedPassword;
            user.Role = "User";
            user.Token = string.Empty;
            await db.tblUser.AddAsync(user);
            await db.SaveChangesAsync();
            return Ok(new
            {
                Message = "User Registered"
            });

        }

        private async Task<bool> IsUsernameExists(string username)
        {
            return await db.tblUser.AnyAsync(x => x.UserName == username);
        }

        private async Task<bool> IsEmailExists(string email)
        {
            return await db.tblUser.AnyAsync(x => x.Email == email);
        }

        private string CheckPasswordStrength(string password)
        {
            StringBuilder sb = new StringBuilder();
            if (password.Length < 8)
                sb.Append("Password must carry atleast 8 characters" + Environment.NewLine);

            if (!(Regex.IsMatch(password, "[a-z]")))
                sb.Append("Password must contain atleast one lowercase character" + Environment.NewLine);

            if (!(Regex.IsMatch(password, "[A-Z]")))
                sb.Append("Password must contain atleast one uppercase character" + Environment.NewLine);

            if (!(Regex.IsMatch(password, "[0-9]")))
                sb.Append("Password must contain atleast one numeric character" + Environment.NewLine);

            if (!(Regex.IsMatch(password, "[<,>,!,@,#,$,%,^,&,*,(,),{,},\\[,\\],\\,/,.,',\",`,_]")))
                sb.Append("Password must contain atleast one special character" + Environment.NewLine);

            return sb.ToString();
        }

        private string CreateJWTToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("supersecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role , user.Role),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                //Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        //[HttpPost]
        //public async Task<ActionResult> AuthenticateUser([FromBody] User user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest(new { Message = "Data not provided" });
        //    }

        //    try
        //    {
        //        var result = await unitOfWork.userRepository.AuthenticateUser(user);
        //        if (result)
        //        {
        //            await unitOfWork.CompleteAsync();
        //            return Ok(new { Message = "User log in Successful. " });
        //        }
        //        else
        //        {
        //            return BadRequest(new { Message = "Failed to log in" });
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //[HttpPost]
        //public async Task<IActionResult> RegisterUser([FromBody] User userobj)
        //{
        //    if (userobj == null)
        //    {
        //        return BadRequest(new { Message = "Data not provided" });
        //    }

        //    try
        //    {
        //        var result = await unitOfWork.userRepository.RegisterEmployee(userobj);
        //        if (result)
        //        {
        //            await unitOfWork.CompleteAsync();
        //            return Ok(new { Message = "User Registered Successfully. " });
        //        }
        //        else
        //        {
        //            return BadRequest(new { Message = "Failed to register" });
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //}
    }
}
