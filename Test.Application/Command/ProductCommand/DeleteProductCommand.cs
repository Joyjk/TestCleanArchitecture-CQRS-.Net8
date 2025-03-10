using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTO;
using Test.Domain.IRepository;

namespace Test.Application.Command.ProductCommand
{
    public class DeleteProductCommand : IRequest<ProductDTO>
    {
        public string ProductName { get; set; } = string.Empty;
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDTO>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _productRepository.GetProductbyName(request.ProductName);
                if (data != null)
                {
                    _productRepository.DeleteProduct(data);
                }
                return new ProductDTO();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
