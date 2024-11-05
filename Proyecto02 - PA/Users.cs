using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02___PA
{
    public class Users
    {
        public string Name { get; set; }
        protected string ID { get; set; }
        public string Position { get; set; }
        private string Password { get; set; }
        public Users(string name, string id, string position, string password)
        {
            Name = name;
            ID = id;
            Position = position;
            Password = password;
        }
        public virtual string GetUser()
        {
            return $"{Name} ({Position}) \nID: {ID}";
        }
        public string GetUserID()
        {
            return ID;
        }
        public void NewPassword(string password)
        {
            Password = password;
        }
        public bool MatchPassword(string password)
        {
            return Password == password;
        }
        public static void AddBook(ref List<Books> booksList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Agregar Libro ---");
            Console.ResetColor();
            Console.Write("\nTítulo: ");
            string title = Console.ReadLine();
            Console.Write("\nAutor: ");
            string author = Console.ReadLine();
            Console.Write("\nISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("\nGénero Literario: ");
            string literaryGenre = Console.ReadLine();
            var newBook = new Books(title, author, isbn, literaryGenre, true);
            booksList.Add(newBook);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLibro Agregado Exitosamente");
            Console.ResetColor();
            Console.ReadKey();
        }
        public static void EditBook(ref List<Books> booksList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Editar Libro ---");
            Console.ResetColor();
            Console.Write("\nISBN: ");
            string isbn = Console.ReadLine();
            Books book = booksList.Find(x => x.ISBN == isbn);
            if (book != null)
            {
                Console.Write("\nTítulo: ");
                book.Title = Console.ReadLine();
                Console.Write("\nAutor: ");
                book.Author = Console.ReadLine();
                Console.Write("\nGénero Literario: ");
                book.LiteralyGenre = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLibro Editado Exitosamente");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLibro No Encontrado");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
        public static void DeleteBook(ref List<Books> booksList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Eliminar Libro ---");
            Console.ResetColor();
            Console.Write("\nISBN: ");
            string isbn = Console.ReadLine();
            Books book = booksList.Find(x => x.ISBN == isbn);
            if (book != null)
            {
                booksList.Remove(book);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nLibro Eliminado Exitosamente");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLibro No Encontrado");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
        public static void EditUser(ref List<Users> usersList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Editar Usuario ---");
            Console.ResetColor();
            Console.Write("\nIngrese el ID del Usuario: ");
            string userId = Console.ReadLine();
            Users user = usersList.Find(x => x.GetUserID() == userId);
            if (user != null)
            {
                Console.Write($"\nNombre Actual: {user.Name} \nNuevo Nombre: ");
                user.Name = Console.ReadLine();
                Console.Write($"\nContraseña Actual: {user.Password} \nNueva Contraseña: ");
                string newPassword = Console.ReadLine();
                user.NewPassword(newPassword);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUsuario Editado Exitosamente");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUsuario No Encontrado");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
        public static void DeleteUser(ref List<Users> usersList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Eliminar Usuario ---");
            Console.ResetColor();
            Console.Write("\nIngrese el ID del Usuario: ");
            string userId = Console.ReadLine();
            Users user = usersList.Find(x => x.GetUserID() == userId);
            if (user != null)
            {
                usersList.Remove(user);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUsuario Eliminado Exitosamente");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUsuario No Encontrado");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
        public static void BubbleSortBooks(ref List<Books> booksList)
        {
            int n = booksList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (string.Compare(booksList[j].ISBN, 
                        booksList[j + 1].ISBN) > 0)
                    {
                        Books temporalBook = booksList[j];
                        booksList[j] = booksList[j + 1];
                        booksList[j + 1] = temporalBook;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLibros Ordenados Exitosamente - Método 'BubbleSort'");
            Console.ResetColor();
        }
        public static void SearchBook(ref List<Books> booksList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Buscar Libro ---");
            Console.ResetColor();
            Console.Write("\nIngrese el Título, Autor o ISBN: ");
            string searchedBook = Console.ReadLine();
            if (IsSorted(booksList))
            {
                var book = BinarySearch(booksList, searchedBook);
                if (book != null)
                {
                    DisplayBookDetails(book);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nLibro No Encontrado");
                    Console.ResetColor();
                }
            }
            else
            {
                var book = SequentialSearch(booksList, searchedBook);
                if (book != null)
                {
                    DisplayBookDetails(book);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nLibro No Encontrado");
                    Console.ResetColor();
                }
            }
            Console.ReadKey();
        }
        protected static bool IsSorted(List<Books> booksList)
        {
            for (int i = 1; i < booksList.Count; i++)
            {
                if (string.Compare(booksList[i - 1].ISBN, 
                    booksList[i].ISBN) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        protected static Books SequentialSearch(List<Books> booksList, string searchQuery)
        {
            foreach (var book in booksList)
            {
                if (book.Title.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    book.ISBN.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }
        protected static Books BinarySearch(List<Books> booksList, string searchQuery)
        {
            int leftNum = 0;
            int rightNum = booksList.Count - 1;
            while (leftNum <= rightNum)
            {
                int midNum = leftNum + (rightNum - leftNum) / 2;
                if (booksList[midNum].ISBN.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    return booksList[midNum];
                }
                if (string.Compare(booksList[midNum].ISBN, searchQuery) < 0)
                {
                    leftNum = midNum + 1;
                }
                else
                {
                    rightNum = midNum - 1;
                }
            }
            return null;
        }
        protected static void DisplayBookDetails(Books book)
        {
            Console.WriteLine($"\nTítulo: {book.Title}");
            Console.WriteLine($"Autor: {book.Author}");
            Console.WriteLine($"ISBN: {book.ISBN}");
            Console.WriteLine($"Género Literario: {book.LiteralyGenre}");
            Console.WriteLine($"Disponibilidad: {(book.Availability ? "Disponible" : "No Disponible")}");
        }
        public static void ShowBooks(ref List<Books> booksList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Lista de Libros ---");
            Console.ResetColor();
            if (booksList.Count > 0)
            {
                foreach (var book in booksList)
                {
                    Console.WriteLine($"\nTítulo: {book.Title}");
                    Console.WriteLine($"Autor: {book.Author}");
                    Console.WriteLine($"ISBN: {book.ISBN}");
                    Console.WriteLine($"Género Literario: {book.LiteralyGenre}");
                    Console.WriteLine($"Disponibilidad: {(book.Availability 
                        ? "Disponible" : "No Disponible")}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo hay libros disponibles.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
    }
}