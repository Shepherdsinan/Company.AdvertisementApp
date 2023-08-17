using Company.AdvertisementApp.Common;

namespace Company.AdvertisementApp.Business.Containe;

public static class ValidationResultExtension
{
    public static List<CustomValidationError> ConvertToCustomValidationError(this FluentValidation.Results.ValidationResult validationResult)
    {
        List<CustomValidationError> errors = new();
        foreach (var error in validationResult.Errors)
        {
            errors.Add(new()
            {
                ErrorMessage = error.ErrorMessage,
                PropertyName = error.PropertyName
            });
        }

        return errors;
    }
}