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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DB_login
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
        MySqlConnection connection = new MySqlConnection("server = localhost; user = root; database = logindb; port = 3306; password = '';");
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT `username`, `password` FROM `logintable` WHERE `username` = '" + TxtBox_Username.Text + "' AND `password` = '" + TxtBox_Password.Text + "'", connection);

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                NavigationWindow window = new NavigationWindow();
                window.Source = new Uri("display.xaml", UriKind.Relative);
                window.Show();
                this.Close();
            }
            else
            {

            }
            connection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT `username`, `password` INTO `logintable`");
        }
    }
}
