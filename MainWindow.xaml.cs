using System.Windows;
using System.Windows.Input;

namespace generator;

public partial class MainWindow
{
    private const string Password = "кодовое слово";
    
    public MainWindow()
    {
        InitializeComponent();
        PasswordTextBox.Visibility = Visibility.Collapsed;
    }

    private void RedactorButton_OnClick(object sender, RoutedEventArgs e)
    {
        PasswordTextBox.Visibility = Visibility.Visible;
        if ((PasswordTextBox.Text).ToLower() != Password) return;
        OpenTestWindow(true);
        PasswordTextBox.Text = string.Empty;
    }
    
    private void PassButton_OnClick(object sender, RoutedEventArgs e)
    {
        OpenTestWindow(false);
    }

    private void PasswordTextBox_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Enter) return;
        if ((PasswordTextBox.Text).ToLower() != Password) return;
        OpenTestWindow(true);
        PasswordTextBox.Text = string.Empty;
    }

    private void OpenTestWindow(bool isActiveEditButton)
    {
        var testWindow = new TestWindow(isActiveEditButton);
        testWindow.Show();
        Close();
    }
}