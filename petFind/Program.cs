Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int opcion = 0;

void menu()
{
    do
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("   == MENU  ==   \n1. Registrar mascota\n2. Listado de mascotas propias\n3. Reportar mascota desaparecida\n4. Mostrar mascotas desaparecidas\n5. Reportar mascota encontrada\n6. Salir de sesion\n7. Salir del programa");
        Console.Write("\nOpcion escogida: ");
        if (int.TryParse(Console.ReadLine()!, out opcion))
        {
            switch (opcion)
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
                    saliendoDelPrograma();
                    break;
                default:
                    opcionNoDisponible();
                    break;
            }
        }
        else
        {
            caracterInvalido();
        }
    } while (opcion != 7);


}

// opcion 1, registrar a las mascotas
void registrarMascota()
{

}

// opcion 2


void reportarMascotaDesaparecida()
{
    try
    {
        MostrarEncabezado("CAMBIAR ESTADO DE MASCOTA", "Instrucciones: Escribe '/' para regresar al menú principal.");

        bool tienemascotas = false;
        Console.WriteLine("Tus mascotas registradas: ");
        for (int i = 0; i < totalMascotas; i++)
        {
            if (mascotas[i].duenoUsuario == usuarioActivo)
            {
                tienemascotas = true;

                string estado = "En casa";
                if (mascotas[i].extraviada == true)
                {
                    estado = "Desaparecida";
                }

                Console.WriteLine($"ID: {mascotas[i].id}");
                Console.WriteLine($"Nombre: {mascotas[i].nombre}");
                Console.WriteLine($"Especie: {mascotas[i].especie}");
                Console.WriteLine($"--> Estado actual: {estado} <--");
                Console.WriteLine("---------------------------------");
            }
        }
       


// Opcion 4


// Opcion 5


// Opcion 6


// Opcion 7 - Sali del programa
void saliendoDelPrograma()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Saliendo del programa ");
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(350);
        Console.Write(". ");
    }
    Console.ResetColor();
    Console.Clear();
}



// En caso de digitar en las opciones numericas, un numero muy elevado
void opcionNoDisponible()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Opcion invalida. Digite una opcion valida ");
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(350);
        Console.Write(". ");
    }
    Console.ResetColor();
    Console.Clear();

}
// En caso de error por caracter mal digitado
void caracterInvalido()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("El caracter digitado es invalido. Ingrese un caracter valido");
    for (int i = 0; i < 5; i++)
    {
        Thread.Sleep(350);
        Console.Write(". ");
    }
    Console.ResetColor();
    Console.Clear();
}

void main()
{
    menu();
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