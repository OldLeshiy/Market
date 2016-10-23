using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Validation;

namespace Model
{
    public class Symbol
    {
        [Key,Required,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, NotNullOrWhiteString]
        public string Name { get; set; }

        [Required, NonZeroPrice]
        public float Spread { get; set; }
    }
}
