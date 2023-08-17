using Company.AdvertisementApp.UI.Models;
using FluentValidation;

namespace Company.AdvertisementApp.UI.ValidationRules;

public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
{
    public UserCreateModelValidator()
    {
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is not empty");
        RuleFor(x => x.Password).MinimumLength(3).WithMessage("Password minimum 3 character");
        RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password Not match");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("Firstname is not empty");
        RuleFor(x => x.SurName).NotEmpty().WithMessage("Surname is not empty");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is not empty");
        RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Username minimum 3 character");
        RuleFor(x =>new
        {
            x.UserName,
            x.FirstName
        }).Must(x=>CanNotFirstname(x.UserName,x.FirstName)).WithMessage("Username is not firstname").When(x=>x.UserName!=null && x.FirstName!=null);
        RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender is not empty");

        
    }

    private bool CanNotFirstname(string username,string firstname)
    {
        return !username.Contains(firstname);
    }

}