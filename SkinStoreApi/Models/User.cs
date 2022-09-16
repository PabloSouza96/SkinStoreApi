using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkinStoreApi.Models
{
    //Representando os dados com quais nossa aplicação vai trabalhar
    [Table("user_table")]
    public class User
    {
        //Informando quem é a chave primária
        [Key]
        //Configurando as colunas com nomes diferentes
        [Column("User_Id")]
        public int Id { get; set; }

        [Column("User_Name")]
        public string Name { get; set; }

        [Column("User_LastName")]
        public string LastName { get; set; }

        [Column("User_Email")]
        public string Email { get; set; }

        [Column("User_Login")]
        public string Login { get; set; }

        [Column("User_Password")]
        public string Password { get; set; }

        [Column("User_Balance")]
        public decimal Balance { get; set; }

        [Column("User_Active")]
        public bool Active { get; set; }

        //Listando a lista de UserSkin
        public List<UsResult> UsResult { get; set; }
    }
}