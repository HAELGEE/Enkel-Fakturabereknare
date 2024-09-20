namespace Enkel_Fakturaberäknare;

public class Program
{
    static void Main(string[] args)
    {
        Invoice invoice = new Invoice();

        invoice.NameCheck();
        invoice.ProductNameCheck();
        invoice.Calculate();

        Console.WriteLine($"Customer: {invoice.Name}");
        Console.WriteLine($"Product: {invoice.Product}");
        Console.WriteLine($"Total products: {invoice.TotalProducts}");
        Console.WriteLine($"Price per product: {invoice.PriceOfProduct}sek");
        Console.WriteLine($"Total Price exk tax: {invoice.PriceWithOutTaxes}sek");
        Console.WriteLine($"Taxes (25%): {invoice.Taxes}sek");
        Console.WriteLine($"Total Price ink tax: {invoice.PriceWithTaxes}sek");

    }
}
public class Invoice
{
    public string? Name;
    public string? Product;
    public int TotalProducts;
    public double PriceOfProduct;
    public double Taxes;
    public double PriceWithTaxes;
    public double PriceWithOutTaxes;
    public void NameCheck()
    {
        Console.Write("What's your name?: ");
        Name = Console.ReadLine();        
    }
    public void ProductNameCheck()
    {
        Console.Write("What is the name of the product?: ");
        Product = Console.ReadLine();

        while (true)
        {
            try
            {
                Console.Write("\nHow many of that product?: ");
                TotalProducts = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                break;
            }
            catch
            {
                Console.WriteLine("Something went wrong!, maybe you didnt put a whole number in?");
                Console.WriteLine("Try again");
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
            catch
            {
                Console.WriteLine("Something went wrong!, maybe you didnt enter a number?");
                Console.WriteLine("Try again!");
            }
        }

        PriceWithOutTaxes = PriceOfProduct * TotalProducts;
        Taxes = PriceWithOutTaxes * 0.25;
        PriceWithTaxes = PriceWithOutTaxes + Taxes;
    }    
}