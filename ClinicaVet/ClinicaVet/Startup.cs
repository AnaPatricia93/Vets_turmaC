using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicaVet.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClinicaVet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //concretiza interface - serve para ir buscar as configuracoes do servidor
        public IConfiguration Configuration { get; }




        // This method gets called by the runtime. Use this method to add services to the container.
        /*public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }*/
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            //****************************************************************************
            // especificação do 'tipo' e 'localização' da BD
            //ConnectionString - especifica onde se encontra o servidor de BD e o nome que ele vai ter
            services.AddDbContext<VetsDB>(options =>
               options
               .UseSqlServer(Configuration.GetConnectionString("ConnectionDB"))
               //.UseLazyLoadingProxies()

               );
            //****************************************************************************
            //ver appsettings

        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            // Quando invocamos o nosso projeto não especificamos o método(action) Index nem o Controler Home
            //especificar as ROTAS (forma como acedemos aos recursos)
            //em particular, estamos a especificar, o Controler por defeito, e o Método por defeito, bem como os parametros de 'pesquisa'
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // id? -> não é um parametro obrigatorio
            });
        }
    }
}
