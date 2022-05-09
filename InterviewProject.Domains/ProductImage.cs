using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewProject.Domains
{
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public byte[] Binary { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
