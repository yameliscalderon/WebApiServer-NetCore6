using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiUsers.Context;
using WebApiUsers.Interface;
using WebApiUsers.Repository;

var builder = WebApplication.CreateBuilder(args);

// CORS para permitir interaccion con client side.
builder.Services.AddCors(setupAction: options => {
    options.AddPolicy(name: "CORSPolicy",
                      configurePolicy: builder =>
                      {
                          builder
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .WithOrigins(origins: "http://localhost:8081")
                          .AllowCredentials();
                      });

});

// Add services to the container.


//Recordar Actualizar cadena de conexión en appsettings.json
builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddTransient<IVehicles, VehiclesRepository>();
builder.Services.AddTransient<IUsers, UsersRepository>();
builder.Services.AddControllers();
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policyName: "CORSPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
