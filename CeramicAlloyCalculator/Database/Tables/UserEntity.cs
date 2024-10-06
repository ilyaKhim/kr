using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CeramicAlloyCalculator.Database.Tables;

[Table("users")]
[PrimaryKey("id")]
public class UserEntity
{
    [Key]
    [Column("id")]
    public int id { get; set; }
    
    [Column("name")]
    public string name { get; set; }

    [Column("username")]
    public string username { get; set; }
    
    [Column("password")]
    public string password { get; set; }
    
    [Column("is_admin")]
    public bool is_admin { get; set; }
}