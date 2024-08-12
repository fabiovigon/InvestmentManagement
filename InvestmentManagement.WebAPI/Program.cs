using InvestmentManagement.Domain.Interfaces.Generics;
using InvestmentManagement.Domain.Interfaces.ICategories;
using InvestmentManagement.Domain.Interfaces.IFinancialSystem;
using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Domain.Interfaces.IUserFinancialSystem;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Domain.Services;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Configurations;
using InvestmentManagement.Infra.Respositories;
using InvestmentManagement.Infra.Respositories.Generics;
using InvestmentManagement.WebAPI.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

//interaface and repository
builder.Services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoriesGenerics<>));
builder.Services.AddSingleton<ICategories, CategoryRepository>();
builder.Services.AddSingleton<IFinancialSystem, FinancialSystemRepository>();
builder.Services.AddSingleton<IProductFinancial, ProductFinancialRepository>();
builder.Services.AddSingleton<IUserFinancialSystem, UserFinancialSystemRepository>();

//Services
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<IFinancialSystemService, FinancialSystemService>();
builder.Services.AddSingleton<IProductFinancialService, ProductFinancialService>();
builder.Services.AddSingleton<IUserFinancialSystemService, UserFinancialSystemService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Teste.Securiry.Bearer",
                     ValidAudience = "Teste.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("A_Much_Longer_Secret_Key_With_Enough_Length_32_Chars")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
