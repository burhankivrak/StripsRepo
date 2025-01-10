
using StripDL;
using StripsBL.Interfaces;
using StripsBL.Services;

namespace StripApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<StripsContext>();
            builder.Services.AddScoped<IAuteurRepository, AuteurService>();
            builder.Services.AddScoped<IReeksRepository, ReeksService>();
            builder.Services.AddScoped<IUitgeverijRepository, UitgeverijService>();
            builder.Services.AddScoped<IStripRepository, StripService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
