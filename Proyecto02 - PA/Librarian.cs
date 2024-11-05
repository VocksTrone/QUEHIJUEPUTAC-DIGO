using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02___PA
{
    public class Librarian : Users
    {
        public Librarian(string name, string id, string password) :
            base(name, id, "Bibliotecario", password)
        {
        }
        public override string GetUser()
        {
            return base.GetUser();
        }
        static bool LibrarianGoOut(ref bool librarianMenu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSesión Cerrada");
            Console.ResetColor();
            Console.ReadKey();
            librarianMenu = false;
            return librarianMenu;
        }
        public static void LibrarianMenu(ref bool librarianMenu, ref List<Books> booksList, ref List<Users> usersList, ref List<Librarian> librariansList, ref List<Reader> readersList, ref Stack<Loans> loanHistory)
        {
            while (librarianMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Menú Bibliotecario ---");
                Console.ResetColor();
                Console.WriteLine("\n1. Agregar Libro");
                Console.WriteLine("2. Editar Libro");
                Console.WriteLine("3. Eliminar Libro");
                Console.WriteLine("4. Buscar Libro");
                Console.WriteLine("5. Prestar Libro");
                Console.WriteLine("6. Devolver Libro");
                Console.WriteLine("7. Ordenar Libros");
                Console.WriteLine("8. Mostrar Libros");
                Console.WriteLine("9. Editar Usuario");
                Console.WriteLine("10. Eliminar Usuario");
                Console.WriteLine("11. Ordenar Lectores");
                Console.WriteLine("12. Ordenar Bibliotecarios");
                Console.WriteLine("13. Mostrar Bibliotecarios");
                Console.WriteLine("14. Mostrar Lectores");
                Console.WriteLine("15. Historial de Préstamos");
                Console.WriteLine("16. Cerrar Sesión");
                Console.Write("\nIngrese una Opción: ");
                int librarianOption = int.Parse(Console.ReadLine());
                switch (librarianOption)
                {
                    case 1:
                        Users.AddBook(ref booksList);
                        break;
                    case 2:
                        Users.EditBook(ref booksList);
                        break;
                    case 3:
                        Users.DeleteBook(ref booksList);
                        break;
                    case 4:
                        Users.SearchBook(ref booksList);
                        break;
                    case 5:
                        LoanBook(ref booksList, ref readersList, ref loanHistory);
                        break;
                    case 6:
                        ReturnBook(ref booksList, ref loanHistory);
                        break;
                    case 7:
                        Users.BubbleSortBooks(ref booksList);
                        break;
                    case 8:
                        Users.ShowBooks(ref booksList);
                        break;
                    case 9:
                        Users.EditUser(ref usersList);
                        break;
                    case 10:
                        Users.DeleteUser(ref usersList);
                        break;
                    case 11:
                        InsertionSortReaders(ref readersList);
                        break;
                    case 12:
                        QuickSortLibrarians(ref librariansList, 0, librariansList.Count - 1);
                        break;
                    case 13:
                        ShowLibrarians(ref librariansList);
                        break;
                    case 14:
                        ShowReaders(ref readersList);
                        break;
                    case 15:
                        ShowLoanHistory(ref loanHistory);
                        break;
                    case 16:
                        LibrarianGoOut(ref librarianMenu);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIngrese una Opción Válida (1 - 16)");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void InsertionSortReaders(ref List<Reader> readersList)
        {
            int readersNum = readersList.Count;
            for (int i = 1; i < readersNum; i++)
            {
                Reader position = readersList[i];
                int j = i - 1;
                while (j >= 0 && string.Compare(readersList[j].
                    GetUserID(), position.GetUserID()) > 0)
                {
                    readersList[j + 1] = readersList[j];
                    j = j - 1;
                }
                readersList[j + 1] = position;
            }
        }
        public static void QuickSortLibrarians(ref List<Librarian> librariansList,
            int lowerPosition, int highPosition)
        {
            if (lowerPosition < highPosition)
            {
                int pivot = Partition(ref librariansList, lowerPosition, highPosition);
                QuickSortLibrarians(ref librariansList, lowerPosition, pivot - 1);
                QuickSortLibrarians(ref librariansList, pivot + 1, highPosition);
            }
        }
        protected static int Partition(ref List<Librarian> librariansList, int lowerPosition,
            int highPosition)
        {
            string pivotDatum = librariansList[highPosition].GetUserID();
            int i = lowerPosition - 1;
            for (int j = lowerPosition; j < highPosition; j++)
            {
                if (string.Compare(librariansList[j].
                    GetUserID(), pivotDatum) < 0)
                {
                    i++;
                    var temp = librariansList[i];
                    librariansList[i] = librariansList[j];
                    librariansList[j] = temp;
                }
            }
            var temp1 = librariansList[i + 1];
            librariansList[i + 1] = librariansList[highPosition];
            librariansList[highPosition] = temp1;
            return i + 1;
        }
        public static void ShowLibrarians(ref List<Librarian> librariansList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Lista de Bibliotecarios ---");
            Console.ResetColor();
            Console.WriteLine("");
            foreach (var librarian in librariansList)
            {
                Console.WriteLine(librarian.GetUser());
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
        public static void ShowReaders(ref List<Reader> readersList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--- Lista de Lectores ---");
            Console.ResetColor();
            Console.WriteLine("");
            foreach (var reader in readersList)
            {
                Console.WriteLine(reader.GetUser());
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
        public static void LoanBook(ref List<Books> booksList, ref List<Reader> readersList,
            ref Stack<Loans> loanHistory)
        {
            Console.Write("ISBN del Libro: ");
            string isbn = Console.ReadLine();
            Books book = booksList.Find(x => x.ISBN == isbn && x.Availability);
            if (book != null)
            {
                Console.Write("ID del Lector: ");
                string readerID = Console.ReadLine();
                Reader reader = readersList.Find(x => x.GetUserID() == readerID);
                if (reader != null)
                {
                    Loans newLoan = new Loans(book, reader);
                    loanHistory.Push(newLoan);
                    book.Availability = false;
                    Console.WriteLine($"El Libro '{book.Title}' se Prestó a {reader.GetUserID()}");
                }
                else
                {
                    Console.WriteLine("Lector No Encontrado");
                }
            }
            else
            {
                Console.WriteLine("Libro No Disponible");
            }
            Console.ReadKey();
        }
        public static void ReturnBook(ref List<Books> booksList, ref Stack<Loans> loanHistory)
        {
            Console.Write("ISBN del Libro: ");
            string isbn = Console.ReadLine();
            Stack<Loans> temporalyStack = new Stack<Loans>();
            bool found = false;
            while (loanHistory.Count > 0)
            {
                Loans loan = loanHistory.Pop();
                if (loan.LoanBook.ISBN == isbn)
                {
                    loan.ReturnBook();
                    loan.LoanBook.Availability = true;
                    Console.WriteLine($"Libro '{loan.LoanBook.Title}' Devuelto por {loan.Reader.GetUserID()}");
                    found = true;
                }
                else
                {
                    temporalyStack.Push(loan);
                }
            }
            while (temporalyStack.Count > 0)
            {
                loanHistory.Push(temporalyStack.Pop());
            }
            if (!found)
            {
                Console.WriteLine("No Existen Préstamos para el ISBN");
            }
            Console.ReadKey();
        }
        public static void ShowLoanHistory(ref Stack<Loans> loanHistory)
        {
            Console.Clear();
            Console.Write("ISBN del Libro: ");
            string isbn = Console.ReadLine();
            List<Loans> loanList = new List<Loans>();
            foreach (var loan in loanHistory)
            {
                if (loan.LoanBook.ISBN == isbn)
                {
                    loanList.Add(loan);
                }
            }
            if (loanList.Count > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Historial de Préstamos ---");
                Console.ResetColor();
                foreach (var loan in loanList)
                {
                    Console.WriteLine($"Libro: {loan.LoanBook.Title}, Lector: {loan.Reader.GetUser()}, " +
                                      $"Fecha de Préstamo: {loan.LoanDate.ToShortDateString()}" +
                                      $"{(loan.ReturnDate.HasValue ? $", Fecha de Devolución: {loan.ReturnDate.Value.ToShortDateString()}" : " (No devuelto)")}");
                }
            }
            else
            {
                Console.WriteLine("No Hay Préstamos para el ISBN");
            }
            Console.ReadKey();
        }
    }
}