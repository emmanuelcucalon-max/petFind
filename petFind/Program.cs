
Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int menu = 0;

void menuPrincipal()
{
    try
    {
        do
        {
            Console.WriteLine(" --  Menu Principal  -- ");
            Console.WriteLine("1. Registrar mascota");
            Console.WriteLine("2. Historial Médico y Citas Veterinarias");
            Console.WriteLine("3. Reportar mascota desaparecida / encontrada");
            Console.WriteLine("4. Reportes de desaparecidos (Público)");
            Console.WriteLine("5. Cartera de PetPoints");
            Console.WriteLine("6. Exportar Base de Datos a CSV");
            Console.WriteLine("7. Cerrar Sesión");
            Console.Write("\nIngrese la opcion a realizar: ");

            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out menu))
            {
                // Opción válida
            }
            else
            {
                MostrarError("Ha ingresado una opcion invalida. Ingrese un numero del 1 al 7");
                MostrarCarga(4);
                Console.Clear();
                continue;
            }

            switch (menu)
            {
                case 1:
                    registroMascota();
                    break;
                case 2:
                    historialMedico();
                    break;
                case 3:
                    reportarMascotaDesaparecida();
                    break;
                case 4:
                    mascotasDesaparecidas();
                    break;
                case 5:
                    billeteraPetPoints();
                    break;
                case 6:
                    exportarDatosCSV();
                    break;
                case 7:
                    salirPrograma();
                    break;
                default:
                    Console.Clear();
                    MostrarError("Ha ingresado una opcion invalida. Por favor, ingrese un numero del 1 al 7.");
                    MostrarCarga(4);
                    Console.Clear();
                    break;
            }

        } while (menu != 7);
    }
    catch (Exception ex)
    {
        MostrarError($"Error en el menú principal: {ex.Message}");
    }
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