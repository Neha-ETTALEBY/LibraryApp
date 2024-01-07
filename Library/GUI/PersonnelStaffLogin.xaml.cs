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
using Library.Business;
using Library.Models;
using Library.DAO;

namespace Library.GUI
{
    /// <summary>
    /// Logique d'interaction pour PersonnelStaffLogin.xaml
    /// </summary>
    public partial class PersonnelStaffLogin : Window
    {
        private string _roleChoisi;//pour savoir le role choisi dans FirstWindow

        LibraryDBContext dbContext = new LibraryDBContext();
        AdminManager _adminManager;
        EmployeManager _employeManager;
       // Créez une instance de LibraryDBContext et passez-la à AdminManager

        public PersonnelStaffLogin(String role_choisi)
        {
         
            InitializeComponent();
           _roleChoisi = role_choisi;
            _adminManager = new AdminManager(new AdminDAO(dbContext));
            _employeManager =new EmployeManager(new EmployeDAO(dbContext));
        }

        private void ConnecterBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Text;
           

            if (_roleChoisi == "Admin" && _adminManager.Connecter(username, password))
            {
                MessageBox.Show("Connecté en tant qu'admin");
                // Effectuez l'action spécifique pour l'admin connecté
                AdminWindowCRUD adminWindowCRUD = new AdminWindowCRUD();
                adminWindowCRUD.Show();
                Hide();
            }
   
            else if (_roleChoisi == "Employe" && _employeManager.Connecter(username,password))
            {
                MessageBox.Show("Connecté en tant qu'employé");
                // Effectuez l'action spécifique pour l'employé connecté
            }
            else
            {
                MessageBox.Show("Échec de la connexion");
            }

            //     LivreManager l = new LivreManager(new LivreDAO(conn));


        }

        private void PasswordTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UsernameTxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
            