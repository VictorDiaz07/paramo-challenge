using MediatR;
using Sat.Recruitment.Core.Dtos;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Core.Interfaces;

namespace Sat.Recruitment.Application.User.Add
{
    /// <summary>
    /// Represents a request to add a new user
    /// </summary>
    public sealed class AddUserRequest : IRequest<IOperationResult<UserDto>>
    {
        /// <summary>
        /// Represents the name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Represents the address of the user
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Represents the phone of the user
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Represents the type of the user
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// Represents the money of the user
        /// </summary>
        public decimal Money { get; set; }
    }
}
