using System;
using System.Reflection;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using PlanningPokerApi.Src.Shared.Database.Contexts;
using PlanningPokerApi.Src.Shared.Injects;
using PlanningPokerApi.Src.Shared.Hubs;
using PlanningPokerApi.Src.Shared.Helpers.Jwt;

namespace PlanningPokerApi
{
  public class Startup
  {

    readonly string MyAllowSpecificOrigins = "@PlanningPokerApi.CorsPolicyDefault";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApiContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("PlanningPokerApiConnectionUrlElephantSQL")));
      services.AddScoped<ApiContext, ApiContext>();

      services.AddScoped<JwtHelper, JwtHelper>();

      services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

      new UsersCreateInject().Invoke(services);
      new CardsCreateInject().Invoke(services);
      new UsersHistoryCreateInject().Invoke(services);
      new VotesCreateInject().Invoke(services);
      new AuthenticationInject().Invoke(services);

      services.AddControllers();
      services.AddSignalR();

      services.AddCors(
        options =>
        options.AddPolicy(
          name: MyAllowSpecificOrigins,
          builder =>
          {
            builder
              .WithOrigins("http://localhost:5500", "http://127.0.0.1:5500")
              .AllowAnyMethod();
          }));

      var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSettings").GetValue<string>("Secret"));

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Planning Poker Api",
          Description = "This is a test for Concert Technologies",
          Contact = new OpenApiContact
          {
            Name = "Alexandre Salvador de Oliveira",
            Email = "alexandresalvadoroliveiradev@gmail.com",
            Url = new Uri("https://aleoliv.dev"),
          }
        });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planning Poker API V1");
        c.RoutePrefix = string.Empty;
      });

      app.UseRouting();

      app.UseCors(MyAllowSpecificOrigins);

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapHub<VoteHub>("/vote-register");
      });
    }
  }
}
