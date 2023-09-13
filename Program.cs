using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace colegio
{
    class Estudiante
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<string> Quices { get; set; } = new List<string>();
        public List<string> Trabajos { get; set; } = new List<string>();
        public List<string> Parciales { get; set; } = new List<string>();
    }

    class Program
    {
        static List<Estudiante> estudiantes = new List<Estudiante>();
        static string dataFilePath = "estudiantes.json"; // Nombre del archivo JSON

        // Función para guardar los datos en formato JSON
        public static void GuardarDatosEnJSON()
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(estudiantes);
                File.WriteAllText(dataFilePath, jsonData);
                Console.WriteLine("Datos guardados en formato JSON.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar datos en formato JSON: {ex.Message}");
            }
        }

        // Función para cargar los datos desde un archivo JSON
public static List<Estudiante> CargarDatosDesdeJSON()
{
    List<Estudiante> estudiantes = new List<Estudiante>();
    try
    {
        if (File.Exists(dataFilePath))
        {
            string jsonData = File.ReadAllText(dataFilePath);
            estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(jsonData);
            Console.WriteLine("Datos cargados desde el archivo JSON.");
        }
        else
        {
            Console.WriteLine("No se encontró el archivo JSON. No se cargaron datos.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al cargar datos desde JSON: {ex.Message}");
    }
    return estudiantes;
}


        // Función para agregar un nuevo estudiante
        public static void AgregarEstudiante()
        {
            try
            {
                Estudiante student = new Estudiante();
                Random random = new Random();

                student.Code = random.Next(1000, 9999).ToString();
                Console.Clear();
                Console.Write("Ingresar nombre del estudiante:");
                student.Name = Console.ReadLine() ?? "0";
                if (string.IsNullOrEmpty(student.Name))
                {
                    throw new ArgumentException("El nombre del estudiante no puede estar vacío.");
                }
                Console.Clear();
                estudiantes.Add(student);
                Console.WriteLine("Estudiante ingresado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ingresar estudiante: {ex.Message}");
            }
        }

        // Función para mostrar todos los estudiantes
        public static void MostrarEstudiantes(List<Estudiante> estudi)
        {
            Console.WriteLine("Lista de estudiantes:");
            foreach (Estudiante student in estudi)
            {
                Console.WriteLine($"CODIGO: {student.Code} - NOMBRE: {student.Name}");
            }
        }

        // Función para buscar un estudiante por código
        public static Estudiante BuscarEstudiantePorCodigo(string codigo)
        {
            return estudiantes.Find(student => student.Code == codigo);
        }

        // Función para eliminar un estudiante por código
        public static void EliminarEstudiantePorCodigo(string codigo)
        {
            Estudiante studentToRemove = BuscarEstudiantePorCodigo(codigo);
            if (studentToRemove != null)
            {
                estudiantes.Remove(studentToRemove);
                Console.WriteLine($"Estudiante con código {codigo} eliminado con éxito.");
            }
            else
            {
                Console.WriteLine($"No existe un estudiante con el código {codigo}");
            }
        }

        // Función para modificar el nombre de un estudiante por código
        public static void ModificarEstudiante(string codigo,int opcion)
        {
            Estudiante studentToModify = BuscarEstudiantePorCodigo(codigo);
            if (studentToModify != null)
            {
                switch (opcion){
                    case 1:
                if (studentToModify.Quices.Count == 0)
                {
                    // Verificar si no se han ingresado notas de quices
                    Console.WriteLine($"No se han ingresado notas de quices para el estudiante {studentToModify.Name}");
                    Console.WriteLine("Presione enter para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("¿Desea ingresar una nueva nota (s(si)/n(no))?");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.KeyChar == 's')
                    {
                        Console.Write("Ingresa la cantidad de quices que deseas actualizar: ");
                        int can = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < can; i++)
                        {
                            Console.Write($"Ingresar nota del quiz {i + 1}: ");
                            string note = Console.ReadLine() ?? "0";
                            studentToModify.Quices.Add(note);
                        }
                    }
                }
                else
                {
                    int con = 1;
                    foreach (string g in studentToModify.Quices)
                    {
                        // Mostrar las notas de quices y permitir la edición
                        Console.WriteLine($"{con}. {g}");
                        Console.Write("Ingresa el índice de la nota a editar: ");
                        int inx = Convert.ToInt32(Console.ReadLine());
                        if (inx >= 0 && inx < studentToModify.Quices.Count)
                        {
                            Console.Write("Ingresa nueva nota: ");
                            string newnote = Console.ReadLine() ?? "0";
                            studentToModify.Quices[inx] = newnote;
                        }
                        else
                        {
                            Console.WriteLine("Índice no válido.");
                        }
                        con++;
                    }
                }
                break;
                    case 2:
                    if(estudiantes.Count==0){
                        Console.Write($"No se han ingresado notas de trabajos para el estudiante {studentToModify.Name}");
                        Console.Clear();
                        Console.Write($"Presione enter para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Desea ingresar una nueva nota (s(si)/n(no))");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if(keyInfo.KeyChar=='s'){
                            Console.Write("Ingresa la cantidad de quices que desea actualizar.");
                            int can=Convert.ToInt16(Console.ReadLine());
                            for(int i=0;i<=can;i++){
                                Console.Write($"Ingresar nota del Trabajo {i}");
                                string note=Console.ReadLine() ?? "0";
                                studentToModify.Trabajos.Add(note);

                            }
                        }
                        else if (keyInfo.KeyChar=='n'){
                            break;
                        }
                    }
                    else{
                            int con=1;
                        foreach(string g in studentToModify.Quices){
                            Console.WriteLine($"{con}.{g}");
                            Console.Write("ingresar el indice de la nota a editar:");
                            int inx=Convert.ToInt16(Console.ReadLine());
                            Console.Write("Ingresar nueva nota:");
                            string newnote=Console.ReadLine()?? "0";
                            studentToModify.Trabajos[inx]=newnote;

                        }

                    }

                    break;
                    case 3:
                    if(estudiantes.Count==0){
                        Console.Write($"No se han ingresado notas de parciales para el estudiante {studentToModify.Name}");
                        Console.Clear();
                        Console.Write($"Presione enter para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        Console.WriteLine("Desea ingresar una nueva nota (s(si)/n(no))");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if(keyInfo.KeyChar=='s'){
                            Console.Write("Ingresa la cantidad de quices que desea actualizar.");
                            int can=Convert.ToInt16(Console.ReadLine());
                            for(int i=0;i<=can;i++){
                                Console.Write($"Ingresar nota del Trabajo {i}");
                                string note=Console.ReadLine() ?? "0";
                                studentToModify.Trabajos.Add(note);

                            }
                        }
                        else if (keyInfo.KeyChar=='n'){
                            break;
                        }
                    }
                    else{
                            int con=1;
                        foreach(string g in studentToModify.Quices){
                            Console.WriteLine($"{con}.{g}");
                            Console.Write("ingresar el indice de la nota a editar:");
                            int inx=Convert.ToInt16(Console.ReadLine());
                            Console.Write("Ingresar nueva nota:");
                            string newnote=Console.ReadLine()?? "0";
                            studentToModify.Trabajos[inx]=newnote;

                        }

                    }

                    break;
                }
            }
            else
            {
                Console.WriteLine($"No existe un estudiante con el código {codigo}");
            }
        }

        static void Main(string[] args)
        {
            estudiantes=CargarDatosDesdeJSON(); // Cargar datos al iniciar la aplicación

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" _____________________________");
                Console.WriteLine("|  UNIVERSIDAD SANTO TOMAS    |");
                Console.WriteLine(" _____________________________");

                Console.ResetColor();
                Console.WriteLine("1. Ingresar estudiante.");
                Console.WriteLine("2. Mostrar estudiantes.");
                Console.WriteLine("3. Eliminar estudiante.");
                Console.WriteLine("4. Modificar nombre de estudiante.");
                Console.WriteLine("0. Salir");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("La entrada no puede estar vacía.");
                    continue;
                }

                int op;
                if (!int.TryParse(input, out op))
                {
                    Console.WriteLine("La entrada debe ser un número.");
                    continue;
                }

                Console.Clear();

                if (op == 1)
                {
                    AgregarEstudiante();
                    GuardarDatosEnJSON();
            
                }
                else if (op == 2)
                {
                    MostrarEstudiantes(estudiantes);
                    Console.ReadKey();
                }
                else if (op == 3)
                {
                    Console.Write("Ingrese el código del estudiante a eliminar: ");
                    string codigoEliminar = Console.ReadLine();
                    EliminarEstudiantePorCodigo(codigoEliminar);
                    GuardarDatosEnJSON();
                }
                else if (op == 4)
                {
 try
    {
        Console.Clear();
        Console.WriteLine(" _____________________________");
        Console.WriteLine("|  EDITAR ESTUDIANTE          |");
        Console.WriteLine(" _____________________________");
        Console.WriteLine("1. Editar Nombre del Estudiante.");
        Console.WriteLine("2. Editar Código del Estudiante.");
        Console.WriteLine("3. Editar Notas del Estudiante.");
        Console.WriteLine("0. Volver al Menú Principal.");
        Console.Write("Ingrese la opción: ");

        string inpu = Console.ReadLine();

        if (string.IsNullOrEmpty(inpu))
        {
            Console.WriteLine("La entrada no puede estar vacía.");
            return;
        }

        int opcion;
        if (!int.TryParse(inpu, out opcion))
        {
            Console.WriteLine("La entrada debe ser un número.");
            return;
        }

        else{

        Console.Write("Codigo del estudiante:");
        string cod=Console.ReadLine() ?? "0";
{
    try
    {
        Console.Clear();
        Console.WriteLine(" _____________________________");
        Console.WriteLine("|  EDITAR NOTAS DEL ESTUDIANTE|");
        Console.WriteLine(" _____________________________");
        Console.WriteLine("1. Editar Notas de Quices.");
        Console.WriteLine("2. Editar Notas de Trabajos.");
        Console.WriteLine("3. Editar Notas de Parciales.");
        Console.WriteLine("0. Volver al Menú Principal.");
        Console.Write("Ingrese la opción: ");

        string inp = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("La entrada no puede estar vacía.");
            return;
        }

        int opci;
        if (!int.TryParse(input, out opci))
        {
            Console.WriteLine("La entrada debe ser un número.");
            return;
        }

        switch (opci)
        {
            case 1:
                ModificarEstudiante(cod,opci);
                break;
            case 2:
                 ModificarEstudiante(cod,opci);
                break;
            case 3:
                ModificarEstudiante(cod,opci);
                break;
            case 0:
                // Volver al menú principal.
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error en el menú de edición de notas: {ex.Message}");
    }
}

    }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error en el menú de edición: {ex.Message}");
    }
                    GuardarDatosEnJSON();
                                        
                }
                else if (op == 0)
                {
                    // Guardar datos antes de salir de la aplicación
                    GuardarDatosEnJSON();
                    break;
                }
            }
        }
    }
}

