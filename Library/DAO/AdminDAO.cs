using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.DAO
{
    internal class AdminDAO
    {
        private readonly LibraryDBContext _context;// Référence vers le contexte de la base de données pour effectuer des opérations CRUD.

        // Constructeur qui reçoit le contexte de base de données
        public AdminDAO(LibraryDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Méthode pour récupérer tous les administrateurs de la base de données
        public IEnumerable<Admin> GetAllAdmins()
        {
            return _context.Admins.ToList();
        }

        // Méthode pour récupérer un administrateur par son ID
        public Admin GetAdminById(int adminId)
        {
            return _context.Admins.FirstOrDefault(a => a.IdAdmin == adminId);
        }

        // Méthode pour ajouter un nouvel administrateur à la base de données
        public void AddAdmin(Admin admin)
        {
            if (admin == null)
                throw new ArgumentNullException(nameof(admin));

            _context.Admins.Add(admin);
            _context.SaveChanges(); // Sauvegarder les changements dans la base de données
        }

        // Méthode pour mettre à jour les informations d'un administrateur existant
        public void UpdateAdmin(Admin admin)
        {
            if (admin == null)
                throw new ArgumentNullException(nameof(admin));

            // Rechercher l'administrateur existant par son ID
            var existingAdmin = _context.Admins.Find(admin.IdAdmin);

            if (existingAdmin != null)
            {
                // Mettre à jour les propriétés de l'administrateur existant
                existingAdmin.Nom = admin.Nom;
                existingAdmin.Prenom = admin.Prenom;
                existingAdmin.AdresseEmail = admin.AdresseEmail;
                existingAdmin.Identifiant = admin.Identifiant;
                existingAdmin.MotDePasse = admin.MotDePasse;

                _context.SaveChanges(); // Sauvegarder les changements dans la base de données
            }
        }

        // Méthode pour supprimer un administrateur de la base de données par son ID
        public void DeleteAdmin(int adminId)
        {
            // Rechercher l'administrateur à supprimer par son ID
            var adminToDelete = _context.Admins.Find(adminId);

            if (adminToDelete != null)
            {
                _context.Admins.Remove(adminToDelete);
                _context.SaveChanges(); // Sauvegarder les changements dans la base de données
            }
        }
    }
}
