using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumAccounting
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        // Навигационные свойства
        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
        public virtual ICollection<AssetMovement> OldLocationMovements { get; set; }
        public virtual ICollection<AssetMovement> NewLocationMovements { get; set; }
    }
}