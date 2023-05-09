using Autofac;
using Autofac.Extensions.DependencyInjection;
using API.Utility;
using System.Text.Json.Serialization;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using AppCore;
using External;
using AppCore.Infrastructure.AutofacModules;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Configuration.GetSection("Environment").Value}.json", optional: true);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options => 
{
    options.CustomSchemaIds(type => type.ToString());
});

//configure autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here. 
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new MediatorModule()));

//DB context configuration
builder.Services.AddDataServices(builder.Configuration);

//AppCore configuration
builder.Services.AddAppCore();

//AppCore configuration
builder.Services.AddExternal();


builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors(option => 
{
    option.AddPolicy("CorsPolicy",
        builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
        );

});

//register resources languages
builder.Services.AddLocalizationServices();


//register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddSingleton<IHttpClient, External.HttpClient>();
builder.Services.AddMemoryCache();

var app = builder.Build();

//exception middleware
app.UseMiddleware<JsonExceptionMiddleware>();

//client language culture( set default or selected language by client )
app.UseMiddleware<CultureProviderMiddleware>();

app.UseCors("CorsPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

//create database if doesn't exist when application start
#pragma warning disable CS8602 // Dereference of a possibly null reference.
using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
    context.Database.Migrate();
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.


app.Run();
