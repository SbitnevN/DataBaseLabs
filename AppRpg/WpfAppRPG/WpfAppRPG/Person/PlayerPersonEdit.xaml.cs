﻿using System.Windows;

namespace WpfAppRPG
{
    /// <summary>
    /// Логика взаимодействия для PlayerPersonEdit.xaml
    /// </summary>
    public partial class PlayerPersonEdit : Window
    {
        private Person _person;
        
        public PlayerPersonEdit(Person person)
        {
            InitializeComponent();
            _person = person;
            Initialize();
        }

        private void Initialize()
        {
            textBoxNickname.Text = _person.Name;
            textBoxGender.Text = _person.Gender;
            textBoxLevel.Text = _person.Level.ToString();
            textBoxRace.Text = _person.Nation;
            idLabel.Content = _person.UserId;
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            _person.Name = textBoxNickname.Text;
            _person.Gender = textBoxGender.Text;
            _person.Nation = textBoxRace.Text;
            _person.Level = int.Parse(textBoxLevel.Text);
            this.Close();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
