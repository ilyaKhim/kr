using CeramicAlloyCalculator.Presentation;

namespace CeramicAlloyCalculator;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        Console.WriteLine("The application had started");
        var presentationLayerManager = new PresentationLayerManager(PresentationFormEnum.WINDOWS);
        presentationLayerManager.ShowLoginForm();
    }
}