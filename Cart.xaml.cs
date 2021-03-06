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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace VideoRental
{
    /// <summary>
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        public Cart()
        {
            InitializeComponent();
            (Resources["Storyboard1"] as Storyboard).Completed += new EventHandler(Window_Activated);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win0 = new MainWindow();
            win0.Show();
            Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            (Resources["Storyboard1"] as Storyboard).Begin();
        }
    }
}
