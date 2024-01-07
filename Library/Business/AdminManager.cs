﻿using Library.DAO;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAO;

namespace Library.Business
{
    internal class AdminManager
    {
        readonly AdminDAO _adminDAO;

        public AdminManager(AdminDAO adminDAO)
        {
            _adminDAO = adminDAO;
        }

        // Connexion d'un Admin
        public bool Connecter(string identifiant, string motDePasse)
        {
            return _adminDAO.GetAdmineByIdentifiantPassword(identifiant, motDePasse);
        }

        // Ajout d'un nouvel employé
        public void CreateEmploye(Employe employe)
        {
            EmployeDAO _employeDAO = new EmployeDAO(new LibraryDBContext());

            _employeDAO.AddEmploye(employe);
        }

        // Ajout d'un nouveau livre
        public void CreateLivre(Livre livre)
        {
            LivreDAO _livreDAO = new LivreDAO(new LibraryDBContext());

            _livreDAO.AddLivre(livre);
        }
        public bool UpdateEmploye(Employe e)
        {
            EmployeDAO _employeDAO = new EmployeDAO(new LibraryDBContext());
            if (CheckIdentifiantEmployeExists(e.Identifiant))
                return false;
          else 
              return   _employeDAO.UpdateEmploye(e);

        }
        public bool CheckIdentifiantEmployeExists(String identifiant)
            {
            EmployeDAO _employeDAO = new EmployeDAO(new LibraryDBContext());
           return   _employeDAO.GetOnlyIdentifiantEmploye(identifiant);
        }
        // Consultation de tous les employés
         public List<Employe> CheckEmployes()
         {
            EmployeDAO _employeDAO = new EmployeDAO(new LibraryDBContext());

            return _employeDAO.GetAllEmployes();
         }

        // Consultation de tous les livres
        public List<Livre>CheckLivres()
        {
            LivreDAO _livreDAO = new LivreDAO(new LibraryDBContext());

            // Logique de consultation des livres
            return _livreDAO.GetLivres();
        }

        // Suppression d'un employé
        public void RemoveEmploye(Employe employe)
        {
            EmployeDAO _employeDAO = new EmployeDAO(new LibraryDBContext());

            // Logique de suppression d'un employé
            _employeDAO.DeleteEmploye(employe);
        }

        // Suppression d'un livre
        public void RemoveLivre(int livreId)
        {
            LivreDAO _livreDAO = new LivreDAO(new LibraryDBContext());

            // Logique de suppression d'un livre
            _livreDAO.RemoveLivre(livreId);
        }

        // Autres méthodes pour la gestion des réservations, des admins, etc.
    }
}