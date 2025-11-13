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
}