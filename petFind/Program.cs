Usuario[] usuarios = new Usuario[100];
Mascota[] mascotas = new Mascota[100];
int totalMascotas = 0;
int totalUsuarios = 0;
bool sesionIniciada = false;
string usuarioActivo = "";
int menu = 0;
int mascotasExtraviadas = 0;

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
void historialMedico()
{
    try
    {
        MostrarEncabezado("EXPEDIENTE MÉDICO Y CITAS", "Instrucciones: Escribe '/' para regresar al menú principal.");

        bool tienemascotas = false;
        Console.WriteLine("Tus mascotas registradas: ");
        for (int i = 0; i < totalMascotas; i++)
        {
            if (mascotas[i].duenoUsuario == usuarioActivo)
            {
                tienemascotas = true;
                Console.WriteLine($"ID: {mascotas[i].id} | Nombre: {mascotas[i].nombre} | Especie: {mascotas[i].especie}");
            }
        }

        if (tienemascotas == false)
        {
            MostrarAdvertencia("\nNo tienes mascotas registradas para ver su historial.");
            PausarYContinuar();
            return;
        }

        Console.WriteLine("\nIngrese el ID de la mascota que desea consultar, o '/' para volver");
        string entrada = Console.ReadLine() ?? "";

        if (entrada == "/") return;

        if (int.TryParse(entrada, out int idMascota))
        {
            bool mascotaEncontrada = false;

            for (int i = 0; i < totalMascotas; i++)
            {
                if (mascotas[i].id == idMascota && mascotas[i].duenoUsuario == usuarioActivo)
                {
                    mascotaEncontrada = true;

                    int opcionActualizar = 0;
                    while (opcionActualizar != 5)
                    {
                        MostrarEncabezado($"HISTORIAL DE {mascotas[i].nombre.ToUpper()}", "");

                        Console.WriteLine($"Tipo de Sangre: {mascotas[i].sangre}");
                        Console.WriteLine($"Vacunas: {mascotas[i].vacunas}");
                        Console.WriteLine($"Alergias: {mascotas[i].alergias}");
                        Console.WriteLine($"Condiciones Especiales: {mascotas[i].condicion}");

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n--- REGISTRO DE CITAS VETERINARIAS ---");
                        Console.ResetColor();
                        Console.WriteLine(mascotas[i].citasMedicas);
                        Console.WriteLine("--------------------------------------------------");

                        Console.WriteLine("\n¿Qué dato médico desea agregar o actualizar?");
                        Console.WriteLine("1. Agregar nueva vacuna");
                        Console.WriteLine("2. Agregar nueva alergia");
                        Console.WriteLine("3. Agregar nueva condición médica");
                        Console.WriteLine("4. Agregar CITA VETERINARIA");
                        Console.WriteLine("5. Volver al menú principal");
                        Console.Write("Seleccione una opción (1-5): ");

                        string entradaSub = Console.ReadLine() ?? "";
                        if (int.TryParse(entradaSub, out opcionActualizar))
                        {
                            if (opcionActualizar == 1)
                            {
                                string nuevaVacuna = ObtenerEntrada("Ingrese el nombre de la nueva vacuna: ");
                                if (nuevaVacuna != "/" && nuevaVacuna != "<")
                                {
                                    mascotas[i].vacunas += " | " + nuevaVacuna;
                                    MostrarExito("Historial de vacunas actualizado.");
                                    MostrarCarga(3);
                                }
                            }
                            else if (opcionActualizar == 2)
                            {
                                string nuevaAlergia = ObtenerEntrada("Ingrese la nueva alergia detectada: ");
                                if (nuevaAlergia != "/" && nuevaAlergia != "<")
                                {
                                    mascotas[i].alergias += " | " + nuevaAlergia;
                                    MostrarExito("Historial de alergias actualizado.");
                                    MostrarCarga(3);
                                }
                            }
                            else if (opcionActualizar == 3)
                            {
                                string nuevaCondicion = ObtenerEntrada("Ingrese la nueva condición médica: ");
                                if (nuevaCondicion != "/" && nuevaCondicion != "<")
                                {
                                    mascotas[i].condicion += " | " + nuevaCondicion;
                                    MostrarExito("Historial de condiciones actualizado.");
                                    MostrarCarga(3);
                                }
                            }
                            else if (opcionActualizar == 4)
                            {
                                Console.WriteLine("\n-- Nueva Cita Veterinaria --");
                                string fecha = ObtenerEntrada("Fecha de la cita (ej. 25/10/2026): ");
                                if (fecha != "/" && fecha != "<")
                                {
                                    string observacion = ObtenerEntrada("Observaciones del veterinario: ");
                                    if (observacion != "/" && observacion != "<")
                                    {
                                        if (mascotas[i].citasMedicas == "Sin citas registradas aún.")
                                        {
                                            mascotas[i].citasMedicas = "";
                                        }

                                        mascotas[i].citasMedicas += $"\n> [{fecha}] Observaciones: {observacion}";
                                        MostrarExito("Cita veterinaria agregada al expediente exitosamente.");
                                        MostrarCarga(3);
                                    }
                                }
                            }
                            else if (opcionActualizar != 5)
                            {
                                MostrarError("Opción no válida.");
                                MostrarCarga(3);
                            }
                        }
                    }
                    break;
                }
            }

            if (mascotaEncontrada == false)
            {
                MostrarError("\nID de mascota no encontrado o no te pertenece. Intenta de nuevo.");
                PausarYContinuar();
            }
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error en el historial médico: {ex.Message}");
    }
}

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