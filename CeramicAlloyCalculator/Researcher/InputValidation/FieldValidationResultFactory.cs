using CeramicAlloyCalculator.Researcher.InputValidation.Dto;

namespace CeramicAlloyCalculator.Researcher.InputValidation;

public class FieldValidationResultFactory
{
    public static FieldValidationResult success()
    {
        var result = new FieldValidationResult();
        result.IsValid = true;

        return result;
    }

    public static FieldValidationResult error(string errorMessage)
    {
        var result = new FieldValidationResult();
        result.ErrorMessage = errorMessage;

        return result;
    }
}