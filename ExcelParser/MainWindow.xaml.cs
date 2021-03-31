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
            foreach (UIElement elem in MainRoot.Children) //через UIElement мы перебираем все обьекты
                //которые находятся в нашей сетке MainRoot.Children обьекты оотносящиеся
                //к нашему Grid x:Name="MainRoot"
            {
                if (elem is Button btn) //теперь нужно прверить относится ли дочерний обьект к классу Button
                {
                    btn.Click += Button_Click; //тк Button это производный класс от класса 
                    //UIElement необходимо произвести явное приведение (downcast), да
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) //Все маршрутизируемые события используют класс
            //RoutedEventArgs (или его наследников), который представляет доступ к следующим свойствам:

            //Source: элемент логического дерева, являющийся источником события.

            //OriginalSource: элемент визуального дерева, являющийся источником события. Обычно то же самое, что и Source
            //OriginalSource У элемента управления могут быть другие элементы управления в качестве дочерних элементов. 
            //Когда вы подписываетесь на событие от элемента управления, родительский элемент, на который вы подписались,
            //скорее всего, будет тем, что, e.Source однако, если у элемента управления есть дочерние элементы,
            //а дочерний элемент - тот, который вызвал событие, то это OriginalSourceбудет дочерний элемент,
            //который вызвал событие.

            //RoutedEvent: представляет имя события

            //Handled: если это свойство установлено в True, событие не будет подниматься и опускаться, а ограничится непосредственным источником.
        {


            string str =
                ((Button) e.OriginalSource).Content.ToString(); // преборазовываем инвент к классу кнопки, и получаем
            //значение контента из кнопки <Button>1</Button> - 1 это и естть контент этой кнопки, и преобразуем его в строку

            if (temp == "=")
            {
                ss = true;
            }

            if (ss)
            {
                if (temp != "+" || temp != "-" || temp != "/" || temp != "*" || temp != "=")
                {
                    textLabel.Text = String.Empty;
                    temp = "";
                }
            }

            if (str == "AC")
            {
                textLabel.Text = String.Empty;
            }
            else if (str == "=")
            {
                string value = new DataTable().Compute(textLabel.Text, null)
                    .ToString(); //Compute повзволят нам выситвать значение праметра в качетве входного 
                //значения можно испольовать строку
                if (!string.IsNullOrWhiteSpace(value))
                {
                    textLabel.Text = value;
                }


            }

            else
            {
                textLabel.Text += str;
                temp = str;
            }


        }

        string temp;
        private bool ss = false;
    }
}
