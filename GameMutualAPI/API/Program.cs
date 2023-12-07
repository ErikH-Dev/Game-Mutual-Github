using DAL;
using Logic;
using Logic.Interface;
using Logic.ValidateScopes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("http://localhost:8080");
					  });
});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("read:messages", policy => policy.Requirements.Add(new
	HasScopeRequirement("read:messages", domain)));
});

builder.Services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ISteamGameCollection, SteamGameDAL>();
builder.Services.AddScoped<ISteamUserCollection, SteamUserDAL>();

builder.Services.AddScoped<SteamGameCollection>();
builder.Services.AddScoped<SteamGameCacheHandler>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

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
