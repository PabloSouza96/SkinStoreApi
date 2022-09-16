using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinStoreApi.Models
{
    //Representando os dados com quais nossa aplicação vai trabalhar
    [Table("skin_table")]
    public class Skin
    {
        //Informando quem é a chave primária
        [Key]
        //Configurando as colunas com nomes diferentes
        [Column("Skin_Id")]
        public int Id { get; set; }

        [Column("Skin_Name")]
        public string Name { get; set; }

        [Column("Skin_Key")]
        public string Key { get; set; }

        [Column("Skin_Float")]
        [DisplayFormat(DataFormatString = "{0:F4}")]
        public decimal Float { get; set; }

        [Column("Skin_Value")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Value { get; set; }

        [Column("Skin_Amount")]
        public int Amount { get; set; }
    }
}