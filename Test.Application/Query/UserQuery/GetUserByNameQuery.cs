using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTO;
using Test.Domain.IRepository;

namespace Test.Application.Query.UserQuery
{
    public class GetUserByNameQuery:IRequest<UserDTO>
    {
        public string Name { get; set; }
    }
    public  class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data =  _userRepository.GetUserbyName(request.Name);
                UserDTO user = new UserDTO()
                {
                    UserName = data.UserName
                };
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
}
