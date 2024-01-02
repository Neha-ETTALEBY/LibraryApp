using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.DAO
{
    internal class EmployeDAO
    {
        private readonly LibraryDBContext _context;

        // Constructeur qui reçoit le contexte de base de données
        public EmployeDAO(LibraryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Méthode pour récupérer tous les employés de la base de données
        public IEnumerable<Employe> GetAllEmployes()
        {
            return _context.Employees.ToList();
        }

        // Méthode pour récupérer un employé par son ID
        public Employe GetEmployeById(int employeId)
        {
            return _context.Employees.FirstOrDefault(e => e.IdEmploye == employeId);
        }

        // Méthode pour ajouter un nouvel employé à la base de données
        public void AddEmploye(Employe employe)
        {
            if (employe == null)
                throw new ArgumentNullException(nameof(employe));

            _context.Employees.Add(employe);
            _context.SaveChanges(); // Sauvegarder les changements dans la base de données
        }

        // Méthode pour mettre à jour les informations d'un employé existant
        public void UpdateEmploye(Employe employe)
        {
            if (employe == null)
                throw new ArgumentNullException(nameof(employe));

            // Rechercher l'employé existant par son ID
            var existingEmploye = _context.Employees.Find(employe.IdEmploye);

            if (existingEmploye != null)
            {
                // Mettre à jour les propriétés de l'employé existant
                existingEmploye.Nom = employe.Nom;
                existingEmploye.Prenom = employe.Prenom;
                existingEmploye.AdresseEmail = employe.AdresseEmail;
                existingEmploye.Identifiant = employe.Identifiant;
                existingEmploye.MotDePasse = employe.MotDePasse;

                _context.SaveChanges(); // Sauvegarder les changements dans la base de données
            }
        }

        // Méthode pour supprimer un employé de la base de données par son ID
        public void DeleteEmploye(int employeId)
        {
            // Rechercher l'employé à supprimer par son ID
            var employeToDelete = _context.Employees.Find(employeId);

            if (employeToDelete != null)
            {
                _context.Employees.Remove(employeToDelete);
                _context.SaveChanges(); // Sauvegarder les changements dans la base de données
            }
        }
    }
}
