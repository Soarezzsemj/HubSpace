using System;
using System.ComponentModel.DataAnnotations;

namespace HubSpace.Web.Models
{
    public class Espaco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } // Ex: "Sala de Reunião", "Estação de Trabalho"

        public int Capacidade { get; set; }

        public decimal PrecoPorHora { get; set; }

        public bool Disponivel { get; set; } = true;
    }
}