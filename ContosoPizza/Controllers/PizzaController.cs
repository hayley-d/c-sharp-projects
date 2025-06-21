using System;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
namespace ContosoPizza.Controllers; 

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase {

    private readonly PizzaRegistry _registry;

    public PizzaController(PizzaRegistry registry) {
        this._registry = registry;
    }

    [HttpGet(Name = "GetPizza")]
    public IEnumerable<Pizza> GetPizza() {
        return _registry.GetPizza();    
    }
}
