using System.Windows;
using System.Data.SqlClient;

namespace WpfAppRPG
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetUser()
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) && string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                    sqlConnection.Open();
                    string sql = "SELECT * FROM [user] WHERE [u_Name] = @login and [u_Pass] = @password";
                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("login", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("password", textBoxPassword.Text);
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        User user = new User
                        {
                            Id = sqlDataReader.GetInt32(0),
                            Name = sqlDataReader.GetString(1),
                            Email = sqlDataReader.GetString(2),
                            Password = sqlDataReader.GetString(3)
                        };
                        PlayerPersonsAddView playerPersonsAddView = new PlayerPersonsAddView(user);
                        this.Hide();
                        playerPersonsAddView.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("No!");
                    }

                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void AddUser()
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) && string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                    sqlConnection.Open();
                    string sql = "INSERT INTO [USER] VALUES (@login, 'fafjadf@govno.com', @password)";
                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("login", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("password", textBoxPassword.Text);
                    cmd.ExecuteNonQuery();
                    textBoxLogin.Text = null;
                    textBoxPassword.Text = null;
                    MessageBox.Show("gotovo");
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("TextBoxes is Empty");
            }
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            GetUser();
        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            AddUser();
        }
    }
}
