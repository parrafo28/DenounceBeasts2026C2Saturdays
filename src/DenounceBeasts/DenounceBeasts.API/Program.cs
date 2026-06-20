using DenounceBeasts.API.Data;
using DenounceBeasts.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg =>
{
    // Registrar el perfil manualmente (opcional):
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly /* escanear automát. perfiles en el assembly */);

//var automapperKey = "asdjaskdjahskjdhkajshdkjahskjdhajshdjkashdkjhasjdhaskjd";
//var automapperLicence = builder.Configuration.GetSection("KeysConfigurations:AutomapperLicenceKey").Value;
//var automapperLicence2 = builder.Configuration.GetSection("AutomapperLicenceKey").Value;
///var settingValue = builder.Configuration.GetSection("Logging:LogLevel:Microsoft.AspNetCore").Value;
//
//builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = automapperLicence, typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
  

if(app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}



app.MapControllers();

app.Run();
