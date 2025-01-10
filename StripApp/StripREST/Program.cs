
using StripDL;
using StripsBL.Interfaces;
using StripsBL.Services;
using StripsDL;

namespace StripREST
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
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<StripsContext>();
                var databaseInitializer = new DatabaseInitializer(dbContext);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../StripsDL", "StripsListEF.txt");
                databaseInitializer.InitialiseerDatabank(filePath);
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
