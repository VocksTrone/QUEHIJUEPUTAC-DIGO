using Proyecto02___PA;

List<Users> usersList = new List<Users>(); List<Books> booksList = new List<Books>();
List<Librarian> librariansList = new List<Librarian>(); List<Reader> readersList = new List<Reader>();
List<Loans> loansList = new List<Loans>();
Stack<Loans> loanHistory = new Stack<Loans>();
bool registerUser = false; bool librarianMenu = false; bool readerMenu = false;
bool generalContinue = true;

while (generalContinue)
{
    try
    {
        SwitchStartMenu();
    }
    catch (FormatException)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nERROR!, Datos Inválidos");
        Console.ResetColor();
        Console.ReadKey();
    }
}
int StartMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("--- Sistema de Gestión Bibliotecaria ---");
    Console.ResetColor();
    Console.WriteLine("\n1. Iniciar Sesión");
    Console.WriteLine("2. Registrarse");
    Console.WriteLine("3. Salir");
    Console.Write("\nIngrese una Opción: ");
    int generalOption = int.Parse(Console.ReadLine());
    return generalOption;
}
bool GeneralGoOut()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nGracias por Usar Nuestro Sistema, Vuelva Pronto");
    Console.ResetColor();
    generalContinue = false;
    return generalContinue;
}
void SwitchStartMenu()
{
    switch (StartMenu())
    {
        case 1:
            LogInMenu();
            break;
        case 2:
            SignInMenu(ref registerUser);
            break;
        case 3:
            GeneralGoOut();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nIngrese una Opción Válida (1 - 3)");
            Console.ResetColor();
            Console.ReadKey();
            break;
    }
}
void LogInMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("--- Iniciar Sesión ---");
    Console.ResetColor();
    Console.Write("\nID: ");
    string id = Console.ReadLine();
    Console.Write("\nContraseña: ");
    string password = Console.ReadLine();
    bool loginSuccess = false;
    foreach (var librarian in librariansList)
    {
        if (librarian.GetUserID() == id && librarian.MatchPassword(password))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSesión Iniciada Exitosamente");
            Console.ResetColor();
            Console.ReadKey();
            librarianMenu = true;
            while (librarianMenu)
            {
                try
                {
                    Librarian.LibrarianMenu(ref librarianMenu, ref booksList, ref usersList, ref librariansList, ref readersList, ref loanHistory);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nERROR!, Datos Inválidos");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            loginSuccess = true;
        }
    }
    foreach (var reader in readersList)
    {
        if (reader.GetUserID() == id && reader.MatchPassword(password))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSesión Iniciada Exitosamente");
            Console.ResetColor();
            Console.ReadKey();
            readerMenu = true;
            while (readerMenu)
            {
                try
                {
                    Reader.ReaderMenu(ref readerMenu, ref booksList);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nERROR!, Datos Inválidos");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            loginSuccess = true;
        }
    }
    if (!loginSuccess)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nID o Contraseña Incorrectos, Intente de Nuevo");
        Console.ResetColor();
        Console.ReadKey();
    }
}
void SignInMenu(ref bool registerUser)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("--- Registrarse ---");
    Console.ResetColor();
    Console.Write("\nNombre: ");
    string name = Console.ReadLine();
    string id = "";
    string position = "";
    registerUser = true;
    while (registerUser)
    {
        Console.Write("\nPuesto (Bibliotecario / Lector): ");
        position = Console.ReadLine().ToUpper();
        if (position == "BIBLIOTECARIO")
        {
            Console.Write("\nIntroduzca la Contraseña de Administrador: ");
            string adminID = Console.ReadLine();
            if (adminID == "urlAdmin")
            {
                Console.Write("\nIngrese su ID: ");
                id = "A" + Console.ReadLine();
                registerUser = false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo Posee Permisos para Crear este Usuario");
                Console.ResetColor();
            }
        }
        else if (position == "LECTOR")
        {
            Console.Write("\nIngrese su ID: ");
            id = "B" + Console.ReadLine();
            registerUser = false;
        }
    }
    Console.Write("\nContraseña: ");
    string password = Console.ReadLine();
    if (position == "BIBLIOTECARIO")
    {
        var newLibrarian = new Librarian(name, id, password);
        librariansList.Add(newLibrarian);
        usersList.Add(newLibrarian);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nBibliotecario Registrado Exitosamente");
        Console.WriteLine($"\nID: {id}");
        Console.ResetColor();
    }
    else if (position == "LECTOR")
    {
        var newReader = new Reader(name, id, password);
        readersList.Add(newReader);
        usersList.Add(newReader);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nLector Registrado Exitosamente");
        Console.WriteLine($"\nID: {id}");
        Console.ResetColor();
    }
    Console.ReadKey();
}