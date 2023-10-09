namespace EspacioTareas
{
    public enum Estado
    {
        Pendiente,
        EnProgreso,
        Completada
    }


    public class Tarea
    {
        int id;
        string? titulo;
        string descripcion;
        Estado estado;

        public Tarea(int id, string? titulo, string descripcion)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            estado = Estado.Pendiente;
        }

        public int Id { get => id; set => id = value; }
        public string? Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public Estado Estado { get => estado; set => estado = value; }
    }
}
