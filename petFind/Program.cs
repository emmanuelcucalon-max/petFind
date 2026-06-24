Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int totalMascotas = 0;
int totalUsuarios = 0;
bool sesionIniciada = false;
string usuarioActivo = "";

void Registrarse()
{
    Console.WriteLine("--- Registro de Cuenta ---");
    Console.Write("Nombre completo: ");
    string nombre = Console.ReadLine();

    Console.Write("Nombre de usuario: ");
    string usuario = Console.ReadLine();

    Console.Write("Teléfono: ");
    string telefono = Console.ReadLine();

    Console.Write("Clave: ");
    string clave = Console.ReadLine();

    Usuario nuevoUsuario = new Usuario
    {
        nombre = nombre,
        usuario = usuario,
        telefono = telefono,
        clave = clave,
        petPoints = 0
    };

    usuarios[totalUsuarios] = nuevoUsuario;
    totalUsuarios++;
    Console.WriteLine("Registro exitoso.");
}

void IniciarSesion()
{
    Console.WriteLine("--- Iniciar Sesión ---");
    Console.Write("Usuario: ");
    string usuario = Console.ReadLine();

    Console.Write("Clave: ");
    string clave = Console.ReadLine();

    bool usuarioExiste = false;

    for (int i = 0; i < totalUsuarios; i++)
    {
        if (usuarios[i].usuario == usuario)
        {
            usuarioExiste = true;
            if (usuarios[i].clave == clave)
            {
                Console.WriteLine("Bienvenido al sistema.");
                sesionIniciada = true;
                usuarioActivo = usuario;
            }
            else
            {
                Console.WriteLine("Clave incorrecta.");
            }
            break;
        }
    }

    if (usuarioExiste == false)
    {
        Console.WriteLine("El usuario no existe.");
    }
}

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
    public string citasMedicas;
    public bool extraviada;
}