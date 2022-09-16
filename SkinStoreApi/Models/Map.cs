using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinStoreApi.Models
{
    //Representando os dados com quais nossa aplicação vai trabalhar
    [Table("map_table")]
    public class Map
    {
        //Informando quem é a chave primária
        [Key]
        //Configurando as colunas com nomes diferentes
        [Column("Map_Id")]
        public int Id { get; set; }

        [Column("Map_Name")]
        public string Name { get; set; }

        [Column("Map_Side")]
        public string Side { get; set; }

        [Column("Map_Comp")]
        public bool Comp { get; set; }
    }
}