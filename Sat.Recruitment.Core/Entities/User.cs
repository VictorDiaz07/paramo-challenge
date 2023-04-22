using Sat.Recruitment.Core.Enums;

namespace Sat.Recruitment.Core.Entities
{
    /// <summary>
    /// Represents a user in the system
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the physical address of the user.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the user.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the type of user.
        /// </summary>
        public UserType UserType { get; set; }

        /// <summary>
        /// Gets or sets the amount of money owned by the user.
        /// </summary>
        public decimal Money { get; set; }
    }
}
