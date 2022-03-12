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
using System.IO;

namespace PracticaFirstTask
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

        private void formBtn_Click_1(object sender, RoutedEventArgs e)
        {
            bool correct = true;
            bool repeat = false;
            formBtn.Background = new LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90);
            Window1 popup = new Window1();
            Window2 popup2 = new Window2();
            Person person = null;
            try
            {
                person = new Person(Int32.Parse(identy.Text), surname.Text.ToString(), name.Text.ToString(), patronymic.Text.ToString(), passport.Text.ToString(), number.Text.ToString(), mail.Text.ToString());
            }
            catch
            {
                correct = false;
                popup.Show();
            }
            if (person != null && person.id == 0)
            {
                correct = false;
            }
            if (person != null && person.numPhone == null)
            {
                correct = false;
            }
            if (person != null && person.passport == null)
            {
                correct = false;
            }
            if (person != null && person.surname == null)
            {
                correct = false;
            }
            if (person != null && person.name == null)
            {
                correct = false;
            }
            if (person != null && person.patronymic == null)
            {
                correct = false;
            }
            if (person != null && person.mail == null)
            {
                correct = false;
            }
            if (person != null)
            {
                using (StreamReader reader = new StreamReader("C:/Users/Disur/source/repos/PracticaFirstTask/PracticaFirstTask/employee.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == person.Compare())
                        {
                            repeat = true;
                            break;
                        }
                        string[] items = line.Split('\t');
                        if(items[0] == person.id.ToString())
                        {
                            repeat = true;
                            break;
                        }
                    }
                }
            }
            if (correct && !repeat)
            {
                using (StreamWriter writer = new StreamWriter("C:/Users/Disur/source/repos/PracticaFirstTask/PracticaFirstTask/employee.txt", true))
                {
                    writer.Write(person.id.ToString() + '\t');
                    writer.Write(person.surname + '\t');
                    writer.Write(person.name + '\t');
                    writer.Write(person.patronymic + '\t');
                    writer.Write(person.passport.ToString() + '\t');
                    writer.Write(person.numPhone.ToString() + '\t');
                    writer.Write(person.mail);
                    writer.Write('\n');
                }
            }
            else if (!correct)
            {
                popup.Show();
            }
            else
            {
                popup2.Show();
            }
        }

    }
}
