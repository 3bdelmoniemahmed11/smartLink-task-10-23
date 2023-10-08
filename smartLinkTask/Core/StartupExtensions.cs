using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using smartLinkTask.BAL.Services.Account.Login;
using smartLinkTask.BAL.Services.Attendances;
using smartLinkTask.BAL.Services.Auth.Token;
using smartLinkTask.BAL.Services.Employees;
using smartLinkTask.DAL.DBContext;
using smartLinkTask.DAL.Models.UserProfileEntity;
using smartLinkTask.DAL.Repositories.Attendances;
using smartLinkTask.DAL.Repositories.Employees;
using System.Text;
namespace smartLinkTask.Core
{
    public static class StartupExtensions
    {


        public static void RegisterServices(this IServiceCollection services)
        {
            ReigisterLoginServices(services);
            ReigisterTokenServices(services);
            ReigisterEmpployeeServices(services);
            ReigisterAttendanceServices(services);
        }

        public static void ReigisterLoginServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
        }
        public static void ReigisterAttendanceServices(this IServiceCollection services)
        {
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        }

        public static void ReigisterEmpployeeServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        public static void ReigisterTokenServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrManagmentContext>(option =>
           option.UseSqlServer(configuration["ConnectionStrings:HrManagement"])
           );
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<UserProfile, IdentityRole>()
           .AddEntityFrameworkStores<HrManagmentContext>()
           .AddDefaultTokenProviders();
        }

        public static async Task SeedDataAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "HR" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserProfile>>();
                string email = "admin@admin.com";
                string password = "admin";


                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new UserProfile();
                    user.UserName = email;
                    user.Email = email;


                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "HR");
                }
            }
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program).Assembly);
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GateWay_API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,

                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
          });
            });
        }

        public static void ConfigureCrossOrgin(this IServiceCollection services, string policyName)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(policyName,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:4200").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();

                    });
            });
        }
    }
}

   
