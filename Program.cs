using OrderComposition.Entities;
using OrderComposition.Entities.Enums;
using System.Globalization;

namespace OrderComposition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine()); //Digitar exatamente como no enumerate

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);
            
            Console.Write("How many items to this order? : ");
            int n = int.Parse(Console.ReadLine());

            //Instanciando OrderItem
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product price: ");
                double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(prodName, prodPrice);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem item = new OrderItem(quantity, prodPrice, product);
                order.AddItem(item);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine(order);
            Console.WriteLine("Total price: $"+order.Total().ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}