using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto02___PA
{
    public class Reader : Users
    {
        public Reader(string name, string id, string password) :
            base(name, id, "Lector", password) 
        {
        }
        static bool ReaderGoOut(ref bool readerMenu)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSesión Cerrada");
            Console.ResetColor();
            Console.ReadKey();
            readerMenu = false;
            return readerMenu;
        }
        public static void ReaderMenu(ref bool readerMenu, ref List<Books> booksList, ref Stack<Loans> loanHistory, ref List<Reader> readersList)
        {
            while (readerMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--- Menú Lector ---");
                Console.ResetColor();
                Console.WriteLine("\n1. Prestar Libros");
                Console.WriteLine("2. Devolver Libros");
                Console.WriteLine("3. Cerrar Sesión");
                Console.Write("\nIngrese una Opción: ");
                int readerOption = int.Parse(Console.ReadLine());
                switch (readerOption)
                {
                    case 1:
                        Librarian.LoanBook(ref booksList, ref readersList, ref loanHistory);
                        break;
                    case 2:
                        Librarian.ReturnBook(ref booksList, ref loanHistory);
                        break;
                    case 3:
                        ReaderGoOut(ref readerMenu);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIngrese una Opción Válida (1 - 3)");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
    }
}