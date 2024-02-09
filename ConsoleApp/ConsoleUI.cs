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

            Console.WriteLine("");

            Console.WriteLine("------ CUSTOMER MENU ------");
            Console.WriteLine("6. Create new customer");
            Console.WriteLine("7. Get ALL customers");
            Console.WriteLine("8. Get ONE customer");
            Console.WriteLine("9. Update customer");
            Console.WriteLine("10. DELETE customer");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Enter Option: ");
            var option = Console.ReadLine();

            switch (option)
            {

                //products
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

                // customers
                case "6":
                    CustomerDto customerDto = new CustomerDto();
                    CreateCustomerUI(customerDto);
                    break;

                case "7":
                    GetCustomersUI();
                    break;

                case "8":
                    GetOneCustomerUI();
                    break;

                case "9":
                    UpdateCustomerUI();
                    break;

                case "10":
                    DeleteCustomerUI();
                    break;

                default:
                    Console.WriteLine();
                    Console.Write("Invalid Option. Press Any Key To Try Again.");
                    Console.ReadKey();
                    break;
            }
        }
    }


    // PRODUCTS

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
        Console.Clear();
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

        Console.Clear();
        Console.WriteLine("PRODUCTS:");
        Console.WriteLine("");

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }

        Console.ReadKey();
    }

    public void GetOneProductUI()
    {
        Console.Clear();

        Console.Write("Enter product ID: ");
        var id = int.Parse(Console.ReadLine()!);
        Console.WriteLine("");

        var product = _productService.GetProductById(id);
        Console.Clear();

        if (product != null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
        }
        else { Console.WriteLine("No product was found."); }

        Console.ReadKey();
    }

    public void UpdateProductUI()
    {
        Console.Clear();

        Console.Write("Enter product ID: ");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);
        Console.Clear();
        if (product != null)
        {
            Console.WriteLine("Product:");
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

        int id;
        Console.Write("Enter product ID: " );
        
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("");
            Console.WriteLine("Not a valid ID, please try again.");
            Console.WriteLine("");
            Console.Write("Enter product ID: ");
        }

        var product = _productService.GetProductById(id);
        Console.Clear();
        if (product != null)
        {
            Console.WriteLine("Product:");
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price} SEK)");
            Console.WriteLine("");

            Console.Write("Are you sure you want to delete this product?");
            Console.Write(" yes/no: ");    
            var option = Console.ReadLine()!.ToLower(); 
            Console.WriteLine("");

            switch (option)
            {
                case "yes":
                    _productService.DeleteProduct(product.Id);
                    Console.WriteLine("Product was succesfully deleted.");
                    break;
                case "no":
                    Console.WriteLine("Product was not deleted.");
                    break;
                default:
                    Console.Write("Invalid Option. Product was not deleted.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("No product was found.");
        }

        Console.WriteLine("");
        Console.Write("Press any key to re-enter main menu ...");
        Console.ReadKey();
    }


    // CUSTOMERS

    public void CreateCustomerUI(CustomerDto customerDto)
    {
        Console.Clear();
        Console.WriteLine("-----CREATE CUSTOMER-----");
        Console.WriteLine("");

        Console.Write("First Name: ");
        customerDto.FirstName = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Last Name: ");
        customerDto.LastName = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Email : ");
        customerDto.Email = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Phone Number: ");
        customerDto.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Role Name: ");
        customerDto.Role = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Street Name: ");
        customerDto.StreetName = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("Postal Code: ");
        customerDto.PostalCode = Console.ReadLine()!;
        Console.WriteLine("");

        Console.Write("City: ");
        customerDto.City = Console.ReadLine()!;

        var result = _customerService.CreateCustomer(customerDto);
        Console.Clear();
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer succesfully added.");
            Console.ReadKey();
        }
        else { Console.Clear(); Console.WriteLine("Something went wrong"); }
    }

    public void GetCustomersUI()
    {
        Console.Clear();

        var customers = _customerService.GetAll();
        Console.Clear();

        Console.WriteLine("CUSTOMERS:");
        Console.WriteLine("");

        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email} - ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Adress.StreetName}, {customer.Adress.PostalCode}, {customer.Adress.City}");
        }

        Console.ReadKey();
    }

    public void GetOneCustomerUI()
    {
        Console.Clear();

        Console.Write("Enter customer email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);
        Console.Clear();

        if (customer != null)
        {
            Console.WriteLine("Customer: ");
            Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email} - ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Adress.StreetName}, {customer.Adress.PostalCode}, {customer.Adress.City}");
        }
        else { Console.WriteLine("No customer was found."); }

        Console.ReadKey();
    }

    public void UpdateCustomerUI()
    {
        Console.Clear();

        Console.Write("Enter customer email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);
        Console.Clear();

        if (customer != null)
        {
            Console.WriteLine("Customer: ");
            Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email} - ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Adress.StreetName}, {customer.Adress.PostalCode}, {customer.Adress.City}");
            Console.WriteLine("");

            Console.Write("New Firstname: ");
            customer.FirstName = Console.ReadLine()!;

            Console.WriteLine("");
            Console.Write("New Lastname: ");
            customer.LastName = Console.ReadLine()!;
            Console.WriteLine("");

            Console.Write("New email: ");
            customer.Email = Console.ReadLine()!;
            Console.WriteLine("");

            Console.Write("New phonenumber: ");
            customer.PhoneNumber = Console.ReadLine()!;
            Console.WriteLine("");

            Console.Write("New streetname: ");
            customer.Adress.StreetName = Console.ReadLine()!;
            Console.WriteLine("");

            Console.Write("New postalcode: ");
            customer.Adress.PostalCode = Console.ReadLine()!;
            Console.WriteLine("");

            Console.Write("New city: ");
            customer.Adress.City = Console.ReadLine()!;
            Console.WriteLine("");

            _customerService.UpdateCustomer(customer);
            Console.Clear();
            Console.WriteLine($"Updated customer:");
            Console.WriteLine($" {customer.FirstName} {customer.LastName} ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Adress.StreetName}, {customer.Adress.StreetName}, {customer.Adress.City}");

        }
        else { Console.WriteLine("No customer was found."); }

        Console.WriteLine("");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
    }

    public void DeleteCustomerUI()
    {
        Console.Clear();
        int id;
        Console.Write("Enter customer ID: ");

        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("");
            Console.WriteLine("Not a valid ID, please try again.");
            Console.WriteLine("");
            Console.Write("Enter customer ID: ");
        }
       
        var customer = _customerService.GetCustomerById(id);
        Console.Clear();

        if (customer != null)
        {
            Console.WriteLine("Customer:");
            Console.WriteLine($"{customer.FirstName} {customer.LastName} - {customer.Email} - ({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Adress.StreetName}, {customer.Adress.PostalCode}, {customer.Adress.City}");
            Console.WriteLine("");

            Console.Write("Are you sure you want to delete this customer?");
            Console.Write(" yes/no: ");
            var option = Console.ReadLine()!.ToLower(); 
            Console.WriteLine("");

            switch (option)
            {
                case "yes":
                    _customerService.DeleteCustomer(customer.Id);
                    Console.WriteLine("customer was succesfully deleted.");
                    break;

                case "no":
                    Console.WriteLine("Customer was not deleted.");
                    break;

                default:
                    Console.Write("Invalid Option. Customer was not deleted.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("No customer was found.");
        }

        Console.WriteLine("");
        Console.Write("Press any key to re-enter main menu ...");
        Console.ReadKey();
    }
}

