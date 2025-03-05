using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace WpfAppRPG
{
    /// <summary>
    /// Логика взаимодействия для LocationView.xaml
    /// </summary>
    public partial class LocationView : Window
    {
        private User _user = new User();
        private List<Person> _persons = new List<Person>();
        private List<Mob> _mobs = new List<Mob>();
        public LocationView(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void GetPersonsOnLocation(int locId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                sqlConnection.Open();
                string sql = $"SELECT p.p_ID, p.p_Name, p.p_Nation, p.p_Lvl, p.p_Gender, p.u_ID" +
                    $" FROM loc_p LP INNER JOIN person P ON P.p_ID = LP.p_ID INNER JOIN [location] L ON L.l_ID = LP.l_ID" +
                    $" WHERE P.u_ID = {_user.Id} AND L.l_ID = {locId}";
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
                    _persons = new List<Person>();
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void GetMobsOnLocation(int locId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(DataBaseConstants.ConnectionString);
                sqlConnection.Open();
                string sql = $"SELECT m.m_ID, m.m_Name, m.m_Lvl, m.m_Type FROM loc_m LP INNER JOIN mob M ON M.m_ID = LP.m_ID INNER JOIN [location] L ON L.l_ID = LP.l_ID WHERE L.l_ID = {locId}";
                SqlCommand cmd = new SqlCommand(sql, sqlConnection);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    _mobs = new List<Mob>();
                    while (sqlDataReader.Read())
                    {
                        Mob mob = new Mob
                        {
                            Id = sqlDataReader.GetInt32(0),
                            Name = sqlDataReader.GetString(1),
                            Level = sqlDataReader.GetInt32(2),
                            Type = sqlDataReader.GetString(3)
                        };
                        _mobs.Add(mob);
                    }
                    Console.WriteLine();
                }
                else
                {
                    _mobs = new List<Mob>();
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void UpdateGridPerson()
        {
            PersonLocationDataGrid.ItemsSource = _persons;
            PersonLocationDataGrid.Items.Refresh();
        }

        private void UpdateGridMob()
        {
            MobLocationDataGrid.ItemsSource = _mobs;
            MobLocationDataGrid.Items.Refresh();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            GetPersonsOnLocation(1);
            GetMobsOnLocation(1);
            UpdateGridMob();
            UpdateGridPerson();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            GetPersonsOnLocation(2);
            GetMobsOnLocation(2);
            UpdateGridMob();
            UpdateGridPerson();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            GetPersonsOnLocation(3);
            GetMobsOnLocation(3);
            UpdateGridMob();
            UpdateGridPerson();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            GetPersonsOnLocation(4);
            GetMobsOnLocation(4);
            UpdateGridMob();
            UpdateGridPerson();
        }
    }
}
