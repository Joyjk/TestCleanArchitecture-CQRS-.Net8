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
    public class UpdateProductCommand : IRequest<ProductDTO>
    {
        public string OldProductName { get; set; } = string.Empty;
        public ProductDTO Model { get; set; } = new ProductDTO();
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product()
            {
                ProductName = request.Model.ProductName
            };
            var data =  _productRepository.GetProductbyName(request.OldProductName);
            if (data != null) 
            {
                product.ProductId = data.ProductId;
                _productRepository.UpdateProduct(product, request.Model.UserName);
            }
            return request.Model;
        }
    }
}
