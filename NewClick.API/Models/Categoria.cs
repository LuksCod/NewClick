using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewClick.API.Models;

    public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    [StringLength(26)]
    public string Cor { get; set; } = "rgba(0,0,0,1)";
    public int Id { get; internal set; }
}
