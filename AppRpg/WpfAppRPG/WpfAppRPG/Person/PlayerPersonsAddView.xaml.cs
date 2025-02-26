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
        private List<Person> _persons;

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
            if (!string.IsNullOrWhiteSpace(textBoxNickname.Text) && !string.IsNullOrWhiteSpace(textBoxRace.Text)
                && !string.IsNullOrWhiteSpace(textBoxGender.Text) && !string.IsNullOrWhiteSpace(textBoxLevel.Text))
            {
                try
                {
                    SqlConnection sqlConnection = new SqlConnection(Constans.ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(Constans.AddPerson, sqlConnection);
                    cmd.Parameters.AddWithValue("name", textBoxNickname.Text);
                    cmd.Parameters.AddWithValue("nation", textBoxRace.Text);
                    cmd.Parameters.AddWithValue("level", textBoxLevel.Text);
                    cmd.Parameters.AddWithValue("gender", textBoxGender.Text);
                    cmd.Parameters.AddWithValue("id", _user.Id);
                    cmd.ExecuteNonQuery();
                    textBoxNickname.Text = string.Empty;
                    textBoxRace.Text = string.Empty;
                    textBoxGender.Text = string.Empty;
                    textBoxLevel.Text = string.Empty;
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("TextBoxes is empty");
            }
        }

        private void GetPerson()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Constans.ConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(Constans.GetPerson, sqlConnection);
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
                    MessageBox.Show("Не найдено");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
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

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainDataGrid.SelectedItem != null)
            {
                Person person = MainDataGrid.SelectedItem as Person;
                PlayerPersonEdit playerPersonEdit = new PlayerPersonEdit(person);
                playerPersonEdit.ShowDialog();
                if (playerPersonEdit.DialogResult == true)
                {
                    SqlConnection sqlConnection = new SqlConnection(Constans.ConnectionString);
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(Constans.EditPerson, sqlConnection);
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
    }
}
