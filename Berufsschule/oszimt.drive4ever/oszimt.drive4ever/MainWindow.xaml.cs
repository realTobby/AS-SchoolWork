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

namespace oszimt.drive4ever
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ViewModel currentView;

        public MainWindow()
        {
            InitializeComponent();
            currentView = new ViewModel();
            this.DataContext = currentView;
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            
            currentView.GetNextQuestion();
        }

        private void frageEins_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentView.AllowedToClick == true)
            {
                currentView.RadioCheckedA = true;
                Check();
            }
        
        }

        private void Check()
        {
            currentView.AllowedToClick = false;

            currentView.BackColorForA = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            currentView.BackColorForB = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            currentView.BackColorForC = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            currentView.BackColorForD = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            var res = currentView.Frage.Loesung;
            switch (res)
            {
                case "a":
                    currentView.BackColorForA = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    break;
                case "b":
                    currentView.BackColorForB = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    break;
                case "c":
                    currentView.BackColorForC = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    break;
                case "d":
                    currentView.BackColorForD = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    break;
            }

            // check correct answer here
            // get radiobutton that is checked
            // check if same with correct answer
            // 
        }

        private void frageZwei_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentView.AllowedToClick == true)
            {
                currentView.RadioCheckedB = true;
                Check();
            }
        }

        private void frageDrei_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentView.AllowedToClick == true)
            {
                currentView.RadioCheckedC = true;
                Check();
            }
        }

        private void frageVier_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentView.AllowedToClick == true)
            {
                currentView.RadioCheckedD = true;
                Check();
            }
        }
    }
}
