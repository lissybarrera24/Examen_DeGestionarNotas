public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Gestión de Notas (Mixto) ===\n");

            // Crear alumnos
            List<Alumno> alumnos = new List<Alumno>
            {
                new Alumno("Lissy Barrera", "202520345", "lissy.barrera@univ.edu"),
                new Alumno("Alis Barrera", "202520346", "alis.barrera@univ.edu"),
                new Alumno("Pedro Barrera", "202520347", "pedro.barrera@univ.edu")
            };

            // Crear asignatura
            Asignatura asignatura = new Asignatura("Programación II", "Ing. Alis Barrera", "Lunes y Miércoles 9:00-11:00");

            // Notas predefinidas para los dos primeros alumnos
            double[][] notasPredefinidas = new double[][]
            {
                new double[] { 10, 12, 35 }, // Lissy
                new double[] { 15, 10, 30 }  // Alis
            };

            for (int idx = 0; idx < alumnos.Count; idx++)
            {
                Alumno alumno = alumnos[idx];
                Matricula matricula = new Matricula(alumno, asignatura);
                double[] notas = new double[3];

                try
                {
                    if (idx < 2) // Los primeros dos alumnos usan notas predefinidas
                    {
                        notas = notasPredefinidas[idx];
                        Console.WriteLine($"\n--- Notas automáticas para {alumno.Nombre} ---");
                    }
                    else // Tercer alumno ingresa manualmente
                    {
                        Console.WriteLine($"\n--- Ingreso de notas para {alumno.Nombre} ---");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.Write($"Ingrese la nota del parcial {i + 1}: ");
                            notas[i] = double.Parse(Console.ReadLine());
                        }
                    }

                    // Validar notas
                    matricula.ValidarNotas(notas[0], notas[1], notas[2]);
                    matricula.NotasParciales.AddRange(notas);

                    double notaFinal1 = matricula.CalcularNotaFinal();
                    double notaFinal2 = matricula.CalcularNotaFinal(notas[0], notas[1], notas[2]);

                    // Mostrar resumen
                    Console.WriteLine($"\n--- Resumen de {alumno.Nombre} ---");
                    Console.WriteLine($"Número de cuenta: {alumno.NumeroCuenta}");
                    Console.WriteLine($"Correo: {alumno.Email}");
                    Console.WriteLine($"Asignatura: {asignatura.NombreAsignatura}");
                    Console.WriteLine($"Docente: {asignatura.NombreDocente}");
                    Console.WriteLine($"Horario: {asignatura.Horario}");
                    Console.WriteLine("Notas parciales: " + string.Join(", ", notas));
                    Console.WriteLine($"Nota final (lista): {notaFinal1} - {matricula.ObtenerMensajeNota(notaFinal1)}");
                    Console.WriteLine($"Nota final (parámetros): {notaFinal2} - {matricula.ObtenerMensajeNota(notaFinal2)}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Solo se permiten números en las notas.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            Console.WriteLine("\nFin del programa. Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}