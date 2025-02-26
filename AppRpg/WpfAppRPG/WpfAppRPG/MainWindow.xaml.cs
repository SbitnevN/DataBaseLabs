using System;
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
            if (!string.IsNullOrWhiteSpace(textBoxLogin.Text) && !string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(Constans.ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(Constans.GetUser, sqlConnection);
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
                        MessageBox.Show("Неудача");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddUser()
        {
            if (textBoxLogin.Text != null && textBoxPassword.Text != null)
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(Constans.ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(Constans.AddUser, sqlConnection);
                    cmd.Parameters.AddWithValue("login", textBoxLogin.Text);
                    cmd.Parameters.AddWithValue("password", textBoxPassword.Text);
                    cmd.ExecuteNonQuery();
                    textBoxLogin.Text = null;
                    textBoxPassword.Text = null;
                    MessageBox.Show("gotovo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            GetUser();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            AddUser();
        }
    }
}
