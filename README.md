# Examen_DeGestionarNotas
public class Gestionar Notas
{
    // Interfaz para cálculo de nota final
    public interface ICalculoNota
    {
        double CalcularNotaFinal();
    }

    // Clase Alumno
    public class Alumno
    {
        public string Nombre { get; set; }
        public string NumeroCuenta { get; set; }
        public string Email { get; set; }

        public Alumno(string nombre, string numeroCuenta, string email)
        {
            Nombre = nombre;
            NumeroCuenta = numeroCuenta;
            Email = email;
        }
    }

    // Clase Asignatura
    public class Asignatura
    {
        public string NombreAsignatura { get; set; }
        public string NombreDocente { get; set; }
        public string Horario { get; set; }

        public Asignatura(string nombreAsignatura, string nombreDocente, string horario)
        {
            NombreAsignatura = nombreAsignatura;
            NombreDocente = nombreDocente;
            Horario = horario;
        }
    }

    // Clase Matricula implementa ICalculoNota
    public class Matricula : ICalculoNota
    {
        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }
        public List<double> NotasParciales { get; set; }

        public Matricula(Alumno alumno, Asignatura asignatura)
        {
            Alumno = alumno;
            Asignatura = asignatura;
            NotasParciales = new List<double>();
        }

        // Método de la interfaz: suma todas las notas de la lista
        public double CalcularNotaFinal()
        {
            double total = 0;
            foreach (double nota in NotasParciales)
            {
                total += nota;
            }
            return total;
        }

        // Método sobrecargado: recibe 3 notas como parámetros
        public double CalcularNotaFinal(double n1, double n2, double n3)
        {
            return n1 + n2 + n3;
        }

        // Devuelve mensaje según rango de nota
        public string ObtenerMensajeNota(double notaFinal)
        {
            if (notaFinal < 60) return "Reprobado";
            else if (notaFinal < 80) return "Bueno";
            else if (notaFinal < 90) return "Muy Bueno";
            else return "Sobresaliente";
        }

        // Valida las notas según reglas del examen
        public void ValidarNotas(double n1, double n2, double n3)
        {
            if (n1 + n2 > 30) throw new ArgumentException("La suma de las notas 1 y 2 no puede ser mayor a 30.");
            if (n3 > 40) throw new ArgumentException("La nota 3 no puede ser mayor a 40.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Gestión de Notas ===\n");

            // Inicializar alumno y asignatura
            Alumno alumno = new Alumno("Lissy Barrera", "202520345", "lissy.barrera@univ.edu");
            Asignatura asignatura = new Asignatura("Programación II", "Ing. Alis Barrera", "Lunes y Miércoles 9:00-11:00");

            Matricula matricula = new Matricula(alumno, asignatura);

            try
            {
                // Pedir 3 notas parciales
                double[] notas = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Ingrese la nota del parcial {i + 1}: ");
                    notas[i] = double.Parse(Console.ReadLine());
                }

                // Validar notas
                matricula.ValidarNotas(notas[0], notas[1], notas[2]);

                // Guardar notas en la lista
                matricula.NotasParciales.AddRange(notas);

                // Calcular nota final de dos formas
                double notaFinal1 = matricula.CalcularNotaFinal(); // por lista
                double notaFinal2 = matricula.CalcularNotaFinal(notas[0], notas[1], notas[2]); // por parámetros

                // Mostrar resumen
                Console.WriteLine("\n--- Resumen del Alumno ---");
                Console.WriteLine($"Nombre: {alumno.Nombre}");
                Console.WriteLine($"Número de cuenta: {alumno.NumeroCuenta}");
                Console.WriteLine($"Correo: {alumno.Email}");
                Console.WriteLine($"Asignatura: {asignatura.NombreAsignatura}");
                Console.WriteLine($"Docente: {asignatura.NombreDocente}");
                Console.WriteLine($"Horario: {asignatura.Horario}");

                Console.WriteLine("\n--- Resultados de Notas ---");
                Console.WriteLine($"Nota final (lista): {notaFinal1} - {matricula.ObtenerMensajeNota(notaFinal1)}");
                Console.WriteLine($"Nota final (parámetros): {notaFinal2} - {matricula.ObtenerMensajeNota(notaFinal2)}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: debe ingresar solo números para las notas.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nFin del programa. Presione cualquier tecla para salir...");
                Console.ReadKey();
            }
        }
    }
}
