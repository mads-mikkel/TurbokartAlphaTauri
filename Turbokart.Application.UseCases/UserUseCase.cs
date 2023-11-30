using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turbokart.Application.Interfaces;
using Turbokart.Domain.Entities;
using Turbokart.Infrastructure.Persistence.Interfaces;

namespace Turbokart.Application.UseCases
{
    public class UserUseCase : IUserUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public UserUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            userRepository = unitOfWork.UserRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await userRepository.GetAll();
        }

        public async Task<bool> IsUserInSystem(string username, string password)
        {
            return await userRepository.IsUserInSystem(username, password);
        }

        public async Task<User> NewUser(User user)
        {
            await userRepository.Save(user);
            await unitOfWork.Commit();
            return user;
        }

        public async Task<User> GetBy(int id)
        {
            return await userRepository.GetBy(id);
        }

        public Task<User> GetOneUsers(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
