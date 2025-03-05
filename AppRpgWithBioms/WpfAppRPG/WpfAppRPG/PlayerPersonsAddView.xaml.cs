using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace WpfAppRPG
{
    /// <summary>
    /// Логика взаимодействия для PlayerPersonsAddView.xaml
    /// </summary>
    public partial class PlayerPersonsAddView : Window
    {
        private User _user;
        private IList<Person> _persons;
        
        public PlayerPersonsAddView(User user)
        {
            InitializeComponent();
            _user = user;
            idLabel.Content = _user.Id;
            GetPerson();
            MainDataGrid.ItemsSource = _persons;
            MainDataGrid.Items.Refresh();
        }
        private void AddPerson()
        {
            if (string.IsNullOrWhiteSpace(textBoxNickname.Text) && string.IsNullOrWhiteSpace(textBoxRace.Text) && string.IsNullOrWhiteSpace(textBoxGender.Text) && string.IsNullOrWhiteSpace(textBoxLevel.Text))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                    sqlConnection.Open();
                    string sql = "INSERT INTO [person] VALUES (@name, @nation, @level, @gender, @id)";
                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("name", textBoxNickname.Text);
                    cmd.Parameters.AddWithValue("nation", textBoxRace.Text);
                    cmd.Parameters.AddWithValue("level", textBoxLevel.Text);
                    cmd.Parameters.AddWithValue("gender", textBoxGender.Text);
                    cmd.Parameters.AddWithValue("id", _user.Id);
                    cmd.ExecuteNonQuery();
                    textBoxNickname.Text = "";
                    textBoxRace.Text = "";
                    textBoxGender.Text = "";
                    textBoxLevel.Text = "";
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("TextBoxes is Null");
            }
        }

        private void GetPerson()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                sqlConnection.Open();
                string sql = "SELECT * FROM [person]";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    _persons = new List<Person>();
                    while(sqlDataReader.Read())
                    {
                        Person person = new Person
                        {
                            Id = sqlDataReader.GetInt32(0),
                            Name = sqlDataReader.GetString(1),
                            Nation = sqlDataReader.GetString(2),
                            Level = sqlDataReader.GetInt32(3),
                            Gender = sqlDataReader.GetString(4),
                            UserId = sqlDataReader.GetInt32(5)
                        };
                        _persons.Add(person);
                    }
                    Console.WriteLine();
                }
                else
                {
                    MessageBox.Show("(((");
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void SortBy(string sortAttribute)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                sqlConnection.Open();
                string sql = $"SELECT * FROM [person] ORDER BY [{sortAttribute}]";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    _persons = new List<Person>();
                    while (sqlDataReader.Read())
                    {
                        Person person = new Person
                        {
                            Id = sqlDataReader.GetInt32(0),
                            Name = sqlDataReader.GetString(1),
                            Nation = sqlDataReader.GetString(2),
                            Level = sqlDataReader.GetInt32(3),
                            Gender = sqlDataReader.GetString(4),
                            UserId = sqlDataReader.GetInt32(5)
                        };
                        _persons.Add(person);
                    }
                    Console.WriteLine();
                }
                else
                {
                    MessageBox.Show("Не вышло");
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        private void AddClick(object sender, RoutedEventArgs e)
        {
            AddPerson();
            Update();
        }

        private void Update()
        {
            GetPerson();
            MainDataGrid.ItemsSource = _persons;
            MainDataGrid.Items.Refresh();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (MainDataGrid.SelectedItem != null)
            {
                Person person = MainDataGrid.SelectedItem as Person;
                PlayerPersonEdit playerPersonEdit = new PlayerPersonEdit(person);
                playerPersonEdit.ShowDialog();
                if (playerPersonEdit.DialogResult == true)
                {
                    SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                    sqlConnection.Open();
                    string sql = "UPDATE [person] SET [P_Name] = @name, [p_Nation] = @nation, [p_Lvl] = @level, [p_Gender] = @gender, [u_ID] = @id WHERE [p_ID] = @p_id";
                    SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                    cmd.Parameters.AddWithValue("p_id", person.Id);
                    cmd.Parameters.AddWithValue("name", person.Name);
                    cmd.Parameters.AddWithValue("nation", person.Nation);
                    cmd.Parameters.AddWithValue("level", person.Level);
                    cmd.Parameters.AddWithValue("gender", person.Gender);
                    cmd.Parameters.AddWithValue("id", person.UserId);
                    cmd.ExecuteNonQuery();
                }
                Update();
            }        
        }

        private void SortByLevelClick(object sender, RoutedEventArgs e)
        {
            SortBy("p_Lvl");
            MainDataGrid.ItemsSource = _persons;
            MainDataGrid.Items.Refresh();
        }

        private void SortByNameClick(object sender, RoutedEventArgs e)
        {
            SortBy("p_Name");
            MainDataGrid.ItemsSource = _persons;
            MainDataGrid.Items.Refresh();
        }

        private void LocationClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LocationView lv = new LocationView(_user);
            lv.ShowDialog();
            this.Show();
        }
    }
}
