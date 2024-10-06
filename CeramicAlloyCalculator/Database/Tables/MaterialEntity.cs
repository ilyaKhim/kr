using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CeramicAlloyCalculator.Database.Tables;

[Table("materials")]
[PrimaryKey("id")]
public class MaterialEntity
{
    [Key]
    [Column("id")]
    public int id { get; set; }

    [Column("name")]
    public string name { get; set; }

    [Column("b0")]
    public double b0 { get; set; }
    
    [Column("b1")]
    public double b1 { get; set; }
    
    [Column("b2")]
    public double b2 { get; set; }
    
    [Column("b3")]
    public double b3 { get; set; }
    
    [Column("b4")]
    public double b4 { get; set; }
    
    [Column("b5")]
    public double b5 { get; set; }
    
    [Column("b6")]
    public double b6 { get; set; }
    
    [Column("b7")]
    public double b7 { get; set; }
    
    [Column("b8")]
    public double b8 { get; set; }
}