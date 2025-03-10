using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTO;
using Test.Domain.IRepository;
using Test.Domain.Model;

namespace Test.Application.Command.ProductCommand
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public ProductDTO Model { get; set; } = new ProductDTO();
    }
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                ProductName = request.Model.ProductName
            };
            _productRepository.SaveProduct(product, request.Model.UserName);
            return request.Model;
        }
    }
}
