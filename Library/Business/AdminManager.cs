using Library.DAO;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business
{
    internal class AdminManager
    {
        readonly AdminDAO _adminDAO;
        private readonly EmployeDAO _employeDAO;
        private readonly LivreDAO _livreDAO;
        private readonly ReservationDAO _reservationDAO;

        public AdminManager(AdminDAO adminDAO, EmployeDAO employeDAO, LivreDAO livreDAO, ReservationDAO reservationDAO)
        {
            _adminDAO = adminDAO;
            _employeDAO = employeDAO;
            _livreDAO = livreDAO;
            _reservationDAO = reservationDAO;
        }
        public AdminManager(LibraryDBContext dbContext)
        {
            _adminDAO = new AdminDAO(dbContext);
        }
        // Connexion d'un Admin
        public bool Connecter(string identifiant, string motDePasse)
        {
            return _adminDAO.GetAdmineByIdentifiantPassword(identifiant, motDePasse);
        }

        // Ajout d'un nouvel employé
        public void CreateEmploye(Employe employe)
        {
            // Logique d'ajout d'un employé
            _employeDAO.AddEmploye(employe);
        }

        // Ajout d'un nouveau livre
        public void CreateLivre(Livre livre)
        {
            // Logique d'ajout d'un livre
            _livreDAO.AddLivre(livre);
        }

        // Consultation de tous les employés
         public List<Employe> CheckEmployes()
         {

            return _employeDAO.GetAllEmployes();
         }

        // Consultation de tous les livres
        public List<Livre>CheckLivres()
        {
            // Logique de consultation des livres
            return _livreDAO.GetLivres();
        }

        // Suppression d'un employé
        public void RemoveEmploye(int employeId)
        {
            // Logique de suppression d'un employé
            _employeDAO.DeleteEmploye(employeId);
        }

        // Suppression d'un livre
        public void RemoveLivre(int livreId)
        {
            // Logique de suppression d'un livre
            _livreDAO.RemoveLivre(livreId);
        }

        // Autres méthodes pour la gestion des réservations, des admins, etc.
    }
}