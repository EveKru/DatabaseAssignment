using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services;

public class CustomerService(CustomerRepository customerRepository, AdressService adressService, RoleService roleService)
{
    private readonly CustomerRepository _customerRepository = customerRepository;
    private readonly AdressService _adressService = adressService;
    private readonly RoleService _roleService = roleService;


    public CustomerEntity CreateCustomer(CustomerDto customerDto)
    {
        var roleEntity = _roleService.CreateRole(customerDto.Role);
        var adressEntity = _adressService.CreateAdress(customerDto.StreetName, customerDto.PostalCode, customerDto.City);

        var customerEntity = new CustomerEntity 
        {
            FirstName = customerDto.FirstName,
            LastName = customerDto.LastName,
            Email = customerDto.Email,
            PhoneNumber = customerDto.PhoneNumber,
            RoleId = roleEntity.Id,
            AdressId = adressEntity.Id
        };

        customerEntity = _customerRepository.Create(customerEntity);
        return customerEntity;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _customerRepository.Get(x => x.Id == id);
        return customerEntity;
    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        var customerEntity = _customerRepository.Get(x => x.Email == email);
        return customerEntity;
    }


    public IEnumerable<CustomerEntity> GetAll()
    {
        var customers = _customerRepository.GetAll();
        return customers;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var updated = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
        return updated;
    }

    public void DeleteCustomer(int id)
    {
        try
        {
            _customerRepository.Delete(x => x.Id == id);
        }
        catch (Exception ex) { Debug.WriteLine(ex); }
    }
}
