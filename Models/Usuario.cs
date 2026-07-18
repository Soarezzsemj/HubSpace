using System;
using System.ComponentModel.DataAnnotations;

namespace HubSpace.Web.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nome {get; set;}
        
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email {get; set;}
        
        [Required]
        [StringLength(255)]
        public string SenhaHash {get; set;}

        [Required] 
        [StringLength(20)] 
        public string Status { get; set; } = "Ativo";
        
        public DateTime DataCriacao {get; set;} =  DateTime.Now;        


    }
}