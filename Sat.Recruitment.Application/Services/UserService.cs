using Sat.Recruitment.Core.Contracts;
using Sat.Recruitment.Core.Dtos;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Core.Interfaces;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Core.Services
{
    /// <summary>
    /// Implementation of the IUserService interface that calculates the money based on the user type and money value
    /// </summary>
    public sealed class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<IOperationResult<UserDto>> AddAsync(User user)
        {
            decimal money = CalculateMoney(user);

            bool exists = _userRepository.Exists(x => user.Email == x.Email || user.Phone == x.Phone || (user.Address == x.Address && user.Name == x.Name));

            if (exists)
            {
                return await Task.FromResult(BasicOperationResult<UserDto>.Fail("The user is duplicated"));
            }

            _userRepository.Create(user);
            _userRepository.Save();

            return await Task.FromResult(BasicOperationResult<UserDto>.Ok());
        }

        /// <inheritdoc/>
        private decimal CalculateMoney(User user) => user.UserType switch
        {
            UserType.Normal => CalculateNormalMoney(user),
            UserType.SuperUser => CalculateSuperUserMoney(user),
            UserType.Premium => CalculatePremiumMoney(user),
            _ => 0
        };

        private decimal CalculateNormalMoney(User user)
        {
            decimal money = user.Money;

            decimal percentage = user.Money switch
            {
                decimal x when x > 100 => 0.12m,
                decimal x when x > 10 => 0.8m,
                _ => 0m
            };

            if (percentage > 0)
            {
                money += user.Money * percentage;
            }

            return money;
        }

        private decimal CalculateSuperUserMoney(User user)
        {
            decimal money = user.Money;

            if (user.Money > 100)
            {
                decimal percentage = 0.20m;
                money += user.Money * percentage;
            }

            return money;
        }

        private decimal CalculatePremiumMoney(User user)
        {
            decimal money = user.Money;

            if (user.Money > 100)
            {
                money += user.Money * 2;
            }

            return money;
        }
    }
}
