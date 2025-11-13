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

        public double CalcularNotaFinal()
        {
            double total = 0;
            foreach (double nota in NotasParciales) total += nota;
            return total;
        }

        public double CalcularNotaFinal(double n1, double n2, double n3)
        {
            return n1 + n2 + n3;
        }

        public string ObtenerMensajeNota(double notaFinal)
        {
            if (notaFinal < 60) return "Reprobado";
            else if (notaFinal < 80) return "Bueno";
            else if (notaFinal < 90) return "Muy Bueno";
            else return "Sobresaliente";
        }

        public void ValidarNotas(double n1, double n2, double n3)
        {
            if (n1 + n2 > 30) throw new ArgumentException("La suma de las dos primeras notas no puede pasar de 30.");
            if (n3 > 40) throw new ArgumentException("La tercera nota no puede ser mayor a 40.");
        }
    }
}