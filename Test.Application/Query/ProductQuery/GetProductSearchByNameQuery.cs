using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Test.Application.DTO;
using Test.Domain.IRepository;

namespace Test.Application.Query.ProductQuery
{
    public class GetProductSearchByNameQuery : IRequest<List<ProductDTO>>
    {
        public string ProductName { get; set; }
    }

    public class GetProductSearchByNameQueryHandler : IRequestHandler<GetProductSearchByNameQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductSearchByNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> Handle(GetProductSearchByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<ProductDTO> productDTOs = new List<ProductDTO>();

                var data = _productRepository.GetProductSearchByName(request.ProductName);

                if (data == null || !data.Any()) 
                {
                    return null; 
                }

                productDTOs = data.Select(item => new ProductDTO
                {
                    ProductName = item.ProductName,
                    UserName = item.CreateBy
                }).ToList();

                return productDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching products: " + ex.Message);
            }
        }
    }
}
