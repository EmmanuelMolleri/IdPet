using IdPet.ApplicationServices.Queries;
using IdPet.CrossCutting;
using IdPet.Infra.Data.AppContext;
using MediatR;

namespace IdPet.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ParserDependencies.Inject(builder.Services);
            DatabaseDependencies.Inject(builder.Services, builder.Configuration);
            MediatorDependencies.Inject(builder.Services);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                ZoologicoContext dbcontext = scope.ServiceProvider.GetRequiredService<ZoologicoContext>();
                dbcontext.Database.EnsureCreated();
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