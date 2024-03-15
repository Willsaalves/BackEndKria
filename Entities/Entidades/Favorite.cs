

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entidades
{
    public class Favorite 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] // Indica que o campo Owner é obrigatório
        public string Owner { get; set; }

        [Required] // Indica que o campo RepoName é obrigatório
        public string RepoName { get; set; }

        public string LastUpdate { get; set; }

        public string Language {  get; set; }

        [Required]

        public bool Status { get; set; }
    }
}
