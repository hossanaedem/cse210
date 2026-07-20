using System;


class Program
{
    static void Main(string[] args)
    {

        // Customer 1
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA"
        );


        Customer customer1 = new Customer(
            "Charles Babbage",
            address1
        );


        Order order1 = new Order(customer1);


        order1.AddProduct(
            new Product("Laptop", "L001", 800, 1)
        );

        order1.AddProduct(
            new Product("Mouse", "M002", 25, 2)
        );


        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}");


        Console.WriteLine("\n====================\n");


        // Customer 2
        Address address2 = new Address(
            "45 Etta-Agbor Street,",
            "Calabar",
            "Cross River",
            "Nigeria"
        );


        Customer customer2 = new Customer(
            "Hossana Edem",
            address2
        );


        Order order2 = new Order(customer2);


        order2.AddProduct(
            new Product("Phone", "P001", 500, 1)
        );


        order2.AddProduct(
            new Product("Headphones", "H002", 50, 3)
        );


        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost()}");

    }
}