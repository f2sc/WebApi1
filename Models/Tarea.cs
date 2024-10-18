using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace projectEF.Models
{
    public class Tarea
    {
        public Guid TareaId { get; set; }

        public Guid CategoriaId { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Prioridad PrioridadTarea { get; set; }

        public DateTime FechaCreacion { get; set; }

        public virtual Categoria Categoria { get; set; }

        public string Resumen {  get; set; }

        public string UrlArchivo { get; set; }
    }

    public enum Prioridad
    {
        Baja, 
        Media, 
        Alta
    }
}
