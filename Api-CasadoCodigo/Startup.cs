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
            //criando uma instância do AutoMapper e definindo uma mapeamento entre um modelo de domínio
            //(Model.Author) e um modelo de exibição (AuthorRequest). 
            var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AuthorRequest, Author>();
                    cfg.CreateMap<Author, AuthorRequest>();
                });
            //A seguir para usar a instância criada do AutoMapper precisamos registrar o
            //IMapper como um serviço usando o contêiner de injeção de dependência nativa da
            //ASP .NET Core usando o método services.AddSingleton():
            //Isso garante que, em vez de uma nova instância, a mesma instância do IMapper
            //será usada toda vez que uma instância do IMapper for solicitada por um construtor no seu código.

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
