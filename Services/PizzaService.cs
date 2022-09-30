using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{

    //Define a list field of pizzas
    static List<Pizza> Pizzas { get; }

    //First two pizzas have been created next pizza starts from 3
    static int nextId = 3;

    //Constructor - When Pizza class is instantiated first two pizzas are in the list
    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    //Get list of all pizzas method - similar to a sql select all and will be attached to the get route
    public static List<Pizza> GetAll() => Pizzas;

    //Get one pizza item by id - will be attached to the get route
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    // Add a new pizza to the list of pizza - will be attached to the post route
    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    // Remove a pizza from the list of pizza - will be attached to the delete route
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    // Update a pizza in the list of pizza - will be attached to the put/patch route
    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}