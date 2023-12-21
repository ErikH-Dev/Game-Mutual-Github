using API;
using AutoMapper;
using DAL;
using DAL.DBContext;
using DAL.ErrorHelper;
using DAL.Models;
using Logic;
using Logic.Interface;
using Logic.ValidateScopes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using SharedObjects;
using System.Security.Claims;

public class Program
{
	private static void Main(string[] args)
	{
		var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		var builder = WebApplication.CreateBuilder(args);

		// Auth0
		var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
		builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>
		{
			options.Authority = domain;
			options.Audience = builder.Configuration["Auth0:Audience"];
			options.TokenValidationParameters = new TokenValidationParameters
			{
				NameClaimType = ClaimTypes.NameIdentifier
			};
		});

		// CORS
		builder.Services.AddCors(options =>
		{
			options.AddPolicy(name: MyAllowSpecificOrigins,
							  builder =>
							  {
								  builder.WithOrigins("http://localhost:8080")
										 .AllowAnyHeader()
										 .AllowAnyMethod();
							  });
		});
		// Authorization Auth0
		builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("read:messages", policy => policy.Requirements.Add(new
			HasScopeRequirement("read:messages", domain)));
		});

		// AutoMapper
		var config = new AutoMapper.MapperConfiguration(cfg =>
		{
			cfg.CreateMap<IUser, UserDTO>().ReverseMap()
				.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
			cfg.CreateMap<API.Models.Create.CreateUserModel, API.Models.General.UserModel>()
				.ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
		});

		IMapper mapper = config.CreateMapper();
		builder.Services.AddSingleton(mapper);

		builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
		// Add services to the container.

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		builder.Services.AddMemoryCache();

		builder.Services.AddScoped<IErrorHelper, ErrorHelper>();

		builder.Services.AddScoped<ISteamGameCollection, SteamGameDAL>();
		builder.Services.AddScoped<ISteamUserCollection, SteamUserDAL>();
		builder.Services.AddScoped<IUserCollection, UserDAL>();
		builder.Services.AddSingleton<UserDbContext>();

		builder.Services.AddScoped<UserCollection>();
		builder.Services.AddScoped<SteamGameCollection>();
		builder.Services.AddScoped<SteamGameCacheHandler>();
		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseMiddleware<ExceptionMiddleware>();

		app.UseHttpsRedirection();

		app.UseRouting();

		app.UseCors(MyAllowSpecificOrigins);

		app.UseAuthentication();

		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			endpoints.MapControllers();
		});

		app.MapControllers();

		app.Run();
	}
}
