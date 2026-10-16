namespace SistemaGimnasio.Modelos
{
    public class Ejercicio
    {
        public string Nombre { get; set; }
        public int Repeticiones { get; set; }
        public int Series {  get; set; }
        public int Descanso { get; set; }

        public Ejercicio(string nombre, int repeticiones, int series, int desscanso)
        {
            Nombre = nombre;
            Repeticiones = repeticiones;
            Series = series;
            Descanso = desscanso;
        }
    }
}
