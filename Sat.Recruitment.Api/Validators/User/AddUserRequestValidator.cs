using FluentValidation;

namespace Sat.Recruitment.Application.User.Add
{
    /// <summary>
    /// Validator for the AddUserRequest class that defines the validation rules for the request properties.
    /// </summary>
    public sealed class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        /// <summary>
        /// Initializes a new instance of the AddUserRequestValidator class with validation rules for AddUserRequest.
        /// </summary>
        public AddUserRequestValidator()
        {
            RuleFor(request => request.Name).Name();
            RuleFor(request => request.Email).Email();
            RuleFor(request => request.Address).NotEmpty();
            RuleFor(request => request.Phone).Phone();
            RuleFor(request => request.Money).GreaterThan(0);
            RuleFor(x => x.UserType).IsInEnum();
        }
    }
}
