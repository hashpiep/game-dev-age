using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class BookManager : MonoBehaviour
{
    private List<Book> books = new List<Book>();
    private static BookManager instance;
    public static BookManager Instance { get { return instance; } }
    private void Start()
    {
        instance = this;
    }
    public void CreateBook(string name, float price, string authorID, string skillKey)
    {
        Book book = new Book($"{Guid.NewGuid().ToString()}_book", name, price, authorID, skillKey);

        books.Add(book);
    }
    public List<Book> GetBooks()
    {
        return books;
    }
    public List<Book> GetBooksFromAuthorID(string authorID)
    {
        return books.Where(book => book.AuthorID == authorID).ToList();
    }
    public List<Book> GetBooksNotFromAuthorID(string authorID)
    {
        return books.Where(book => book.AuthorID != authorID).ToList();
    }
    public Book GetBookFromID(string id)
    {
        return books.Where(book => book.ID == id).FirstOrDefault();
    }
    public List<Book> GetBooksFromIDs(List<string> ids)
    {
        List<Book> books = new List<Book>();

        foreach (var id in ids)
        {
            books.Add(GetBookFromID(id));
        }

        return books;
    }
}