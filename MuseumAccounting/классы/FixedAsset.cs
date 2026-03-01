using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumAccounting
{
    [Table("FixedAssets")]
    public class FixedAsset
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("InventoryNumber")]
        public string InventoryNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [Column("CategoryId")]
        public int CategoryId { get; set; }

        [Required]
        [Column("CommissionDate")]
        public DateTime CommissionDate { get; set; }

        [Required]
        [Column("InitialCost", TypeName = "decimal(18,2)")]
        public decimal InitialCost { get; set; }

        [Required]
        [Column("ResponsibleEmployeeId")]
        public int ResponsibleEmployeeId { get; set; }

        [Required]
        [Column("LocationId")]
        public int LocationId { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

        [Required]
        public StatusEnum Status { get; set; }

        // Навигационные свойства
        [ForeignKey("CategoryId")]
        public virtual AssetCategory Category { get; set; }

        [ForeignKey("ResponsibleEmployeeId")]
        public virtual Employee ResponsibleEmployee { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public virtual ICollection<AssetMovement> Movements { get; set; }
    }
}