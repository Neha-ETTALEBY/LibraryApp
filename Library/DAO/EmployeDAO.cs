using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO
{
    internal class EmployeDAO
    {
        private readonly LibraryDBContext _dbcontext;
       

        // Constructeur qui reçoit le contexte de base de données pour avoir une référence 
        // Ce design pattern est appele dependency injection
        public EmployeDAO(LibraryDBContext context)
        {
            _dbcontext = context;
        }
       
        //cherche  si identifiant et mdp est dans  database pour qu'il puisse se connecter
        public bool GetEmployeByIdentifiantPassword(string identifiant, string motDePasse)
        {
            if (_dbcontext.Employees.Any(e => e.Identifiant == identifiant && e.MotDePasse == motDePasse) != null)
            {
                return true;
            }
            return false;
        }
        public bool GetOnlyIdentifiantEmploye(string identifiant)
        {
            // Vérifier si un employé avec l'identifiant donné existe dans la base de données
            bool identifiantExists = _dbcontext.Employees.Any(e => e.Identifiant == identifiant);

            return identifiantExists;
        }



        // Méthode pour récupérer tous les employés de la base de données
        public List<Employe> GetAllEmployes()
        {
            return _dbcontext.Employees.ToList();
        }

        // Méthode pour récupérer un employé par son ID
        public Employe GetEmployeByID(int employeId)
        {
            return _dbcontext.Employees.FirstOrDefault(e => e.IdEmploye == employeId);
        }

        // Méthode pour ajouter un nouvel employé à la base de données
        public void AddEmploye(Employe employe)
        {
            if (employe == null)
                throw new ArgumentNullException(nameof(employe));

            _dbcontext.Employees.Add(employe);
            _dbcontext.SaveChanges(); // Sauvegarder les changements dans la base de données
        }

        // Méthode pour mettre à jour les informations d'un employé existant
        public bool UpdateEmploye(Employe employe)
        {
            if (employe == null)
                throw new ArgumentNullException(nameof(employe));

            try
            {
                // Rechercher l'employé existant par son ID
                var existingEmploye = _dbcontext.Employees.Find(employe.IdEmploye);

                if (existingEmploye != null)
                {
                    // Mettre à jour les propriétés de l'employé existant avec les nouvelles valeurs
                    existingEmploye.Nom = employe.Nom;
                    existingEmploye.Prenom = employe.Prenom;
                    existingEmploye.AdresseEmail = employe.AdresseEmail;
                    existingEmploye.MotDePasse = employe.MotDePasse;
                    existingEmploye.Identifiant = employe.Identifiant;

                    // Enregistrer les modifications dans la base de données
                    _dbcontext.SaveChanges();

                    return true;
                }

                return false; // L'employé n'a pas été trouvé dans la base de données
            }
            catch (Exception ex)
            {
                // Gérer l'exception ou la renvoyer pour un traitement ultérieur
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }

        // Méthode pour supprimer un employé de la base de données par son ID
        public void DeleteEmploye(Employe employe)
        {
            // Rechercher l'employé à supprimer par son ID
            var employeToDelete = _dbcontext.Employees.FirstOrDefault(e => e.IdEmploye == employe.IdEmploye);

            if (employeToDelete != null)
            {
                _dbcontext.Employees.Remove(employeToDelete);
                _dbcontext.SaveChanges(); // Sauvegarder les changements dans la base de données
            }
        }

       
    }
}
