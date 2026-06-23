// Petfind - Prototipo // Inicio de sesion 
// Petfind - Prototipo // Inicio de sesion 
Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int totalMascotas = 0;
int totalUsuarios = 0;
bool sesionIniciada = false;
string usuarioActivo = "";
int menu = 0;
int mascotasExtraviadas = 0;

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