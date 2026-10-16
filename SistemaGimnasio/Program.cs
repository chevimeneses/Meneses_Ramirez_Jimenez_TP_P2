using SistemaGimnasio.Modelos;
using SistemaGimnasio.Servicios;

Console.WriteLine("Sistema de Gestión de Gimnasios");

// 1. Registrar usuario
Console.WriteLine("\n--- REGISTRO DEL USUARIO ---");

Console.Write("Nombre del usuario: ");
string nombreUsuario = Console.ReadLine() ?? "";

Console.Write("Edad del usuario: ");
int edadUsuario = int.Parse(Console.ReadLine()!);

Console.Write("Objetivo del usuario: ");
string objetivoUsuario = Console.ReadLine() ?? "";

Usuario usuario = new Usuario(nombreUsuario, edadUsuario, objetivoUsuario);

// 2. Registrar ejercicios y crear rutina personalizada
Console.WriteLine("\n--- CREACIÓN DE LA RUTINA ---");

Console.Write("Nombre de la rutina: ");
string nombreRutina = Console.ReadLine() ?? "";

Console.Write("Duración de la rutina (en minutos): ");
int duracionRutina = int.Parse(Console.ReadLine()!);

Rutina rutina = new Rutina(nombreRutina, duracionRutina);

for (int i = 1; i <= 3; i++)
{
    Console.WriteLine($"\n--- EJERCICIO {i} DE 3 ---");

    Console.Write("Nombre del ejercicio: ");
    string nombreEjercicio = Console.ReadLine() ?? "";

    Console.Write("Número de repeticiones: ");
    int repeticiones = int.Parse(Console.ReadLine()!);

    Console.Write("Número de series: ");
    int series = int.Parse(Console.ReadLine()!);

    Console.Write("Descanso entre series (en segundos): ");
    int descanso = int.Parse(Console.ReadLine()!);

    Ejercicio ejercicio = new Ejercicio(
        nombreEjercicio,
        repeticiones,
        series,
        descanso
    );

    rutina.AgregarEjercicio(ejercicio);
}

// 3. Asignar rutina al usuario
AsignadorRutinas asignador = new AsignadorRutinas();

asignador.AsignarRutinaAUsuario(usuario, rutina);

Console.WriteLine("\nRutina asignada correctamente.");

// 4. Registrar entrenador
Console.WriteLine("\n--- REGISTRO DEL ENTRENADOR ---");

Console.Write("Nombre del entrenador: ");
string nombreEntrenador = Console.ReadLine() ?? "";

Console.Write("Especialidad del entrenador: ");
string especialidadEntrenador = Console.ReadLine() ?? "";

Entrenador entrenador = new Entrenador(
    nombreEntrenador,
    especialidadEntrenador
);

// 5. Asignar usuario al entrenador
asignador.AsignarUsuarioAEntrenador(usuario, entrenador);

Console.WriteLine("Usuario asignado al entrenador correctamente.");

// 6. Mostrar resumen para verificación
Console.WriteLine("\n====================================");
Console.WriteLine("       RESUMEN DEL REGISTRO");
Console.WriteLine("====================================");

Console.WriteLine("\n--- DATOS DEL USUARIO ---");
Console.WriteLine($"Nombre: {usuario.Nombre}");
Console.WriteLine($"Edad: {usuario.Edad}");
Console.WriteLine($"Objetivo: {usuario.Objetivo}");

Console.WriteLine("\n--- RUTINA ASIGNADA ---");
Console.WriteLine($"Nombre: {usuario.RutinaAsignada!.Nombre}");
Console.WriteLine($"Duración: {usuario.RutinaAsignada.Duracion} minutos");

Console.WriteLine("\nEjercicios:");

int numero = 1;

foreach (Ejercicio ejercicio in usuario.RutinaAsignada.ObtenerEjercicios())
{
    Console.WriteLine($"\nEjercicio {numero}: {ejercicio.Nombre}");
    Console.WriteLine($"Repeticiones: {ejercicio.Repeticiones}");
    Console.WriteLine($"Series: {ejercicio.Series}");
    Console.WriteLine($"Descanso: {ejercicio.Descanso} segundos");

    numero++;
}

Console.WriteLine("\n--- DATOS DEL ENTRENADOR ---");
Console.WriteLine($"Nombre: {entrenador.Nombre}");
Console.WriteLine($"Especialidad: {entrenador.Especialidad}");

Console.WriteLine("\nUsuarios asignados al entrenador:");

foreach (Usuario u in entrenador.ObtenerUsuariosAsignados())
{
    Console.WriteLine($"- {u.Nombre}");
}

Console.WriteLine("\n====================================");
Console.WriteLine("  REGISTRO COMPLETADO CORRECTAMENTE");
Console.WriteLine("====================================");

Console.WriteLine("\nPresiona una tecla para salir...");
Console.ReadKey();