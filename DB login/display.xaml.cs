using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DB_login
{
    /// <summary>
    /// Interaction logic for display.xaml
    /// </summary>
    public partial class display : Page
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; user = root; database = logindb; port = 3306; password = '';");
        public display()
        {
            InitializeComponent();
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `hospitals`", connection);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("hospitals");
            sda.Fill(dt);
            dbtable.ItemsSource = dt.DefaultView;
            connection.Close();

            //var list = new ObservableCollection<DataObject>();
           
        }

        private void dbtable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
