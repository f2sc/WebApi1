using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using projectEF;
using projectEF.Models;

namespace WebApi1.Service
{
    public class TareaService : ITareaService
    {
        TareasContext context;

        public TareaService(TareasContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            context.Tareas.Add(tarea);
            context.SaveChanges();
        }

        public async Task Update(Guid id, [FromBody] Tarea tarea)
        {
            Tarea? tareaActual = context.Tareas.Find(id);
            if (tareaActual != null) 
            {
                tareaActual.CategoriaId = tarea.CategoriaId;
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;
                tareaActual.FechaCreacion = tarea.FechaCreacion;
                tareaActual.Resumen = tarea.Resumen;
                tareaActual.UrlArchivo = tarea.UrlArchivo;

                context.Tareas.Add(tareaActual);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            Tarea? tareaActual = context.Tareas.Find(id);

            if (tareaActual != null)
            {
                context.Tareas.Remove(tareaActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITareaService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid id, [FromBody] Tarea tarea);
        Task Delete(Guid id);
    }
}
