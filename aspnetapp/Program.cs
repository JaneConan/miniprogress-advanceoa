using aspnetapp;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
//builder.Services.AddRazorPages();

builder.Services.AddMvc();

builder.Services.AddDbContext<CounterContext>();

#region Ìí¼Óswagger×¢ÊÍ
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.EnablePersistAuthorization();
    });
}

app.Run();
