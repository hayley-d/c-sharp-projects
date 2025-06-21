using System;
using System.Collections.Generic;

namespace ContosoPizza.Models {

    public class PizzaRegistry {
        public Dictionary<string,Pizza> MenuItems {get; private set;} = new Dictionary<string,Pizza>();

        public List<Pizza> GetPizza() {
            return this.MenuItems.Select(p => p.Value).ToList();
        }

        public void AddMenuItem(string name, double price) {
            this.MenuItems.Add(name,new Pizza(name,price));
        }

        public Pizza? GetMenuItem(string name) {
            return this.MenuItems[name];
        }

        public List<Pizza> GetItemsInPriceRange(double start, double end) {
            return this.MenuItems.Where(p => p.Value.Price >= start && p.Value.Price <= end).Select(p => p.Value).ToList();
        }

        public void RemoveItemFromMenu(string name) {
            this.MenuItems.Remove(name);
        }

    }
}
