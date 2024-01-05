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
using System.Windows.Shapes;

namespace Library.GUI
{
    /// <summary>
    /// Logique d'interaction pour FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        public FirstWindow()
        {
            InitializeComponent();
        }

        private void AdherentRoleBtn_Click(object sender, RoutedEventArgs e)
        {

            Accueil home = new Accueil(); //à partir du page  d'acceuil il peut soit se connecter soit s'inscrire
                home.Show();
                Hide();
            
        }

        private void AdminRolebtn_Click(object sender, RoutedEventArgs e)
        {
            PersonnelStaffLogin admin = new PersonnelStaffLogin();
            admin.Show();
            Hide();
        }

        private void EmployerRoleBtn_Click(object sender, RoutedEventArgs e)
        {
            PersonnelStaffLogin admin = new PersonnelStaffLogin();
            admin.Show();
            Hide();
        }
    }
}
