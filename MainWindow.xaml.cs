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
using System.Data.SQLite;
using VideoRental.Connection;
using System.Data;

namespace VideoRental
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DisplayData();
        }

        public void DisplayData()
        {
            using (SQLiteConnection connection = new SQLiteConnection(DBConn.myConn))
            {
                try
                {
                    connection.Open();
                    string query = $@"SELECT Films.ID, Films.Name, Films.Rate, Films.Price
                                        FROM Films ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    DataTable DT = new DataTable("Films");
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SDA.Fill(DT);
                    DGAllEmp.ItemsSource = DT.DefaultView;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Cart win1 = new Cart();
            win1.Show();
            Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Report win2 = new Report();
            win2.Show();
            Close();
        }

        private void DGAllEmp_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedColumn = DGAllEmp.CurrentCell.Column.DisplayIndex;
            var selectedCell = DGAllEmp.SelectedCells[selectedColumn];
            var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
            if (cellContent is TextBlock)
            {
                MessageBox.Show((cellContent as TextBlock).Text, "Подробнее", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
