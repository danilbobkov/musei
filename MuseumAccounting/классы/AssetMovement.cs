using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumAccounting
{
    [Table("AssetMovements")]
    public class AssetMovement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("FixedAssetId")]
        public int FixedAssetId { get; set; }

        [Required]
        [Column("MovementDate")]
        public DateTime MovementDate { get; set; }

        [Column("OldLocationId")]
        public int? OldLocationId { get; set; }

        [Required]
        [Column("NewLocationId")]
        public int NewLocationId { get; set; }

        [MaxLength(500)]
        public string Reason { get; set; }

        // Навигационные свойства
        [ForeignKey("FixedAssetId")]
        public virtual FixedAsset FixedAsset { get; set; }

        [ForeignKey("OldLocationId")]
        public virtual Location OldLocation { get; set; }

        [ForeignKey("NewLocationId")]
        public virtual Location NewLocation { get; set; }
    }
}