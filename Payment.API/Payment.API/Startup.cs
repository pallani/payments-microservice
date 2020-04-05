using System;
using MediatR;
using System.Reflection;
using System.Data.Common;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Infrastructure;
using Payment.API.Application.Queries;
using Payment.Infrastructure.Repositories;

using Payment.Domain.AggregatesModel.PaymentIntentAggregate;

namespace Payment.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
      {
          services.AddControllers();

          services.AddSwaggerGen(c =>
          {
              c.SwaggerDoc("v1", new OpenApiInfo { Title = "Payment API", Version = "v1" });
          });
			 
          services.AddMediatR(Assembly.GetExecutingAssembly());
          services.AddCustomConfiguration();
          services.AddCustomDbContext(Configuration);
      }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      EnableSwagger(app);
			app.UseHttpsRedirection();
			app.UseRouting();
      app.UseAuthorization();

      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }

    private void EnableSwagger(IApplicationBuilder app)
    {
      app.UseSwagger();
      app.UseSwaggerUI(c => {
          c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Payment v1");
      });
    }
	}

  public static class CustomExtensionMethods
  {
    public static IServiceCollection AddCustomConfiguration(this IServiceCollection services)
    {
      services.AddScoped<IPaymentQueries, PaymentQueries>();
			services.AddScoped<IPaymentIntentRepository, PaymentIntentRepository>();

      return services;
    }

    public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
    {
      if (configuration.GetValue<bool>("EnablePostgres") == true)
      {
        services.AddDbContext<PaymentContext>(options =>
        {
          options.UseNpgsql(configuration["ConnectionStringPostgres"],
						npgsqlOptionsAction: npsqloptions => {
							npsqloptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
							npsqloptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
						}
          );
        });

				return services;
      }

      services.AddDbContext<PaymentContext>(options =>
      {
        options.UseSqlServer(configuration["ConnectionString"],
					sqlServerOptionsAction: sqlOptions => {
						sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
						sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
					});
      });

      return services;
    }
  }
}
