using Microsoft.EntityFrameworkCore;
using projectEF.Models;

namespace projectEF
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>
            {
                new Categoria
                {
                    CategoriaID = Guid.Parse("d24f36a0-89e7-4e99-ac6f-8f7818716939"),
                    Nombre = "Actividades pendientes",
                    Descripcion = "Las actividades que están todavía pendientes de hacer.",
                    Peso = 20
                },
                new Categoria
                {
                    CategoriaID = Guid.Parse("d24f36a0-89e7-4e99-ac6f-8f7818716940"),
                    Nombre = "Actividades personales",
                    Descripcion = "Las actividades que se tienen que hacer personalmente.",
                    Peso = 50
                }
            };

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaID);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).HasMaxLength(1500).IsRequired(false);
                categoria.Property(p => p.Peso);

                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>
            {
                new Tarea { 
                    TareaId = Guid.Parse("b83f34bf-af22-493a-bd0e-415788ce4163"), 
                    CategoriaId = Guid.Parse("d24f36a0-89e7-4e99-ac6f-8f7818716939"), 
                    Titulo = "Hacer la compra", 
                    Descripcion = "Hay que hacer la compra en el mercadona." , 
                    FechaCreacion = DateTime.Now, 
                    PrioridadTarea = Prioridad.Media, 
                    UrlArchivo = "https://cdn.businessinsider.es/sites/navi.axelspringer.es/public/media/image/2022/11/mujer-mirando-lista-compra-2880589.jpg?tf=3840x" 
                },
                new Tarea
                {
                    TareaId = Guid.Parse("b83f34bf-af22-493a-bd0e-415788ce4174"), 
                    CategoriaId = Guid.Parse("d24f36a0-89e7-4e99-ac6f-8f7818716940"), 
                    Titulo = "Hacer deporte", 
                    Descripcion = "Salir a correr 15 minutos o correr en la cinta.", 
                    FechaCreacion = DateTime.Now, 
                    PrioridadTarea = Prioridad.Alta, 
                    UrlArchivo = "https://media.revistagq.com/photos/641c645781245672268fff7a/16:9/w_2560%2Cc_limit/1036780592"
                }

            };

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);

                tarea.HasOne(p => p.Categoria)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(p => p.CategoriaId);

                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Ignore(p => p.Resumen);
                tarea.Property(p => p.UrlArchivo).IsRequired(false);

                tarea.HasData(tareasInit);
            });
        }
    }
}
