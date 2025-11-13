# Examen_DeGestionarNotas
public class Gestionar Notas
{
    public interface ICalculoNota
    {
        double CalcularNotaFinal();
    }

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

        // Método de la interfaz
        public double CalcularNotaFinal()
        {
            double total = 0;
            foreach (double nota in NotasParciales)
            {
                total += nota;
            }
            return total;
        }

        // Sobrecarga del método
        public double CalcularNotaFinal(double n1, double n2, double n3)
        {
            return n1 + n2 + n3;
        }

        // Mensaje según la nota
        public string ObtenerMensajeNota(double notaFinal)
        {
            if (notaFinal < 60)
                return "Reprobado";
            else if (notaFinal < 80)
                return "Bueno";
            else if (notaFinal < 90)
                return "Muy Bueno";
            else
                return "Sobresaliente";
        }

        // Validar notas con excepciones
        public void ValidarNotas(double n1, double n2, double n3)
        {
            if (n1 + n2 > 30)
                throw new ArgumentException("La suma de la nota 1 y la nota 2 no puede ser mayor a 30.");
            if (n3 > 40)
                throw new ArgumentException("La nota 3 no puede ser mayor a 40.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Gestión de Notas ===\n");

            // Datos del alumno y asignatura
            Alumno alumno = new Alumno("Luis Martínez", "202520678", "luis.martinez@univ.edu");
            Asignatura asignatura = new Asignatura("Programación II", "Ing. Gabriela Torres", "Martes y Jueves 9:00-11:00");

            Matricula matricula = new Matricula(alumno, asignatura);

            try
            {
                Console.Write("Ingrese la nota del primer parcial: ");
                double n1 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota del segundo parcial: ");
                double n2 = double.Parse(Console.ReadLine());

                Console.Write("Ingrese la nota del tercer parcial: ");
                double n3 = double.Parse(Console.ReadLine());

                // Validar
                matricula.ValidarNotas(n1, n2, n3);

                // Guardar notas
                matricula.NotasParciales.Add(n1);
                matricula.NotasParciales.Add(n2);
                matricula.NotasParciales.Add(n3);

                // Calcular notas finales (dos maneras)
                double notaFinal1 = matricula.CalcularNotaFinal();
                double notaFinal2 = matricula.CalcularNotaFinal(n1, n2, n3);

                // Mostrar resultados
                Console.WriteLine("\n--- Resumen del Alumno ---");
                Console.WriteLine("Nombre: " + alumno.Nombre);
                Console.WriteLine("Número de cuenta: " + alumno.NumeroCuenta);
                Console.WriteLine("Correo: " + alumno.Email);
                Console.WriteLine("Asignatura: " + asignatura.NombreAsignatura);
                Console.WriteLine("Docente: " + asignatura.NombreDocente);
                Console.WriteLine("Horario: " + asignatura.Horario);

                Console.WriteLine("\n--- Resultados de Notas ---");
                Console.WriteLine("Nota final (lista): " + notaFinal1 + " - " + matricula.ObtenerMensajeNota(notaFinal1));
                Console.WriteLine("Nota final (parámetros): " + notaFinal2 + " - " + matricula.ObtenerMensajeNota(notaFinal2));
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
                Console.WriteLine("\nFin del programa. Presione cualquier opción para salir del programa...");
                Console.ReadKey();
            }
        }
    }
}
