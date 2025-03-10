using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTO;
using Test.Domain.IRepository;
using Test.Domain.Model;

namespace Test.Application.Command.UserCommand
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public UserDTO Model { get; set; } = new UserDTO();
    }
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
        
            User user = new User()
            {
                UserName = request.Model.UserName
            };
            _userRepository.SaveUser(user);
            return request.Model;
        }
    }
}
