namespace CeramicAlloyCalculator.Presentation;

public class PresentationLayerManager
{
    private PresentationFormEnum PresentationFormEnum;
    private PresentationLayerFactory PresentationLayerFactory;

    public PresentationLayerManager(PresentationFormEnum presentationFormEnum)
    {
        PresentationFormEnum = presentationFormEnum;
        PresentationLayerFactory = new PresentationLayerFactory();
    }
    
    public void ShowLoginForm()
    {
        PresentationLayerFactory.GetPresentationForm(PresentationFormEnum).ShowLoginForm();
    }
}