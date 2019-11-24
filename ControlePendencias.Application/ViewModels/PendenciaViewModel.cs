using ControlePendencias.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControlePendencias.Application.ViewModels
{
    public class PendenciaViewModel
    {
        public PendenciaViewModel()
        {
            DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }

        [Display(Name = "Título")]
        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        [MaxLength(60, ErrorMessage = "Limite máximo de 60 caracteres")]
        [Required(ErrorMessage = "Título obrigatório")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        [MinLength(20, ErrorMessage = "Mínimo de 20 caracteres")]
        [MaxLength(500, ErrorMessage = "Limite máximo de 500 caracteres")]
        [Required(ErrorMessage = "Descrição obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Complexidade obrigatória")]
        public Complexidade Complexidade { get; set; }

        [Required(ErrorMessage = "Prioridade obrigatória")]
        public Prioridade Prioridade { get; set; }

        [Required(ErrorMessage = "Status obrigatória")]
        public Status Status { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Entrega")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Data Final obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        public DateTime DataFinal { get; set; }

        [Display(Name = "Responsável")]
        [Range(typeof(int), "1", "99999", ErrorMessage = "Responsável obrigatório")]
        public int IdResponsavelSelecionado { get; set; }

        public ResponsavelViewModel ResponsavelAtual { get; set; }
    }
}