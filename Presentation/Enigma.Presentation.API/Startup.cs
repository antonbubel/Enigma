namespace Enigma.Presentation.API
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.AspNetCore.Cors.Infrastructure;

    using Hubs;

    using Machine;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEnigmaMachine, EnigmaMachine>();
            
            services.AddCors();
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(ConfigureCorsPolicy);
            app.UseSignalR(ConfigureHubRouteBuilder);
            app.UseMvc();
        }

        private void ConfigureCorsPolicy(CorsPolicyBuilder corsPolicyBuilder)
        {
            corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }

        private void ConfigureHubRouteBuilder(HubRouteBuilder hubRouteBuilder)
        {
            hubRouteBuilder.MapHub<SignalRHub>("/enigma-signalr-hub");
        }
    }
}
