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
            return _employeDAO.GetEmployeBy_identifiant_Password(identifiant,motDePasse);
        }


        // Création d'un nouveau livre
        public void CreerLivre(Livre livre)
        {
            _livreDAO.AjouterLivre(livre);
        }

        // Suppression d'un livre
        public void SupprimerLivre(int livreId)
        {
            _livreDAO.SupprimerLivre(livreId);
        }
        // Consultation de tous les livres
        public List<Livre> ConsulterLivres()
        {
            // Logique de consultation des livres
            return _livreDAO.ObtenirTousLesLivres();
        }

    }
}
