namespace CeramicAlloyCalculator.Presentation.Windows;

public class WindowsPresentationManager : PresentationManagerInterface
{
    public void ShowLoginForm()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new LoginForm());
    }
}