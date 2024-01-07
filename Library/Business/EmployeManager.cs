using System;
using System.Collections.Generic;
using Library.DAO;
using Library.Models;

namespace Library.Business
{
    internal class EmployeManager
    {
        private readonly EmployeDAO _employeDAO;


        public EmployeManager(EmployeDAO employeDAO)
        {
            _employeDAO = employeDAO;
 
        }
        public EmployeManager(LibraryDBContext dbContext)
        {
            _employeDAO = new EmployeDAO(dbContext);
        }

        // Connexion d'un employé
        public bool Connecter(string identifiant, string motDePasse)
        {
            return _employeDAO.GetEmployeByIdentifiantPassword(identifiant,motDePasse);
        }


        // Création d'un nouveau livre
        public void CreateLivre(Livre livre)
        {
            LivreDAO _livreDAO = new LivreDAO(new LibraryDBContext());
            _livreDAO.AddLivre(livre);
        }

        // Suppression d'un livre
        public void RemoveLivre(int livreId)
        {
            LivreDAO _livreDAO = new LivreDAO(new LibraryDBContext());
            _livreDAO.RemoveLivre(livreId);
        }
        // Consultation de tous les livres
        public List<Livre> CheckLivres()
        {
            LivreDAO _livreDAO = new LivreDAO(new LibraryDBContext());
            return _livreDAO.GetLivres();
        }

    }
}
