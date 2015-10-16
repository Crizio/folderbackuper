﻿using System;
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

namespace FolderBackup.Client
{
    /// <summary>
    /// Logica di interazione per RegisterWindow.xaml
    /// </summary>
    
    public partial class RegisterWindow : Window
    {
        public Window parent { get; set; }
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = this.usernameTxtBox.Text;
            string password = this.passwordTxtBox.Password;

            if (username.Equals(""))
            {
                MessageBox.Show(this, "Username cannot be empty!", "Missing username", MessageBoxButton.OK);
                return;
            }

            if (password.Equals(""))
            {
                MessageBox.Show(this, "Password cannot be empty!", "Missing password", MessageBoxButton.OK);
                return;
            }

            BackupServiceClient server = new BackupServiceClient();
            if (server.register(username, password))
            {
                MessageBox.Show(this, "Registration succeed. You can log in now.", "Registration succeed!", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show(this, "Registration procedure failed!", "Error", MessageBoxButton.OK);
            }
        }

        
    }
}
