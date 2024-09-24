using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICode_AnalytiqueRepository, Code_AnalytiqueRepository>();
builder.Services.AddTransient<ICode_AnalytiqueService, Code_AnalytiqueService>();

builder.Services.AddTransient<IEtatsRepository, EtatsRepository>();
builder.Services.AddTransient<IEtatsService, EtatsService>();

builder.Services.AddTransient<IFrais_DeplacementRepository, Frais_DeplacementRepository>();
builder.Services.AddTransient<IFrais_DeplacementService, Frais_DeplacementService>();

builder.Services.AddTransient<IPersonnelRepository, PersonnelRepository>();
builder.Services.AddTransient<IPersonnelService, PersonnelService>();

builder.Services.AddTransient<IAchatRepository, AchatRepository>();
builder.Services.AddTransient<IAchatService, AchatService>();

builder.Services.AddTransient<IAssistate_DAFRepository, Assistate_DAFRepository>();
builder.Services.AddTransient<IAssistate_DAFService, Assistate_DAFService>();

builder.Services.AddTransient<IComptabiliteRepository, ComptabiliteRepository>();
builder.Services.AddTransient<IComptabiliteService, ComptabiliteService>();

builder.Services.AddTransient<IChef_ComptabiliteRepository, Chef_ComptabiliteRepository>();
builder.Services.AddTransient<IComptabiliteService, ComptabiliteService>();

builder.Services.AddTransient<IFactureRepository, FactureRepository>();
builder.Services.AddTransient<IFactureService, FactureService>();

builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddDbContext<BlogDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BlogConnectionString"),
     providerOptions => providerOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder(
        JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser()
            .Build();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
options.WithOrigins("https://localhost:7180")
.AllowAnyMethod()
.AllowAnyHeader());
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
