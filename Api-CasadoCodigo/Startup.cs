using Api_CasadoCodigo.Dto;
using Api_CasadoCodigo.Model;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Api_CasadoCodigo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            /**services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api_CasadoCodigo", Version = "v1" });
            });*/
            //criando uma inst�ncia do AutoMapper e definindo uma mapeamento entre um modelo de dom�nio
            //(Model.Author) e um modelo de exibi��o (AuthorRequest). 
            var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AuthorRequest, Author>();
                    cfg.CreateMap<Author, AuthorRequest>();
                });
            //A seguir para usar a inst�ncia criada do AutoMapper precisamos registrar o
            //IMapper como um servi�o usando o cont�iner de inje��o de depend�ncia nativa da
            //ASP .NET Core usando o m�todo services.AddSingleton():
            //Isso garante que, em vez de uma nova inst�ncia, a mesma inst�ncia do IMapper
            //ser� usada toda vez que uma inst�ncia do IMapper for solicitada por um construtor no seu c�digo.

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            //Adicionado o fluent Validation.
            services.AddMvcCore().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api_CasadoCodigo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
