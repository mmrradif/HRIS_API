global using HRIS.DatabaseContext;
global using HRIS.Interfaces;
global using HRIS.Repositories;
global using Microsoft.EntityFrameworkCore;
global using HRISgenericInterfaces.CompanyInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection.Metadata;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;
using HRISgenericInterfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericRepositories.CompanyRepositories;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Repositories.CompanyRepositories;
using HRISdatabaseModels.DatabaseModels.EmployeeTaxInformation;
using HRISgenericRepositories.EmployeeTaxInformationRepositories;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericRepositories.LoanRepositories;
using HRIS_Models.DatabaseModels.SalaryFinalize;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using HRISgenericRepositories.SalaryFinalizeRepositories;
using HRISgenericRepositories.SalaryStructureRepositories;
using HRISdatabaseModels.DatabaseModels.AuthenticationAuthorization;
using HRISgenericRepositories.UserAuthRepositories;
using System.ComponentModel.DataAnnotations;


//http://localhost:18486/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(t =>
{
    t.SwaggerDoc("v1", new OpenApiInfo { Title = "Human Resourse Information Systems", Version = "v1",});

    t.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme="Bearer",
        BearerFormat="JWT",
        Description="JWT Authentication",
        Name="Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type= Microsoft.OpenApi.Models.SecuritySchemeType.Http
        
    });

    t.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {

        { 
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new List<string>()
        }
    });
});


builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
});



builder.Services.AddCors(opt =>
{
    opt.AddPolicy("hrisPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});



//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("HRExecutivePolicy", policy =>

//        policy.RequireAssertion(options =>
//        options.User.IsInRole(UserRoles.Superuser)
//        ||
//        options.User.IsInRole(UserRoles.HRExecutive)

//    ));

//    options.AddPolicy("HRManagerPolicy", policy =>

//       policy.RequireAssertion(options =>
//       options.User.IsInRole(UserRoles.Superuser)
//       ||
//       options.User.IsInRole(UserRoles.HRManager)

//   ));

//    options.AddPolicy("PayrollExecutivePolicy", policy =>

//       policy.RequireAssertion(options =>
//       options.User.IsInRole(UserRoles.Superuser)
//       ||
//       options.User.IsInRole(UserRoles.PayrollExecutive)

//    ));

//    options.AddPolicy("PayrollManagerPolicy", policy =>

//       policy.RequireAssertion(options =>
//       options.User.IsInRole(UserRoles.Superuser)
//       ||
//       options.User.IsInRole(UserRoles.PayrollManager)

//    ));

//    options.AddPolicy("AuditExecutivePolicy", policy =>

//        policy.RequireAssertion(options =>
//        options.User.IsInRole(UserRoles.Superuser)
//        ||
//        options.User.IsInRole(UserRoles.Audit)

//    ));

//    options.AddPolicy("AccountantPolicy", policy =>

//        policy.RequireAssertion(options =>
//        options.User.IsInRole(UserRoles.Superuser)
//        ||
//        options.User.IsInRole(UserRoles.Accountant)

//    ));

//});




builder.Services.AddDbContext<HRISdbContext>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAllInterfaces<Company>, CompanyRepo>();
builder.Services.AddTransient<IAllInterfaces<Department>, DepartmentRepo>();
builder.Services.AddTransient<IAllInterfaces<Designation>, DesignationRepo>();
builder.Services.AddTransient<IAllInterfaces<Division>, DivisionRepo>();
builder.Services.AddTransient<IAllInterfaces<Grade>, GradeRepo>();
builder.Services.AddTransient<IAllInterfaces<Location>, LocationRepo>();
builder.Services.AddTransient<IAllInterfaces<Roster>, RosterRepo>();

builder.Services.AddTransient<IAllInterfaces<EmployeeTaxInfo>, EmployeeTaxInformationRepo>();

builder.Services.AddTransient<IAllInterfaces<LoanType>, LoanTypeRepo>();
builder.Services.AddTransient<IAllInterfaces<LoanInformation>, LoanInformationRepo>();
builder.Services.AddTransient<IAllInterfaces<LoanSchedule>, LoanScheduleRepo>();


builder.Services.AddTransient<IAllInterfaces<Salary>, SalaryRepo>();
builder.Services.AddTransient<IAllInterfaces<SalaryDetails>, SalaryDetailsRepo>();
builder.Services.AddTransient<IAllInterfaces<SalaryComponent>, SalaryComponenetRepo>();

builder.Services.AddTransient<IAllInterfaces<PayGradeScale>, PayGradeScaleRepo>();

builder.Services.AddTransient<IAllInterfaces<User>, UserAuthRepo>();





//builder.Services.AddDbContext<HRISdbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddDbContext<HRISdbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")
       );
}, ServiceLifetime.Transient);


//builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<HRISdbContext>()
//    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    //--tabassum--
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //--leader--
    //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    //options.RequireHttpsMetadata = false;
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        //--leader--
        //ValidateIssuer = true,
        //ValidateAudience = true,
        //ValidAudience = builder.Configuration["JWT:ValidAudience"],
        //ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))

        //--tabassum--
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecret.....")),
        ValidateAudience = false,
        ValidateIssuer= false
        //ClockSkew = TimeSpan.Zero
    };

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("hrisPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
