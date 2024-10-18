using Microsoft.AspNetCore.Mvc;
using projectEF;
using projectEF.Models;
 
namespace WebApi1.Service
{
    public class CategoriaService : ICategoriaService
    {
        TareasContext context;

        public CategoriaService(TareasContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Categoria> Get()
        {
            return context.Categorias;
        }

        public async Task Save(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, [FromBody] Categoria categoria)
        {
            var categoriaActual = context.Categorias.Find(id);

            if (categoriaActual != null)
            {
                Console.WriteLine($"Updating CategoriaID: {id}");
                Console.WriteLine($"New Descripcion: {categoria.Descripcion}, New Nombre: {categoria.Nombre}, New Peso: {categoria.Peso}");


                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Peso = categoria.Peso;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            Categoria? categoriaActual = context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                context.Remove(categoriaActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();

        Task Save(Categoria categoria);

        Task Update(Guid id, [FromBody] Categoria categoria);

        Task Delete(Guid id);

    }
}
