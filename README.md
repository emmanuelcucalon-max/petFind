____       __  _______           __
   / __ \___  / /_/ ____(_)___  ____/ /
  / /_/ / _ \/ __/ /_  / / __ \/ __  / 
 / ____/  __/ /_/ __/ / / / / / /_/ /  
/_/    \___/\__/_/   /_/_/ /_/\__,_/   
                                       
      |\__/,|   (`\
    _.|o o  |_   ) )   "Tecnología al servicio de las mascotas"
   -(((---(((--------      

   
🐾 PetFind - Prototipo de Gestión y Rescate Animal

> Uniendo a la comunidad para proteger a nuestros compañeros de cuatro patas. 

---

 ¿Qué es PetFind?

PetFind es una plataforma interactiva de consola desarrollada enteramente en C#. Nace con la misión de ser un sistema integral de gestión de mascotas
que no solo actúa como un expediente médico digital, sino como una red de apoyo comunitario. A través de este sistema, los ciudadanos pueden registrar 
a sus animales, reportar extravíos en tiempo real para alertar a la comunidad, y ganar recompensas por ayudar a devolver a una mascota a su hogar.

---

 Características Principales

| Módulo | Descripción |
| --- | --- |
  Autenticación | Sistema seguro de registro e inicio de sesión con validación de credenciales únicas para cada dueño. |
| Expediente Médico | Registro detallado que incluye tipo de sangre, alergias, condiciones especiales y un historial cronológico de **Citas Veterinarias**. |
| Alerta Comunitaria | Interruptor rápido para reportar una mascota como "Desaparecida" o "En casa", alimentando un tablón público de extravíos. |
| Billetera PetPoints | Economía virtual que premia con puntos (150 por avistamiento, 300 por intercepción) canjeables por consultas veterinarias. |
| Exportación CSV| Persistencia de datos integrada que exporta toda la base de la memoria a un archivo compatible con Microsoft Excel. |
---

 Tecnologías y Estructura Técnica

Este prototipo está diseñado bajo los principios de la programación estructurada y la eficiencia de recursos:

Lenguaje:C# (Aplicación de Consola .NET).
Almacenamiento Temporal:Arreglos unidimensionales estáticos y `structs` personalizados (sin dependencias de bases de datos externas como SQL).
Persistencia: Manejo de archivos planos utilizando la clase `StreamWriter` de la librería nativa para la generación de archivos `.csv`.
Arquitectura:Máquinas de estado para los menús y el principio DRY (*Don't Repeat Yourself*) para la validación continua de entradas y renderizado de la interfaz.

---

 Guía de Instalación y Ejecución

Al ser un programa sin dependencias externas ni configuraciones de red, poner a funcionar PetFind toma menos de dos minutos.

1. Clonar o Copiar el Código: Abre tu entorno de desarrollo favorito (Visual Studio 2022 es altamente recomendado) y crea un nuevo proyecto de tipo **Aplicación de Consola en C#**.
2. Integrar el Núcleo:
Abre el archivo `Program.cs`, elimina cualquier código que venga por defecto y pega la totalidad del código fuente de PetFind.
3. Ejecutar:
Presiona `F5` o el botón de "Iniciar". El compilador abrirá automáticamente la consola interactiva.
4. Generar la Base de Datos:
Una vez dentro, registra usuarios y mascotas de prueba. Al seleccionar la opción **"Exportar Base de Datos a CSV"** en el menú principal, el archivo `BaseDeDatos_Mascotas.csv` se creará mágicamente en la raíz de tu proyecto (dentro de la carpeta `bin/Debug/net...`).

---

 Contribuciones y Futuro

Este código base está preparado para escalar. En las próximas iteraciones del proyecto, se planea integrar la generación automática de códigos QR para la rápida identificación de las mascotas rescatadas directamente desde la plataforma web comunitaria.
