using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewClick.API.Models;

public class Produto
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("CategoriaId")]
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(3000)]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }


    [Required(ErrorMessage = "A quantidade é obrigatório")]
    [Display(Name = "Quantidade")]
    public int Qtde { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Valor de Custo")]
    [Required(ErrorMessage = "O valor de custo é obrigatório")]
    public decimal ValorCusto { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    [Display(Name = "Valor de Venda")]
    [Required(ErrorMessage = "O valor de venda é obrigatório")]
    public decimal ValorVenda { get; set; }

    [Required(ErrorMessage = "O destaque é obrigatório")]
    public bool Destaque { get; set; } = false;

    [StringLength(300)]
    public string Foto { get; set; }
}
