using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTO;
using Test.Domain.IRepository;

namespace Test.Application.Query.ProductQuery
{
    public class GetProductbyNameQuery : IRequest<ProductDTO>
    {
        public string ProductName { get; set; }
    }
    public class GetProductbyNameQueryHandler : IRequestHandler<GetProductbyNameQuery, ProductDTO>
    {
        private readonly IProductRepository _productRepository;

        public GetProductbyNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> Handle(GetProductbyNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _productRepository.GetProductbyName(request.ProductName);

                if (data == null)
                {
                    return null;
                }

                ProductDTO product = new ProductDTO()
                {
                    ProductName = data.ProductName,
                    UserName = data.CreateBy
                };
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching products: " + ex.Message);
            }
        }


    }
}
