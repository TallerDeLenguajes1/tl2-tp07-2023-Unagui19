using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using EspacioTareas;

namespace DatoSpace
{
    public class AccesoDatos
    {
        public string leerArchivo(string path)
        {
            string? documento;
            using (var fs = new FileStream(path,FileMode.Open)){
                //abrir el archivo
                using(var sr = new StreamReader(fs)){// para leer
                    documento= sr.ReadToEnd(); 
                    // Console.WriteLine(documento);
                    sr.Close();
                }
                fs.Close();
            }           
            return documento; 
        }

        public List<Tarea> getTareas()
        {
            string documento=leerArchivo("datos/tareas.json");
            List<Tarea> tareas= JsonSerializer.Deserialize<List<Tarea>>(documento); 
            // Console.WriteLine($"{cadeteria.Nombre},{cadeteria.Telefono},{cadeteria.Code}");
            return tareas; 
        }

        public void guardarTarea(List<Tarea> tareas)
        {    
            var fst = new FileStream("datos/tareas.json",FileMode.OpenOrCreate);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string archivoJson = JsonSerializer.Serialize(tareas, options);
            using (var sw =new StreamWriter(fst))
            {
                sw.WriteLine(archivoJson);
                sw.Close();
            }//PARA CREAR UN JSON y guardar o solo guardar 
            fst.Close();
        }

    }
}