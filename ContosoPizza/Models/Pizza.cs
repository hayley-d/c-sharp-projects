namespace ContosoPizza.Models {
    public class Pizza(string name, double price) {
        private static readonly Random random = new Random();

        public int Id { get; set; } = random.Next(0,100);
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;


        public void MakePizza() {
            Console.WriteLine($"Making a {this.Name} with love");
        }
    }
}
