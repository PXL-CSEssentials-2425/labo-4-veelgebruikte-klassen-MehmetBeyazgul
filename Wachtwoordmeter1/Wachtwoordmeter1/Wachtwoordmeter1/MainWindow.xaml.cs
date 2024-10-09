using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wachtwoordmeter1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void passwordMeterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = userNameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            int passwordStrength = 0;

            if (string.IsNullOrEmpty(username))
            {
                resultTextBlock.Text = "Please enter an username";
                return;
            }
            if(string.IsNullOrEmpty(password))
            {
                resultTextBlock.Text = "Please enter an password";
                return;
            }
            //if(password.Contains(username))
            //{
            //    resultTextBlock.Text = "Password can not contain username";
            //    return;
            //}
            //if (password.Length <= 10)
            //{
            //    resultTextBlock.Text = "Password must be at least 10 characters long";
            //    return;
            //}
            if (!password.Contains(username))
            {
                passwordStrength++;
            }
            if(password.Length >= 10)
            {
                passwordStrength++;
            }
            bool hasDigit = false;
            bool hasUpper = false;
            bool hasLower = false;

            foreach (char c in password.ToCharArray())
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }
                if (char.IsLower(c))
                {
                    hasLower = true;
                }
            }
            if (hasDigit)
            {
                passwordStrength++;
            }
            if(hasUpper)
            {
                passwordStrength++;
            }
            if(hasLower)
            {
                passwordStrength++;
            }
            switch (passwordStrength)
            {
                case 5:
                    resultTextBlock.Text = "Strong password";
                    resultTextBlock.Foreground = Brushes.Green;
                    break;
                case 4:
                    resultTextBlock.Text = "Medium password";
                    resultTextBlock.Foreground= Brushes.Orange; 
                    break;
                default:
                    resultTextBlock.Text = "Weak password";
                    resultTextBlock.Foreground = Brushes.Red;
                    break;
            }
        }
    }
}