using Infrastructure.Dtos;
using Infrastructure.Services;

namespace ConsoleApp;

internal class ConsoleUI
{

    private readonly ProductService _productService;

    public ConsoleUI(ProductService productService)
    {
        _productService = productService;
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

    }


}
