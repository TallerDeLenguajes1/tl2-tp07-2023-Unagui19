using EspacioTareas;
using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_Unagui19.Controllers;

[ApiController]
[Route("[controller]")]
public class ManejoDeTareasController : ControllerBase
{
   
    private ManejoDeTareas manejoTareas;
    private readonly ILogger<ManejoDeTareasController> _logger;

    public ManejoDeTareasController(ILogger<ManejoDeTareasController> logger)
    {
        _logger = logger;
        manejoTareas= ManejoDeTareas.GetInstacia();
    }

    [HttpGet]
    [Route("GetTareas")]
    public ActionResult<IEnumerable<Tarea>> GetTareas()
    {
        return Ok(manejoTareas.tareas);
    }

    [HttpPost]
    [Route ("AddTarea")] 
    public ActionResult<bool>AddTarea(string? titulo, string descripcion)
    {
        bool resultado = manejoTareas.CrearTarea(titulo, descripcion);
        if(resultado){
            return Ok("Tarea agregada con exito");
        }
        else{
            return StatusCode(500,"error al agregar tarea");
        }
    }

    [HttpDelete]
    [Route("Borrar tAAREA")]
    public ActionResult<bool> borrarTarea(int idTarea)
    {
        // Pedido pedido = new Pedido();
        if(idTarea!=0){
            manejoTareas.EliminarTarea(idTarea);
            return Ok("tarea eliminada con exito");
        }
        else{
            return NotFound("pedido incorrectos");
        }
    }
    

    // [HttpGet(Name = "GetWeatherForecast")]
    // public IEnumerable<ManejoDeTareas> Get()
    // {
    //     return Enumerable.Range(1, 5).Select(index => new ManejoDeTareas
    //     {
    //         Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         TemperatureC = Random.Shared.Next(-20, 55),
    //         Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //     })
    //     .ToArray();
    // }
}
