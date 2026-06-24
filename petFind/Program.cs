
void MostrarCarga(int segundos)
{
    try
    {
        for (int i = 0; i < segundos; i++)
        {
            System.Threading.Thread.Sleep(350);
            Console.Write(". ");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al mostrar carga: {ex.Message}");
    }
}

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

void MostrarAdvertencia(string mensaje)
{
    try
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(mensaje);
        Console.ResetColor();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Advertencia: {mensaje} - {ex.Message}");
    }
}

void registroMascota()
{
    Console.Clear();
    MostrarAdvertencia("--- Registrar Nueva Mascota ---");

    Console.Write("Nombre de la mascota: ");
    string nombre = Console.ReadLine();

    Console.Write("Especie (Perro/Gato/etc): ");
    string especie = Console.ReadLine();

    Console.Write("Raza: ");
    string raza = Console.ReadLine();

    Console.Write("Color de pelaje: ");
    string color = Console.ReadLine();

    Mascota nuevaMascota = new Mascota
    {
        id = totalMascotas + 1,
        duenoUsuario = usuarioActivo,
        nombre = nombre,
        especie = especie,
        raza = raza,
        color = color,
        sangre = "No especificado",
        alergias = "Ninguna",
        vacunas = "Ninguna",
        condicion = "Ninguna",
        rasgoCaracteristico = "Ninguno",
        citasMedicas = "Sin citas registradas aún.",
        extraviada = false
    };

    mascotas[totalMascotas] = nuevaMascota;
    totalMascotas++;
    MostrarExito("Mascota guardada en el sistema.");
}