using Microsoft.OpenApi.Models;
using PizzaStore;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("*","http://www.127.0.0.1");
                      });
        });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
       c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI(c =>
    {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
    });
}


app.UseCors(MyAllowSpecificOrigins);

app.MapGet("/", () => "Hello World!");

List<Product> data = new List<Product>();
data.Add(new Product("Hawiian Pizza",50.0));
data.Add(new Product("Regina Pizza",50.0));
data.Add(new Product("All Meat Pizza",50.0));
data.Add(new Product("Chocolate Pizza",50.0));

app.MapGet("/products", () => data);
app.MapGet("/product/{id}", (int id) => data.SingleOrDefault(product => product.Id == id));

app.MapPost("/products", (Product product) => {
        data.Add(product);
        return Results.Ok();
        });
app.MapPut("/products", (Product product) => {
        var matching = data.FirstOrDefault(p => p.Id == product.Id);
        if (matching is null) {
            data.Add(product);
            return Results.NotFound($"Unable to find product with id {product.Id}");
        } else {
            matching.Name = product.Name;
            matching.Price = product.Price;
            return Results.Ok(matching);
        }
});

app.MapDelete("/product/{id}", (int id) => {
        data.RemoveAll(x => x.Id == id);
        return Results.Ok();
});
app.Run();
