using InterviewProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewProject.Domains
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("UnitOfMeasure")]
        public int UnitOfMeasureId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerUnit { get; set; }
        public ProductStatusEnum Status { get; set; }

        public virtual Category Category { get; set; }
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
    }
}
