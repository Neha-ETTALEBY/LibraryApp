using Library.Business;
using Library.DAO;
using Library.Models;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace Library.GUI
{
    /// <summary>
    /// Logique d'interaction pour PersonnelStaffLivreCRUD.xaml
    /// </summary>
    public partial class PersonnelStaffLivreCRUD : Window
    {
        LibraryDBContext dbContext = new LibraryDBContext();
        AdminManager _adminManager;
        EmployeManager _employeManager;
        LivreManager _livreManager;
        public PersonnelStaffLivreCRUD()
        {
            InitializeComponent();

            _adminManager = new AdminManager(new AdminDAO(dbContext));
            _employeManager = new EmployeManager(new EmployeDAO(dbContext));
            _livreManager= new LivreManager(new LivreDAO(dbContext));

            // Récupérer la référence à l'objet CollectionViewSource depuis les ressources et définir la source de données
            List<Livre> livres = _adminManager.CheckLivres();
            CollectionViewSource livresViewSource = (CollectionViewSource)Resources["LivresViewSource"];
            livresViewSource.Source = livres;
        }

        private void ChoisirFichier_Click(object sender, RoutedEventArgs e)
        {
            // Utiliser un OpenFileDialog pour permettre à l'utilisateur de choisir un fichier
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tous les fichiers (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Obtenez le chemin d'accès au fichier choisi
                string cheminFichier = openFileDialog.FileName;

                // Faites quelque chose avec le chemin du fichier, par exemple, affichez-le dans une TextBox
                cheminFichierTextBox.Text = cheminFichier;
            }
        }
        private void ViderChamps()
        {
           TitreTextBox.Text = "";
           AuteurTextBox.Text = "";
            EditeurTextBox.Text = "";
            AnneePubTextBox.Text = "";
            CategorieTextBox.Text = "";
            DisponibleTextBox.Text = "";
            cheminFichierTextBox.Text = "";
        }


        private void GestionLivre(object sender, RoutedEventArgs e)
        {

        }

        private void GestionEmploye(object sender, RoutedEventArgs e)
        {
            AdminWindowCRUD adminWindowCRUD = new AdminWindowCRUD();
            adminWindowCRUD.Show();
            Hide();
        }

        private void AjouterLivre(object sender, RoutedEventArgs e)
        {
            // Récupérer les données des inputs
            string titre = TitreTextBox.Text;
            string auteur = AnneePubTextBox.Text;
            string editeur = EditeurTextBox.Text;
            string anneepublication = AnneePubTextBox.Text;
            string categorie = CategorieTextBox.Text;
            string disponible = DisponibleTextBox.Text.ToLower();
            string cheminFichier = cheminFichierTextBox.Text;
            if (titre != "" && auteur != "" && editeur != "" && anneepublication != "" && categorie != "" && disponible!="" && cheminFichier!="")
            {
                // Création d'un nouvel employé avec les données récupérées
                Livre nouvelLivre = new Livre()
                {
                    Titre = titre,
                    Auteur = auteur,
                    Editeur = editeur,
                    AnneePublication = int.Parse(anneepublication),
                    Categorie = categorie,
                    Disponible = (disponible == "oui") ? true : (disponible == "non") ? false : default(bool),
                    // Utilisez ReadAllBytes pour lire le contenu du fichier en tant qu'array de bytes
                    Image = File.ReadAllBytes(cheminFichier) //Assurez-vous d'avoir using System.IO
                };

                _adminManager.CreateLivre(nouvelLivre);
                MessageBox.Show("Le livre a été ajouté avec succès.");


                ViderChamps();

               
            }
            else
            {
                MessageBox.Show("verifier les champs ne doit  pas etre  vide");
            }
            //ces trois lignes juste pour refresh 
            List<Livre> livres = _adminManager.CheckLivres();
            CollectionViewSource livresViewSource = (CollectionViewSource)Resources["LivresViewSource"];
            livresViewSource.Source = livres;


        }

        private void SupprimerLivre(object sender, RoutedEventArgs e)
        {

            // Vérifier s'il y a un livre sélectionné
            if (livresListView.SelectedItem != null)
            {
                // Récupérer le livre sélectionné à partir de la source de données du ListView
                Livre selectedLivre = livresListView.SelectedItem as Livre;
                // Supprimer livre  de la source de données
                _adminManager.RemoveLivre(selectedLivre);
                MessageBox.Show("Le livre a été supprimé avec succès.");
                ViderChamps();
                //ces trois lignes juste pour refresh 
                List<Livre> livres = _adminManager.CheckLivres();
                CollectionViewSource livresViewSource = (CollectionViewSource)Resources["LivresViewSource"];
                livresViewSource.Source = livres;

            }
        }

        private void ModifierLivre(object sender, RoutedEventArgs e)
        {
            // Vérifier s'il y a un employé sélectionné
            if (livresListView.SelectedItem != null)
            {
                // Récupérer l'employé sélectionné à partir de la source de données du ListView
                Livre selectedLivre = livresListView.SelectedItem as Livre;

                // Conserver les anciennes valeurs si les champs TextBox sont vides
                selectedLivre.Titre = !string.IsNullOrEmpty(TitreTextBox.Text) ? TitreTextBox.Text : selectedLivre.Titre;
                selectedLivre.Auteur = !string.IsNullOrEmpty(AuteurTextBox.Text) ? AuteurTextBox.Text : selectedLivre.Auteur;
                selectedLivre.Editeur = !string.IsNullOrEmpty(EditeurTextBox.Text) ? EditeurTextBox.Text : selectedLivre.Editeur;
                selectedLivre.AnneePublication = !string.IsNullOrEmpty(AnneePubTextBox.Text) ? int.Parse(AnneePubTextBox.Text) : selectedLivre.AnneePublication;
                selectedLivre.Categorie = !string.IsNullOrEmpty(CategorieTextBox.Text) ? CategorieTextBox.Text : selectedLivre.Categorie;
                selectedLivre.Disponible = !string.IsNullOrEmpty(DisponibleTextBox.Text) ? (DisponibleTextBox.Text == "oui") ? true : (DisponibleTextBox.Text == "non") ? false : default(bool) : selectedLivre.Disponible;
                selectedLivre.Image = !string.IsNullOrEmpty(DisponibleTextBox.Text) ? File.ReadAllBytes(cheminFichierTextBox.Text) : selectedLivre.Image;

                // Appeler la méthode de mise à jour du livre dans la base de données
                if (_adminManager.UpdateLivre(selectedLivre))
                {
                    List<Livre> livres = _adminManager.CheckLivres();
                    CollectionViewSource livresViewSource = (CollectionViewSource)Resources["LivresViewSource"];
                    livresViewSource.Source = livres;

                    // Réinitialiser les champs TextBox
                    ViderChamps();

                    // Afficher un message de succès ou effectuer d'autres actions nécessaires
                    MessageBox.Show("Livre a été modifié avec succès.", "Succès");

                }

                //ces trois lignes juste pour actualiser  


            }
        

        }
        

         private void TitreTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AuteurTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EditeurTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AnneePubTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CategorieTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DisponibleTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ImageTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
