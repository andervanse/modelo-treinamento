using ControlePendencias.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlePendencias.Application.ViewModels
{
    public class ResponsavelViewModel
    {
        public int Id { get; set; }

        [MinLength(5, ErrorMessage = "Mínimo de 5 caracteres")]
        [MaxLength(60, ErrorMessage = "Limite máximo de 60 caracteres")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Função")]
        [Required(ErrorMessage = "Função obrigatória")]
        public Funcao Funcao { get; set; }
        public IEnumerable<Pendencia> Pendencias { get; set; }       
    }
}