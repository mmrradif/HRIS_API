using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.AuthenticationAuthorization;
using HRISgenericInterfaces;
using HRISgenericInterfaces.AuthInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRISgenericRepositories.UserAuthRepositories
{
    public class UserAuthRepo : GenericRepo<User>, IUserInterface, IAllInterfaces<User>
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 10000;

        public UserAuthRepo(HRISdbContext dbContext) : base(dbContext)
        {
           
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

        // Verify Password

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

        // Authenticate
        public async Task<bool> AuthenticateUser(User user)
        {
            var userToLogin = await hrisDbContext.tblUser.FirstOrDefaultAsync(x=>x.UserName == user.UserName);

            bool isPassVerified = VerifyPassword(user.Password, userToLogin.Password);

            if(user.UserName != null && isPassVerified == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Register
        public async Task<bool> RegisterEmployee(User data)
        {
            if (await IsUsernameExists(data.UserName)) return false;

            if(await IsEmailExists(data.Email)) return false;

            if(!(CheckPasswordStrength(data.Password) == "")) return false;

            var hashedPassword = HashPassword(data.Password);

            data.Password = hashedPassword;
            data.Role = data.Role.ToString();

            await hrisDbContext.tblUser.AddAsync(data);
            return true;
        }

        private async Task<bool> IsUsernameExists(string username)
        {
            return await hrisDbContext.tblUser.AnyAsync(x => x.UserName == username);
        }

        private async Task<bool> IsEmailExists(string email)
        {
            return await hrisDbContext.tblUser.AnyAsync(x => x.Email == email);
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

        public async Task CompleteAsync()
        {
            await hrisDbContext.SaveChangesAsync();
            Dispose();
        }

        public void Dispose()
        {
            hrisDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
