using Microsoft.EntityFrameworkCore;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAO
{
    internal class LivreDAO
    {
        private readonly LibraryDBContext _context;

        // Constructeur qui prend le contexte de la base de données en paramètre.
        public LivreDAO(LibraryDBContext context)
        {
            _context = context;
        }

        // Méthode pour ajouter un livre à la base de données.
        public void AjouterLivre(Livre livre)
        {
            _context.Livres.Add(livre);
            _context.SaveChanges();
        }

        // Méthode pour mettre à jour les informations d'un livre dans la base de données.
        public void MettreAJourLivre(Livre livre)
        {
            _context.Livres.Update(livre);
            _context.SaveChanges();
        }

        // Méthode pour supprimer un livre de la base de données en utilisant son ID.
        public void SupprimerLivre(int livreId)
        {
            var livre = _context.Livres.Find(livreId);

            if (livre != null)
            {
                _context.Livres.Remove(livre);
                _context.SaveChanges();
            }
        }

        // Méthode pour récupérer tous les livres de la base de données.
        public List<Livre> ObtenirTousLesLivres()
        {
            return _context.Livres.ToList();
        }

        // Méthode pour vérifier la disponibilité d'un livre en utilisant son ID.
        public bool EstDisponible(int livreId)
        {
            var livre = _context.Livres.Find(livreId);
         
            // Pour l'instant, cette méthode renvoie simplement true si le livre existe et false sinon.
            return livre != null;
        }

    }
}
