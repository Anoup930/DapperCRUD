using Autofac;
using Autofac.Extensions.DependencyInjection;
using DapperWebAPI;
using DapperWebAPI.Models;
using DapperWebAPI.Services;



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
