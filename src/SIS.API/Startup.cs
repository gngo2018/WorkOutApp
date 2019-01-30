using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WorkOut.Business.DataContract.Authorization.Interfaces;
using WorkOut.Business.Managers.Authorization;
using WorkOut.Database.Authorization;
using WorkOut.Database.Contexts;
using WorkOut.Database.DataContract.Authorization.Interfaces;
using WorkOut.Database.DataContract.Roles.Interfaces;
using WorkOut.Database.Entities.People;
using WorkOut.Database.Entities.Roles;
using WorkOut.Database.Roles;
using WorkOut.Database.SeedData;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using System.Text;
using WorkOut.Business.DataContract.WorkOut.Interfacees;
using WorkOut.Business.Managers.WorkOut;
using WorkOut.Database.DataContract.WorkOut.Interfaces;
using WorkOut.Database.WorkOut;
using WorkOut.API.MappingProfiles;
using WorkOut.Business.DataContract.SetInfo.Interfaces;
using WorkOut.Business.Managers.SetInfo;
using WorkOut.Database.DataContract.SetInfo.Interfaces;
using WorkOut.Database.SetInfo;
using WorkOut.Business.DataContract.Exercise;
using WorkOut.Business.Managers.Exercise;
using WorkOut.Database.DataContract.Exercise;
using WorkOut.Database.Exercise;

namespace WorkOut.API
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
            services.AddDbContext<SISContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            IdentityBuilder builder = services.AddIdentityCore<UserEntity>(opt =>
                 {
                     opt.Password.RequireDigit = false;
                     opt.Password.RequiredLength = 4;
                     opt.Password.RequireNonAlphanumeric = false;
                     opt.Password.RequireUppercase = false;
                 });

            builder = new IdentityBuilder(builder.UserType, typeof(RoleEntity), builder.Services);
            builder.AddEntityFrameworkStores<SISContext>();
            builder.AddRoleValidator<RoleValidator<RoleEntity>>();
            builder.AddRoleManager<RoleManager<RoleEntity>>();
            builder.AddSignInManager<SignInManager<UserEntity>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            ////===== Cors =======
            services.AddCors();
            Mapper.Reset();

            //===== Mapping Config =======
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new WorkOutMappingProfile());
                mc.AddProfile(new SetInfoMappingProfile());
                mc.AddProfile(new ExerciseMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<SeedRepository>();

            //===== Interfaces =======
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IWorkOutManager, WorkOutManager>();
            services.AddScoped<IWorkOutRepository, WorkOutRepository>();
            services.AddScoped<ISetInfoManager, SetInfoManager>();
            services.AddScoped<ISetInfoRepository, SetInfoRepository>();
            services.AddScoped<IExerciseManager, ExerciseManager>();
            services.AddScoped<IExerciseRepository, ExerciseRepository>();


            //======= Swagger =======
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SIS API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedRepository seedRepo)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            seedRepo.SeedUsers(); 
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIS API V1");
            });
            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Fallback", action = "Index" }
                );
            });

        }
    }
}
