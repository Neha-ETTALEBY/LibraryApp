using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Models;

namespace Library.Business
{
    internal class EmployeManager
    {
        private readonly EmployeDAO _employeDAO;
        private readonly LivreDAO _livreDAO;
        private readonly ReservationDAO _reservationDAO;

        public EmployeManager(EmployeDAO employeDAO, LivreDAO livreDAO, ReservationDAO reservationDAO)
        {
            _employeDAO = employeDAO;
            _livreDAO = livreDAO;
            _reservationDAO = reservationDAO;
        }

        // Connexion d'un employé
        public Employe Connecter(string identifiant, string motDePasse)
        {
            return _employeDAO.GetEmployeByIdentifiantPassword(identifiant,motDePasse);
        }


        // Création d'un nouveau livre
        public void CreateLivre(Livre livre)
        {
            _livreDAO.AddLivre(livre);
        }

        // Suppression d'un livre
        public void RemoveLivre(int livreId)
        {
            _livreDAO.RemoveLivre(livreId);
        }
        // Consultation de tous les livres
        public List<Livre> CheckLivres()
        {
            // Logique de consultation des livres
            return _livreDAO.GetLivres();
        }

    }
}
