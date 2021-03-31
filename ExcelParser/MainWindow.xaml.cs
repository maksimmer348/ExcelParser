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


namespace ExcelParser
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Dictionary<string, object> Elements = new Dictionary<string, object>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement elem in MainRoot.Children)//через UIElement мы перебираем все обьекты
                //которые находятся в нашей сетке MainRoot.Children обьекты оотносящиеся
                //к нашему Grid x:Name="MainRoot"
            {
                if (elem is Button)//теперь нужно прверить относится ли дочерний обьект к классу Button
                {
                    ((Button) elem).Click += Button_Click;//тк Button это производный класс от класса 
                    //UIElement необходимо произвести явное приведение (downcast), да
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = ((Button) e.OriginalSource).Content.ToString();//
           
            if (str == "AC")
            {
                textLabel.Text = String.Empty;
            }
            else if (str == "=")
            {
                
            }
            else
            {
                textLabel.Text += str;
            }

        }
    }
}
