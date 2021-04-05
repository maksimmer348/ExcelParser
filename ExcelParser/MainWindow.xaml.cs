using System;
using System.Collections.Generic;
using System.Configuration;
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
        private ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string pass = passTextBox.Password.Trim();
            string passRepeat = passRepeatTextBox.Password.Trim();
            string email = EmailTextBox.Text.ToLower().Trim();

            loginTextBox.ToolTip = null;
            loginTextBox.Background = Brushes.Transparent;
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
                db.Add(new User(login, pass, email) );
                db.SaveChanges();
        }


        private void Delete_account(object sender, RoutedEventArgs e)
        {
            var users = db.Users.OrderBy(b => b.id).First();
            db.Remove(users);
            db.SaveChanges();
        }

        private void View_accounts_Click(object sender, RoutedEventArgs e)
        {
            var users = db.Users.OrderBy(b => b.id);
            foreach (var user in users)
            {
                Debug.WriteLine($"{user.id} {user.login} {user.password} {user.email}");
            }
            db.SaveChanges();
        }

        
        private void Update_Account_Click(object sender, RoutedEventArgs e)
        {
            var users = db.Users.OrderBy(b => b.id).ToList();
            users[0].email = "KEKE@ya.ru";
            users[0].login = "KESHAS";
            db.SaveChanges();
        }
    }
}
