using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Library.Models;
using System.Linq;
namespace Library.DAO
{
    internal class LivreDAO
    {
        // La déclaration de readonly sur un champ signifie que sa valeur ne peut être modifiée qu'à l'intérieur du constructeur de la classe
        private readonly LibraryDBContext _dbContext; //L'objet dbContext encapsule la connexion à la base de données + l'underscore c'est une convention de codage pour dire que c'est un champ de classe

        // Constructeur qui reçoit le contexte de base de données pour avoir une référence 
        // Ce design pattern est appele dependency injection
        public LivreDAO(LibraryDBContext context)
        {
            _dbContext = context;
        }
        public LivreDAO() { }   
        // la méthode pour ajouter un livre

        public void AddLivre(Livre livre)
        {
            _dbContext.Livres.Add(livre);
            _dbContext.SaveChanges(); // to save the changes. This method is necessary to persist the changes.
        }
        // la methode qui retourne un livre en se basant de son id
        public Livre GetLivreByID(int id)
        {
            return _dbContext.Livres.FirstOrDefault(l => l.IdLivre == id); // lambda expression, default = null, "a" parameter represents each livre in the table
        }
        //  la methode qui fait l'update d'un livre en se basant de son id
        public bool UpdateLivre(Livre updatedLivre)
        {
            if (updatedLivre == null)
                throw new ArgumentNullException(nameof(updatedLivre));

            try
            {
                // Rechercher l'employé existant par son ID
                var existingLivre = _dbContext.Livres.Find(updatedLivre.IdLivre);

                if (existingLivre != null)
                {
                    // Mettre à jour les propriétés de l'employé existant avec les nouvelles valeurs
                    existingLivre.Titre = updatedLivre.Titre;
                    existingLivre.Auteur = updatedLivre.Auteur;
                    existingLivre.Editeur = updatedLivre.Editeur;
                    existingLivre.AnneePublication = updatedLivre.AnneePublication;
                    existingLivre.Categorie = updatedLivre.Categorie;
                    existingLivre.Disponible = updatedLivre.Disponible;
                    existingLivre.Image = updatedLivre.Image;


                    // Enregistrer les modifications dans la base de données
                    _dbContext.SaveChanges();

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
        // pour afficher tous les adherents
        public List<Livre> GetLivres()
        {
            return _dbContext.Livres.ToList(); // pour afficher tous les livres ss forme de liste

        }
        //pour supprimer un livre en se basant de son id
        public void RemoveLivre(Livre livre)
        {
            var LivreToRemove = _dbContext.Livres.FirstOrDefault(l=>l.IdLivre==livre.IdLivre);
            if (LivreToRemove != null)
            {
                _dbContext.Livres.Remove(LivreToRemove);
                _dbContext.SaveChanges();
            }
        }


    }
}
