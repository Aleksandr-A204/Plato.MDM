using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Plato.MDM.Data;
using Plato.MDM.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMdmDirectoryRepository, MdmDirectoryRepository>();
builder.Services.AddScoped<IMdmDirectoryVersionRepository, MdmDirectoryVersionRepository>();
builder.Services.AddScoped<IMdmDirectoryLevelRepository, MdmDirectoryLevelRepository>();
builder.Services.AddScoped<IMdmDirectoryDomainRepository, MdmDirectoryDomainRepository>();

builder.Services.AddDbContext<MdmSystemContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// JSON Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

builder.Services.AddControllers();

// Enable CORS http://localhost:5173
builder.Services.AddCors(option => option.AddPolicy(name: "myAllowSpecificOrigins", builder =>
    builder.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader()));

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

app.UseAuthorization();

app.MapControllers();

// Enable CROS
app.UseCors("myAllowSpecificOrigins");

app.Run();
