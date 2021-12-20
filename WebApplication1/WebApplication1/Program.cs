using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using WebApplication1.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/helloworld", () => "Hello World!");

app.MapGet("/person", (Func<Person>)(() =>
{
    return new Person()
    {
        Id = "1",
        Name = "tom",
        Address = "123 abc"
    };
}));

app.MapGet("/persons", (Func<List<Person>>)(() =>
{
    return new PersonCollection().GetPersons();
}));

app.MapGet("/person/{id}", async (http) =>
{
    if(!http.Request.RouteValues.TryGetValue("id", out var id))
    {
        http.Response.StatusCode = 400;
        return;
    }
    else
    {
        await http.Response.WriteAsJsonAsync(new PersonCollection()
            .GetPersons()
            .FirstOrDefault(x => x.Id == (string)id));
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
