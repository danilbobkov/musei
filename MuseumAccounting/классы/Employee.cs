using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumAccounting
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Column("FullName")]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        // Навигационное свойство для обратной связи
        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
    }
}