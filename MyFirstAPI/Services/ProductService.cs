
using MyFirstAPI.Models;
using MyFirstAPI.Repositories;
using MyFirstAPI.Models.Exceptions;

namespace MyFirstAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Product ID must be greater than zero.");
            }
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            { 
                throw new NotFoundException($"Product with ID {id} not found.");
            }
            return product;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.Id = 0;
            return await _productRepository.CreateAsync(product);
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var ExisitingProduct = await _productRepository.GetByIdAsync(id);
            if (ExisitingProduct == null)
            {
                throw new NotFoundException($"Product with ID {id} not found.");
            }
            product.Id = id;
            return await _productRepository.UpdateProductAsync(product);

        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Product ID must be greater than zero.", nameof(id));
            }
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new NotFoundException($"Product with ID {id} not found.");
            }
            return await _productRepository.DeleteProductAsync(existingProduct);
        }
    }    
}