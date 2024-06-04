using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Libro
    {
        [Key]
        public int PkLibro { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Editorial { get; set; } = null!;
        
        [ForeignKey("Autores")]
        public int FkAutor { get; set; }
        public Autor Autor { get; set; }

    }
}
