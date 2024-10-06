using CeramicAlloyCalculator.Presentation.Windows;

namespace CeramicAlloyCalculator.Presentation;

public class PresentationLayerFactory
{
    public PresentationManagerInterface GetPresentationForm(PresentationFormEnum presentationFormEnum)
    {
        if (presentationFormEnum == PresentationFormEnum.WINDOWS)
        {
            return new WindowsPresentationManager();
        }
        
        throw new NotImplementedException();
    }
}