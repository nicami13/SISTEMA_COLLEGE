// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Threading;

namespace colegio
{

    class Program
    {
        static List<Estudiante> estudiantes = new List<Estudiante>();

        public static void IngresarEstudiante()
        {
            Estudiante student = new Estudiante();
            Random random = new Random();

            student.Code = random.Next(1000, 9999).ToString();
            Console.Clear();
            Console.Write("Ingresar nombre del estudiante:");
            student.Name = (Console.ReadLine() ?? "0");
            Console.Clear();



            for (int i = 0; i < student.Quices.Length; i++)
            {
                Console.Write($"Ingresar la nota del quiz número {i + 1}:");
                student.Quices[i] = (Console.ReadLine() ?? "0");
                Console.Clear();
            }

            for (int i = 0; i < student.Trabajos.Length; i++)
            {
                Console.Write($"Ingresar la nota del trabajo número {i + 1}:");
                student.Trabajos[i] = (Console.ReadLine() ?? "0");
                Console.Clear();
            }

            for (int i = 0; i < student.Parciales.Length; i++)
            {
                Console.Write($"Ingresar la nota del parcial número {i + 1}:");
                student.Parciales[i] = (Console.ReadLine() ?? "0");
                Console.Clear();
            }

            Console.WriteLine("Presione enter para continuar...");
            Console.ReadKey();
            Console.Clear();

            estudiantes.Add(student);
        }

        public static void CalcNotas()
        {
            foreach (Estudiante n in estudiantes)
            {
                string nombre = n.Name;
                string codigo = n.Code;
                int notaQuices = 0;
                int notaTrabajos = 0;
                int notaParciales = 0;

                foreach (string s in n.Quices)
                {
                    notaQuices += Convert.ToInt32(s);
                }
                foreach (string s in n.Trabajos)
                {
                    notaTrabajos += Convert.ToInt32(s);
                }
                foreach (string s in n.Parciales)
                {
                    notaParciales += Convert.ToInt32(s);
                }

                int PorcNquices = (notaQuices * 15) / 100;
                int PorcNtrabajos = (notaTrabajos * 15) / 100;
                int PorcNparciales = (notaParciales * 70) / 100;
                int NotaFinal = PorcNparciales + PorcNquices + PorcNtrabajos;

                Console.WriteLine($"NOMBRE:{nombre}");
                Console.WriteLine($"CODIGO:{codigo}");
                Console.WriteLine($"NOTA FINAL QUICES:{notaQuices}");
                Console.WriteLine($"NOTA FINAL TRABAJOS:{notaTrabajos}");
                Console.WriteLine($"NOTA FINAL PARCIALES:{notaParciales}");
                Console.WriteLine($"NOTA DEL CORTE:{NotaFinal}");
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Console.Clear();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" _____________________________");
                Console.WriteLine("|  UNIVERSIDAD SANTO TOMAS     |");
                Console.WriteLine(" _____________________________");

                Console.ResetColor();
                Console.WriteLine("1. Ingresar estudiante.");
                Console.WriteLine("2. Ver notas finales de los estudiantes.");
                Console.WriteLine("0. Salir");
                int op = Convert.ToInt16(Console.ReadLine() ?? "0");
                Console.Clear();

                if (op == 1)
                {
                    IngresarEstudiante();
                }
                else if (op == 2)
                {
                    if (estudiantes.Count > 0)
                    {
                        CalcNotas();
                    }
                    else
                    {
                        Console.WriteLine("No se han ingresado estudiantes.");
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        Console.Clear();
                    }
                }
                else if (op == 0)
                {
                    break;
                }
            }
        }
    }
}
