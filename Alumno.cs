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
}