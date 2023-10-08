
using smartLinkTask.Controllers.Account;
using smartLinkTask.Core;
namespace smartLinkTask
{
    public class Program
    {
        private static readonly string OriginPolicyName = "DEFAULTPOLICY";
        public static async Task Main(string[] args)
        {
             
        var builder = WebApplication.CreateBuilder(args);

          
            builder.Services.ConfigureCrossOrgin(OriginPolicyName);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureSwagger();
            builder.Services.AddSwaggerGen();
            builder.Services.RegisterServices();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureJWT(builder.Configuration);
            builder.Services.ConfigureDatabase(builder.Configuration);
            builder.Services.ConfigureAutoMapper();

          
            var app = builder.Build();
            /* init the data of the system with 
             * email = admin@admin.com
             * password=admin
             * */
            await Common.SeedDataAsync(app);
          
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(OriginPolicyName);

            app.MapControllers();
            
            
            app.Run();
        }
    }
}