using ecommerce.api.Extensions;
using ecommerce.infastructure;
using ecommerce.app;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.addinfastrucrureservice(builder.Configuration);
builder.Services.AddApplicationService();

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = builder.Configuration.GetConnectionString("Redis");
    return ConnectionMultiplexer.Connect(configuration!);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await app.SeedDataAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider=new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"Files")),
    RequestPath="/Files"

});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
