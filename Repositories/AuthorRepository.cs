using BookApp.Models;
using BookApp.Services;
using BookApp.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookApp.Repositories
{
    public class AuthorRepository
    {
        private DataContext db;
        
        public AuthorRepository()
        {
            db = new DataContext();
        }

        public List<BookAuthorViewModel> GetAllAuthors()
        {
            var authors = (from a in db.Authors
                           select new BookAuthorViewModel(){
                               Id = a.Id,
                               Name = a.Name,
                               Type = "Authors",
                               Image = a.Image
                           }).ToList();
            return authors;
        }

        public List<AuthorViewModel> getAllAuthorsByName(string name)
        {
            var authors = (from a in db.Authors
                           where a.Name.ToLower().Contains(name.ToLower())
                           select new AuthorViewModel(){
                               Id = a.Id,
                               Name = a.Name
                           }).ToList();
            return authors;
        }

        public List<AuthorViewModel> getAllAuthors()
        {
            var authors = (from a in db.Authors
                           select new AuthorViewModel(){
                               Id = a.Id,
                               Name = a.Name
                           }).ToList();
            return authors;
        }

        public Author getAuthorFromId(int id)
        {
            var author = (from a in db.Authors
                           where a.Id == id
                           select a).FirstOrDefault();
            return author;
        }

        public void AddAuthor(Author author)
        {
            db.Add(author);
            db.SaveChanges();
        }

        public void RemoveAuthor(int id)
        {
            var authorToRemove = (from a in db.Authors
                                  where a.Id == id
                                  select a).FirstOrDefault();
            db.Remove(authorToRemove);
            db.SaveChanges();
        }
    }
}