using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinStoreApi.Models
{
    //Representando os dados com quais nossa aplicação vai trabalhar
    [Table("us_table")]
    public class UserSkin
    {
        //Informando quem é a chave primária
        [Key]
        //Configurando as colunas com nomes diferentes
        [Column("Order_Id")]
        public int Id { get; set; }

        [Column("Code_User")]
        public int CodeUser { get; set; }

        [Column("Code_Skin")]
        public int CodeSkin { get; set; }
    }

    //Criando a lista de UserSkin
    public class UsResult
    {
        public int Id { get; set; }

        public int CodeUser { get; set; }

        public int CodeSkin { get; set; }
    }
}
