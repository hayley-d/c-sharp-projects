using System;

namespace PizzaStore{
    public class Product (string name, double price) {
        public static readonly Random random = new Random();
        public int Id { get; set; } = random.Next(0, 100);
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
    }
}
