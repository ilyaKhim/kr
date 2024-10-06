namespace CeramicAlloyCalculator.Researcher.InputValidation.Dto;

public class CoefficientsValidationResult
{
    public Dictionary<string, FieldValidationResult> FieldValidationResults = new Dictionary<string, FieldValidationResult>();

    public bool isValid()
    {
        foreach (KeyValuePair<string, FieldValidationResult> entry in FieldValidationResults)
        {
            if (!entry.Value.IsValid)
            {
                return false;
            }
        }

        return true;
    }
}