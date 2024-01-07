using Library.Business;
using Library.DAO;
using Library.Models;
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
    /// Logique d'interaction pour AdminWindowCRUD.xaml
    /// </summary>
    public partial class AdminWindowCRUD : Window
    {

        LibraryDBContext dbContext = new LibraryDBContext();
        AdminManager _adminManager;
        EmployeManager _employeManager;
        public AdminWindowCRUD()
        {
            InitializeComponent();

            _adminManager = new AdminManager(new AdminDAO(dbContext));
            _employeManager = new EmployeManager(new EmployeDAO(dbContext));
            List<Employe> employees = _adminManager.CheckEmployes();
            // Récupérer la référence à l'objet CollectionViewSource depuis les ressources et définir la source de données
            CollectionViewSource employeesViewSource = (CollectionViewSource)Resources["EmployeesViewSource"];
            employeesViewSource.Source = employees;

        }

        private void ViderChamps()
        {
            nomTextBox.Text = "";
            prenomTextBox.Text = "";
            emailTextBox.Text = "";
            identifiantTextBox.Text = "";
            motDePasseTextBox.Text = "";
        }



        private void AjouterEmploye(object sender, RoutedEventArgs e)
        {

            // Récupérer les données des inputs
            string nom = nomTextBox.Text;
            string prenom = prenomTextBox.Text;
            string adresseEmail = emailTextBox.Text;
            string identifiant = identifiantTextBox.Text;
            string motDePasse = motDePasseTextBox.Text;
            if (nom != "" && prenom != "" && adresseEmail != "" && identifiant != "" && motDePasse != "")
            {
                // Création d'un nouvel employé avec les données récupérées
                Employe nouvelEmploye = new Employe()
                {
                    Nom = nom,
                    Prenom = prenom,
                    AdresseEmail = adresseEmail,
                    Identifiant = identifiant,
                    MotDePasse = motDePasse
                };


                // Ajout du nouvel employé dans la base de données
                _adminManager.CreateEmploye(nouvelEmploye);
                ViderChamps();

                // Afficher un message de succès ou effectuer d'autres actions nécessaires
                MessageBox.Show("L'employé a été ajouté avec succès.");
                List<Employe> employees = _adminManager.CheckEmployes();
                // Récupérer la référence à l'objet CollectionViewSource depuis les ressources et définir la source de données
                CollectionViewSource employeesViewSource = (CollectionViewSource)Resources["EmployeesViewSource"];
                employeesViewSource.Source = employees;
            }
            else
            {
                MessageBox.Show("verifier les champs ne doit  pas etre  vide");
            }

        }

        private void SupprimerEmploye(object sender, RoutedEventArgs e)
        {
            // Vérifier s'il y a un employé sélectionné
            if (employeesListView.SelectedItem != null)
            {
                // Récupérer l'employé sélectionné à partir de la source de données du ListView
                Employe selectedEmployee = employeesListView.SelectedItem as Employe;

                // Supprimer l'employé de la source de données
                _adminManager.RemoveEmploye(selectedEmployee);
                ViderChamps();
                //ces trois lignes juste pour  refresh la liste après suppress
                List<Employe> employees = _adminManager.CheckEmployes();
                CollectionViewSource employeesViewSource = (CollectionViewSource)Resources["EmployeesViewSource"];
                employeesViewSource.Source = employees;

            }
        }
        private void ModifierEmploye(object sender, RoutedEventArgs e)
        {

            // Vérifier s'il y a un employé sélectionné
            if (employeesListView.SelectedItem != null)
            {
                // Récupérer l'employé sélectionné à partir de la source de données du ListView
                Employe selectedEmployee = employeesListView.SelectedItem as Employe;

                // Conserver les anciennes valeurs si les champs TextBox sont vides
                selectedEmployee.Nom = !string.IsNullOrEmpty(nomTextBox.Text) ? nomTextBox.Text : selectedEmployee.Nom;
                selectedEmployee.Prenom = !string.IsNullOrEmpty(prenomTextBox.Text) ? prenomTextBox.Text : selectedEmployee.Prenom;
                selectedEmployee.AdresseEmail = !string.IsNullOrEmpty(emailTextBox.Text) ? emailTextBox.Text : selectedEmployee.AdresseEmail;
                selectedEmployee.Identifiant = !string.IsNullOrEmpty(identifiantTextBox.Text) ? identifiantTextBox.Text : selectedEmployee.Identifiant;
                selectedEmployee.MotDePasse = !string.IsNullOrEmpty(motDePasseTextBox.Text) ? motDePasseTextBox.Text : selectedEmployee.MotDePasse;

                // Appeler la méthode de mise à jour de l'employé dans la base de données
                if (_adminManager.UpdateEmploye(selectedEmployee))
                {
                    // Actualiser la liste après modification
                    List<Employe> employees = _adminManager.CheckEmployes();
                    CollectionViewSource employeesViewSource = (CollectionViewSource)Resources["EmployeesViewSource"];
                    employeesViewSource.Source = employees;

                    // Réinitialiser les champs TextBox
                    ViderChamps();

                    // Afficher un message de succès ou effectuer d'autres actions nécessaires
                    MessageBox.Show("L'employé a été modifié avec succès.", "Succès");
                }
                
              
                   
                
             
            }
        
         
            
       } 


        private void GestionLivre(object sender, RoutedEventArgs e)
        {
            PersonnelStaffLivreCRUD personnelStaffLivreCRUD = new PersonnelStaffLivreCRUD();
            personnelStaffLivreCRUD.Show();
            Hide();
        }

        private void GestionEmploye(object sender, RoutedEventArgs e)
        {

        }

        private void nomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void prenomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void identifiantTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void motDePasseTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}
