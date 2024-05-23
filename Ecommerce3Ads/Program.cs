using Ecommerce3Ads.Data;
using Ecommerce3Ads.Repositorio.Interfaces;
using Ecommerce3Ads.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce3Ads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adiciona a configuração do DbContext
            builder.Services.AddDbContext<EcommerceDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Adiciona serviços aos contêineres de injeção de dependência
            builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            builder.Services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configura o pipeline de requisição HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
