using Sat.Recruitment.Core.Dtos;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Core.Contracts
{
    /// <summary>
    /// Represents a service for user-related operations
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="user">The user object for which to calculate the money</param>
        /// <returns>The calculated amount of money</returns>
        Task<IOperationResult<UserDto>> AddAsync(User request);

    }
}
