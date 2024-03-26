using System.IO;
using System.Windows;


namespace generator;

public partial class TestWindow
{
    public TestWindow(bool isActiveEditButton)
    {
        InitializeComponent();
        EditTestButton.IsEnabled = isActiveEditButton;
    }
    
    private void  ReturnButton_OnClick(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void PassTestButton_OnClick(object sender, RoutedEventArgs e)
    {
        Frame.Content = File.Exists("test.json") ? new PassTestPage() : new NoTestPage();
    }
    
    private void EditTestButton_OnClick(object sender, RoutedEventArgs e)
    {
        Frame.Content = new EditTestPage();
    }
}