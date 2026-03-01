using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuseumAccounting
{
    [Table("AssetCategories")]
    public class AssetCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public virtual ICollection<FixedAsset> FixedAssets { get; set; }
    }
}