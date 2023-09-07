using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Public_Offering.Business.DependencyResolvers.Autofac;
using Public_Offering.Business.Mappings.CompanyProfile;

using Public_Offering.Business.Mappings.PublicOfferProfile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new CompanyProfile());
    mc.AddProfile(new PublicOfferProfile());
  


});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
// Register services directly with Autofac here. Don't
// call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));
#endregion
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

app.Run();
