namespace Enigma.Presentation.API
{
    using System;
    using System.Text;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.AspNetCore.Authentication.JwtBearer;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    
    
    using Hubs;
    using Adapters;

    using Machine;
    using Infrastructure.Configuration;

    using BusinessLogic.Ports;
    using BusinessLogic.UseCases;
    using BusinessLogic.Models;
    using BusinessLogic.Identity;
    using static BusinessLogic.Identity.Helpers.Constants;

    using Domain.Model;
    using Domain.Model.Entities;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
               .AddDbContext<ApplicationContext>(ConfigurePostgreSqlDatabase)
               .BuildServiceProvider();
            
            services.AddScoped<IEnigmaMachine, EnigmaMachine>();
            services.AddScoped<IAccountsPort, AccountsUseCase>();
            services.AddScoped<IEnigmaMachinePort, EnigmaMachineUseCase>();
            services.AddScoped<IEnigmaMachineConfigurationPort, EnigmaMachineConfigurationUseCase>();
            services.AddScoped(typeof(BusinessLogic.Adapters.EnigmaMachineAdapter));
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAccountsAdapter, AccountsAdapter>();
            services.AddScoped<IAuthAdapter, AuthAdapter>();
            services.AddScoped<IEnigmaMachineAdapter, EnigmaMachineAdapter>();
            services.AddScoped<IEnigmaMachineConfigurationAdapter, EnigmaMachineConfigurationAdapter>();
            services.AddLogging();

            services.AddSingleton(ctx => MapperConfigurationProvider.CreateConfiguration().CreateMapper());
            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
   
            ConfigureAuthentication(services);
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

            app.UseAuthentication();
            app.UseCors(ConfigureCorsPolicy);
            app.UseSignalR(ConfigureHubRouteBuilder);
            app.UseMvc();
        }

        private void ConfigurePostgreSqlDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                ConfigurationManager.ConnectionStrings.DefaultContext,
                serverOptions => serverOptions.MigrationsAssembly(ConfigurationManager.AppStart.MigrationsAssembly)
            );
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

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var secretKey = ConfigurationManager.Identity.SecretKey;
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            // jwt wire up
            var jwtIssuer = ConfigurationManager.Identity.JwtIssuer;
            var jwtIssuerAudience = ConfigurationManager.Identity.JwtIssuerAudience;

            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options => {
                options.Issuer = jwtIssuer;
                options.Audience = jwtIssuerAudience;
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtIssuer,

                ValidateAudience = true,
                ValidAudience = jwtIssuerAudience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtIssuer;
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiUser", policy => policy.RequireClaim(JwtClaimIdentifiers.Rol, JwtClaims.ApiAccess));
                options.AddPolicy("Administrator", policy => policy.RequireClaim(JwtClaimIdentifiers.Rol, JwtClaims.Administrator));
            });

            var builder = services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = ConfigurationManager.Identity.PasswordRequiredLength;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
        }
    }
}
