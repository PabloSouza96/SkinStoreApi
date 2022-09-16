using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinStoreApi.Models
{
    //Representando os dados com quais nossa aplicação vai trabalhar
    [Table("player_table")]
    public class Player
    {
        //Informando quem é a chave primária
        [Key]
        //Configurando as colunas com nomes diferentes
        [Column("Player_Id")]
        public int Id { get; set; }

        [Column("Player_Name")]
        public string Name { get; set; }

        [Column("Player_Nick")]
        public string Nick { get; set; }

        [Column("Player_Function")]
        public string Function { get; set; }

        [Column("Player_Rating")]
        public decimal Rating { get; set; }
    }
}