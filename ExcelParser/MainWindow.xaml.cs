using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Diagnostics;
using System.Printing;

namespace ExcelParser
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

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string pass = passTextBox.Password.Trim();
            string passRepeat = passRepeatTextBox.Password.Trim();
            string email = EmailTextBox.Text.ToLower().Trim();

            var syste = (11, 20, "40");
            var (name, age) = ("Tom", 10);
            Debug.WriteLine($"{syste.Item1} {syste.Item2 } {syste.Item3}");
            Debug.WriteLine($"{name} {age}");



            loginTextBox.ToolTip = null;//текст вспылвающей подсказки при наведении на текстбокс
            loginTextBox.Background = Brushes.Transparent;//делаем текст текстбокса прозрачным
            passTextBox.ToolTip = null;
            passTextBox.Background = Brushes.Transparent;
            passRepeatTextBox.ToolTip = null;
            passRepeatTextBox.Background = Brushes.Transparent;
            EmailTextBox.ToolTip = null;
            EmailTextBox.Background = Brushes.Transparent;

            if (login.Length < 5)
            {
                loginTextBox.ToolTip = "Недостаточно смволов";
                loginTextBox.Background = Brushes.DarkRed;
            }
            else if(pass.Length < 5)
            {
                passTextBox.ToolTip = "Недостаточно смволов";
                passTextBox.Background = Brushes.DarkRed;
            }
            else if (pass != passRepeat)
            {
                passRepeatTextBox.ToolTip = "ПАроли не совпадают ";
                passRepeatTextBox.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 ||!email.Contains("@") || !email.Contains("."))
            {
                EmailTextBox.ToolTip = "Неверно введен емейл";
                EmailTextBox.Background = Brushes.DarkRed;
            }
        }
    }
}
