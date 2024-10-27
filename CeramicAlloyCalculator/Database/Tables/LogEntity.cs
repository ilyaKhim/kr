using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CeramicAlloyCalculator.Database.Tables;

[Table("log")]
[PrimaryKey("id")]
public class LogEntity
{
    [Key]
    [Column("id")]
    public int id { get; set; }

    [ForeignKey("User")]
    [Column("user_id")]
    public int user_id { get; set; }
    public UserEntity User { get; set; }

    [ForeignKey("Material")]
    [Column("material_id")]
    public int material_id { get; set; }
    public MaterialEntity Material { get; set; }

    [Column("event")]
    public string Event { get; set; }

    [Column("event_date")]
    public DateTime EventDate { get; set; } = DateTime.Now;
}
