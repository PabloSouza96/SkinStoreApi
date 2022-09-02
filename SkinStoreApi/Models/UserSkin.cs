using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinStoreApi.Models
{
    [Table("us_table")]
    public class UserSkin
    {
        [Key]
        [Column("Order_Id")]
        public int Id { get; set; }

        [Column("Code_User")]
        public int CodeUser { get; set; }

        [Column("Code_Skin")]
        public int CodeSkin { get; set; }
    }

    public class UsResult
    {
        public int Id { get; set; }

        public int CodeUser { get; set; }

        public int CodeSkin { get; set; }
    }
}
