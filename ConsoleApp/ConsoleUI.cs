using Infrastructure.Dtos;
using Infrastructure.Services;

namespace ConsoleApp;

internal class ConsoleUI
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public ConsoleUI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    public void MainMenuUI()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("######## MENU OPTIONS ########");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("------ PRODUCT MENU ------");
            Console.WriteLine("1. Create new product");
            Console.WriteLine("2. Get ALL products");
            Console.WriteLine("3. Get ONE product");
            Console.WriteLine("4. Update product");
            Console.WriteLine("5. DELETE product");
            Console.WriteLine("6. EXIT ");

            Console.WriteLine("");
            Console.Write("Enter Option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ProductDto productDto = new ProductDto();
                    CreateProductUI(productDto);
                break;

                case "2":
                    GetProductsUI();
                break;

                case "3":
                    GetOneProductUI();
                break;

                case "4":
                    UpdateProductUI();
                break;

                case "5":
                    DeleteProductUI();
                break;

                case "6":
                    Environment.Exit(0);
                break;

                default:
                    Console.WriteLine();
                    Console.Write("Invalid Option. Press Any Key To Try Again.");
                    Console.ReadKey();
                break;
            }
        }
    }

    public void CreateProductUI(ProductDto productDto)
    {
        Console.Clear();
        Console.WriteLine("-----CREATE PRODUCT-----");
        Console.WriteLine("");

        Console.Write("Product Title: ");
        productDto.Title = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Product Articlenumber: ");
        productDto.ArticleNumber = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Product Description: ");
        productDto.Description = Console.ReadLine();
        Console.WriteLine("");

        Console.Write("Product Price: ");
        productDto.Price = decimal.Parse(Console.ReadLine()!);
        Console.WriteLine("");

        Console.Write("Product Category: ");
        productDto.Category = Console.ReadLine()!;

        var result = _productService.CreateProduct(productDto);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product succesfully created.");
            Console.ReadKey();
        }
        else { Console.Clear(); Console.WriteLine("Something went wrong"); }

    }

    public void GetProductsUI()
    {
        Console.Clear();

        var products = _productService.GetAll();

        Console.WriteLine("PRODUCTS:");
        Console.WriteLine("");

        foreach (var product in products)
            {
                Console.WriteLine($" {product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            }

        Console.WriteLine("");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

    public void GetOneProductUI()
    {
        Console.Clear();

        Console.Write("Enter product ID: ");
        var id = int.Parse(Console.ReadLine()!);
        Console.WriteLine("");

        var product = _productService.GetProductById(id);
        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }
        else { Console.WriteLine("No product was found."); }

        Console.WriteLine("");
        Console.Write("Press any key to continue...");
        Console.ReadKey(); 
    }

    public void UpdateProductUI()
    {
        Console.Clear();

        Console.WriteLine("Enter product ID");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);
        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            Console.WriteLine("");

            Console.Write("New product title: ");
            product.Title = Console.ReadLine()!;

            Console.WriteLine("");
            Console.Write("New product price: ");
            product.Price = int.Parse(Console.ReadLine()!);

            _productService.UpdateProduct(product);
            Console.WriteLine($"Updated product: {product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }
        else { Console.WriteLine("No product was found."); }

        Console.WriteLine("");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

    public void DeleteProductUI()
    {
        Console.Clear();

        Console.Write("Enter product ID: ");
        var id = int.Parse(Console.ReadLine()!);
        Console.WriteLine("");

        var product = _productService.GetProductById(id);
        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
            Console.WriteLine("Product was succesfully deleted.");
        } 
        else
        {
            Console.WriteLine("No product was found."); 
        }

        Console.WriteLine("");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }
}
