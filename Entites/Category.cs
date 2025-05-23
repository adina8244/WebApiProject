﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entites;

[Table("CATEGORIES")]
public partial class Category
{
    [Key]
    [Column("CATEGORY_ID")]
    public int CategoryId { get; set; }

    [Column("CATEGORY_NAME")]
    [StringLength(50)]
    public string CategoryName { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Proudct> Proudcts { get; set; } = new List<Proudct>();
}