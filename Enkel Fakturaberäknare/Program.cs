namespace Enkel_Fakturaberäknare;

public class Program
{
    static void Main(string[] args)
    {
        Invoice invoice = new Invoice();

        Console.WriteLine("=== Invoice ===");

        invoice.NameCheck();
        invoice.ProductNameCheck();
        invoice.Calculate();

        Console.WriteLine($"Customer: {invoice.Name}");
        Console.WriteLine($"Product: {invoice.Product}");
        Console.WriteLine($"Total products: {invoice.TotalProducts}");
        Console.WriteLine($"Price per product: {invoice.PriceOfProduct:C}");
        Console.WriteLine($"Total Price ex tax: {invoice.PriceWithOutTaxes:C}");
        Console.WriteLine($"Taxes (25%): {invoice.Taxes:C}");
        Console.WriteLine($"Total Price ink tax: {invoice.PriceWithTaxes:C}");

    }
}
public class Invoice
{
    public string? Name {  get; set; }
    public string? Product { get; set; }
    public int TotalProducts { get; set; }
    public double PriceOfProduct { get; set; }
    public double Taxes { get; set; }
    public double PriceWithTaxes { get; set; }
    public double PriceWithOutTaxes { get; set; }
    public void NameCheck()
    {
        Console.Write("What's your name?: ");
        Name = Console.ReadLine();        
    }
    public void ProductNameCheck()
    {
        Console.Write("\nWhat is the name of the product?: ");
        Product = Console.ReadLine();

        while (true)
        {
            try
            {
                Console.Write("\nHow many of that product?: ");
                TotalProducts = Convert.ToInt32(Console.ReadLine());
                while (TotalProducts <= 0)
                {
                    Console.WriteLine("The number of products must be greater than zero. Please try again.");
                    TotalProducts = Convert.ToInt32(Console.ReadLine());
                }
                Console.Clear();
                break;
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }
    }
    public void Calculate()
    {
        while (true)
        {
            try
            {
                Console.Write("How much does the product cost per product?: ");
                PriceOfProduct = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                break;
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid number.");
            }
        }

        PriceWithOutTaxes = PriceOfProduct * TotalProducts;
        Taxes = PriceWithOutTaxes * 0.25;
        PriceWithTaxes = PriceWithOutTaxes + Taxes;
    }    
}