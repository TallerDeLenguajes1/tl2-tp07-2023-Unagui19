using DatoSpace;
using  EspacioTareas;
namespace EspacioTareas
{
    public class ManejoDeTareas
    {
        public List<Tarea> tareas { get; set; }
        public int contadorTareas { get; set; }
        
        public ManejoDeTareas()
        {
            tareas=new List<Tarea>();
            contadorTareas = 0;
        }

        AccesoDatos accesoDatos=new AccesoDatos();

        private static ManejoDeTareas instancia;

        public static ManejoDeTareas GetInstacia()
        {
            if (instancia == null)
            {
                AccesoDatos helper= new AccesoDatos();
                instancia = new ManejoDeTareas();
                // Tareas =
                // instancia = helperCadeteria.Obtener();
                // List<Tarea> tareas= helper.getTareas();
                // List<Cadete> cadetes = helper.getCadetes("datos/Cadetes.json");
            }
            return instancia;
        }

        public bool CrearTarea(string? titulo, string descripcion)
        {
            contadorTareas++;
            Tarea nuevaTarea = new Tarea( contadorTareas, titulo, descripcion);
            if(nuevaTarea==null) return false;
            tareas.Add(nuevaTarea);
            accesoDatos.guardarTarea(tareas);
            return true;
        }
        
        

        public Tarea BuscarporTareaPorId(int id)
        {
            Tarea tarea = tareas.FirstOrDefault(tarea => tarea.Id == id);
            return tarea;
        }


        public void CambiarEstado(int idTarea, int estado)
        {
                foreach (var item in tareas)
                {
                    if (item.Id == idTarea)
                    {
                        if (estado == (int)Estado.Pendiente)
                        {
                            
                            item.Estado=Estado.EnProgreso;
                        }
                        else
                        {
                            item.Estado=Estado.Completada;
                        }
                    }
                }
                accesoDatos.guardarTarea(tareas);;
        }

        public bool EliminarTarea(int idTarea)
        {
            Tarea tarea = BuscarporTareaPorId(idTarea);
            if(tarea!=null){
                tareas.Remove(tarea);
                return true;
            }
            else{
                return false;
            }
        }

        public List<Tarea> ListarTareas()
        {
            return tareas;
        }

        
        public List<Tarea> ListarTareasCompletadas()
        {
            List<Tarea> tareasCompletadas = new List<Tarea>();
            foreach (var item in tareas)
            {
                if (item.Estado == Estado.Completada)
                {
                    tareasCompletadas.Add(item);
                }
            }

            if (tareasCompletadas!=null)
            {
                return tareasCompletadas;
            }
            else
            {
                return null;
            }
        }
    }

}