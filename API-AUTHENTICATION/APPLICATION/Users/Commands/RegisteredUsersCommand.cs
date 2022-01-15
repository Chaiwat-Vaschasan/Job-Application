using DOMAIN.Entities.Users;
using DOMAIN.Models.Share;
using DOMAIN.Models.Users;
using DOMAIN.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APPLICATION.Users.Commands
{
    public class RegisteredUsersCommand : IRequest<ResponseStatusModel>
    {
        public UserModel UserModel { get; set; }
    }

    public class RegisteredUsersCommandHandler : IRequestHandler<RegisteredUsersCommand, ResponseStatusModel>
    {
        #region Inject
        private readonly IUnitOfWork unit;

        public RegisteredUsersCommandHandler(IUnitOfWork unit) 
        {
            this.unit = unit;
        }
        #endregion

        #region Handle
        public async Task<ResponseStatusModel> Handle(RegisteredUsersCommand request, CancellationToken cancellationToken)
        {
            var register = request.UserModel;
            var duplicateUser = unit.UserRepository.FindByUsernameOrEmail(register.Username, register.Email);
            
            if (duplicateUser != null) 
            {
                return await Task.FromResult(new ResponseStatusModel()
                {
                    Success = false,
                    Message = "username or email already exists."
                });
            }

            var newUser = new User();
            newUser.Create(register);
            foreach(var role in register.Roles) 
            {
                await unit.UserRoleRepository.Add(new UserRole(newUser.Id, role.RoleId));
            }
            await unit.UserRepository.Add(newUser);
            await unit.Save();

            return await Task.FromResult(new ResponseStatusModel()
            {
                Success = true,
                Message = "register user success."
            });
        }
        #endregion
    }
}
