
Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int menu = 0;

void menuPrincipal()
{
    do
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("   == MENU  ==   \n1. Registrar mascota\n2. Listado de mascotas propias\n3. Reportar mascota desaparecida\n4. Mostrar mascotas desaparecidas\n5. Reportar mascota encontrada\n6. Salir de sesion\n7. Salir del programa");
        Console.Write("\nOpcion escogida: ");
        if (int.TryParse(Console.ReadLine()!, out menu))
        {
            switch (menu)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    salirPrograma();
                    break;
                default:
                    MostrarError("Ha ingresado una opcion invalida. Inrese un numero del 1 al 7");
                    break;
            }
        }
        else
        {
            MostrarError("Ha ingresado un caracter invalido.");
        }
    } while (menu!= 7);


}

// opcion 1, registrar a las mascotas
void registrarMascota()
{

}

// opcion 2


// Opcion 3


// Opcion 4


// Opcion 5


// Opcion 6


// Opcion 7 - Sali del programa

void MostrarCarga(int segundos)
{
    try
    {
        for (int i = 0; i < segundos; i++)
        {
            Thread.Sleep(350);
            Console.Write(". ");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al mostrar carga: {ex.Message}");
    }
}

void salirPrograma()
{
    try
    {
        MostrarEncabezado("CERRANDO SESIÓN", "");
        Console.WriteLine("Cerrando sesión actual en Petfind.");
        Console.WriteLine("¡Vuelve pronto!");

        MostrarCarga(3);
        Console.WriteLine();
        sesionIniciada = false;
        usuarioActivo = "";
        menu = 7;
        Console.Clear();
    }
    catch (Exception ex)
    {
        MostrarError($"Error al salir: {ex.Message}");
    }
}

void MostrarExito(string mensaje)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Éxito: {mensaje} - {ex.Message}");
    }
}
void MostrarEncabezado(string titulo, string instrucciones)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"========== {titulo} ==========");
    Console.ResetColor();

    if (instrucciones != "")
    {
        Console.WriteLine(instrucciones + "\n");
    }
}
string ObtenerEntrada(string prompt)
{
    try
    {
        while (true)
        {
            Console.Write(prompt);
            string entrada = Console.ReadLine() ?? "";

            if (entrada != "")
            {
                return entrada;
            }
            else
            {
                MostrarError("Entrada vacía. Por favor, intenta de nuevo.");
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al obtener entrada: {ex.Message}");
        return "";
    }
}



// En caso de digitar en las opciones numericas, un numero muy elevado
void MostrarError(string mensaje)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {mensaje} - {ex.Message}");
    }
}

void main()
{
    menuPrincipal();
}
main();
struct Usuario
{
    public string nombre;
    public string usuario;
    public string telefono;
    public string clave;
    public int petPoints;
}

struct Mascota
{
    public int id;
    public string duenoUsuario;
    public string nombre;
    public string especie;
    public string raza;
    public string color;
    public string sangre;
    public string alergias;
    public string vacunas;
    public string condicion;
    public string rasgoCaracteristico;
    public bool extraviada;
}