
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

void Registrarse()
{
    try
    {
        Console.Clear();
        Console.WriteLine("\n--- Registro de Cuenta Nueva ---");

        string nombre = ObtenerEntrada("Nombre completo: ");
        string usuario = "";

        bool usuarioValido = false;
        while (usuarioValido == false)
        {
            usuario = ObtenerEntrada("Nombre de usuario: ");
            bool duplicado = false;

            for (int i = 0; i < totalUsuarios; i++)
            {
                if (usuarios[i].usuario == usuario)
                {
                    duplicado = true;
                    break;
                }
            }

            if (duplicado == true)
            {
                MostrarError("Ese nombre de usuario ya está en uso. Por favor, elige otro.");
            }
            else
            {
                usuarioValido = true;
            }
        }

        string telefono = ObtenerEntrada("Teléfono: ");
        string clave = ObtenerEntrada("Clave: ");

        Usuario nuevoUsuario = new Usuario
        {
            nombre = nombre,
            usuario = usuario,
            telefono = telefono,
            clave = clave,
            petPoints = 0
        };

        if (totalUsuarios < usuarios.Length)
        {
            usuarios[totalUsuarios] = nuevoUsuario;
            totalUsuarios++;
            MostrarExito("¡Registro exitoso! Ahora puedes iniciar sesión.");
            MostrarCarga(4);
        }
        else
        {
            MostrarAdvertencia("No hay espacio para más usuarios.");
            MostrarCarga(4);
        }
    }
    catch (Exception ex)
    {
        MostrarError($"Error al registrarse: {ex.Message}");
    }
}

void registroMascota()
{
    try
    {
        bool otraMascota = false;
        do
        {
            Console.Clear();
            MostrarAdvertencia("--- Registraremos su mascota ---");

            string nombre = ObtenerEntrada("Nombre de su mascota: ");
            string especie = ObtenerEntrada("Especie: ");
            string raza = ObtenerEntrada("Raza: ");
            string color = ObtenerEntrada("Color de pelaje: ");

            Console.WriteLine("\n- Información médica inicial -");
            string sangre = ObtenerEntrada("Tipo de sangre: ");
            string vacunas = ObtenerEntrada("Vacunas colocadas: ");
            string alergias = ObtenerEntrada("Alergias: ");
            string condicion = ObtenerEntrada("Condición especial: ");
            string rasgoCaracteristico = ObtenerEntrada("Algún rasgo físico característico: ");

            Mascota nuevaMascota = new Mascota
            {
                id = totalMascotas + 1,
                duenoUsuario = usuarioActivo,
                nombre = nombre,
                especie = especie,
                raza = raza,
                color = color,
                sangre = sangre,
                alergias = alergias,
                vacunas = vacunas,
                condicion = condicion,
                rasgoCaracteristico = rasgoCaracteristico,
                citasMedicas = "Sin citas registradas aún.",
                extraviada = false
            };

            mascotas[totalMascotas] = nuevaMascota;
            totalMascotas++;

            MostrarCarga(4);
            Console.Clear();
            MostrarExito("Mascota registrada satisfactoriamente.");
            MostrarCarga(2);

            bool opcionValida = false;
            do
            {
                Console.Write("\n¿Desea registrar otra mascota? (si/no): ");
                string respuesta = (Console.ReadLine() ?? "").ToLower();

                if (respuesta == "si")
                {
                    otraMascota = true;
                    opcionValida = true;
                }
                else if (respuesta == "no")
                {
                    otraMascota = false;
                    opcionValida = true;
                }
                else
                {
                    MostrarError("Respuesta inválida.");
                }
            } while (opcionValida == false);

        } while (otraMascota == true);
    }
    catch (Exception ex)
    {
        MostrarError($"Error al registrar mascota: {ex.Message}");
    }
}

void exportarDatosCSV()
{
    try
    {
        MostrarEncabezado("EXPORTACIÓN DE DATOS", "Preparando la base de datos de mascotas para exportación...");
        MostrarCarga(4);

        StreamWriter archivoCSV = new StreamWriter("BaseDeDatos_Mascotas.csv");

        archivoCSV.WriteLine("ID,Dueño,Nombre,Especie,Raza,Color,Sangre,Vacunas,Alergias,Condicion,Citas_Medicas,Estado");

        for (int i = 0; i < totalMascotas; i++)
        {
            string estado = "En Casa";
            if (mascotas[i].extraviada == true)
            {
                estado = "Desaparecida";
            }

            string citasLimpias = mascotas[i].citasMedicas.Replace("\n", " ").Replace(",", ";");
            string vacunasLimpias = mascotas[i].vacunas.Replace(",", ";");
            string alergiasLimpias = mascotas[i].alergias.Replace(",", ";");
            string condicionLimpia = mascotas[i].condicion.Replace(",", ";");
            string rasgoLimpio = mascotas[i].rasgoCaracteristico.Replace(",", ";");

            archivoCSV.WriteLine($"{mascotas[i].id},{mascotas[i].duenoUsuario},{mascotas[i].nombre},{mascotas[i].especie},{mascotas[i].raza},{mascotas[i].color},{mascotas[i].sangre},{vacunasLimpias},{alergiasLimpias},{condicionLimpia},{citasLimpias},{estado}");
        }

        archivoCSV.Close();

        MostrarEncabezado("EXPORTACIÓN DE DATOS", "");
        MostrarExito("¡Datos guardados exitosamente!\n");
        Console.WriteLine("Se ha creado el archivo 'BaseDeDatos_Mascotas.csv' en la carpeta de tu proyecto.");
        Console.WriteLine("Puedes abrirlo directamente con Excel.");

        PausarYContinuar();
    }
    catch (Exception ex)
    {
        MostrarError($"Error al exportar los datos: {ex.Message}");
        PausarYContinuar();
    }
}