namespace bookmanager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("book")]
    public partial class book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required (ErrorMessage ="Vui long nhap tua de")]
        [StringLength(100, ErrorMessage ="Tua de khong qua 100")]
        public string Title { get; set; }

        [Required(ErrorMessage ="Vui long nhap chi tiet")]
        [StringLength(200, ErrorMessage ="Description khong qua 200")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui long nhap tac gia")]
        [StringLength(30,ErrorMessage ="Tac gia khong qua 30")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Vui long nhap hinh anh")]
        [StringLength(255)]
        public string Images { get; set; }
        [Required(ErrorMessage = "Vui long nhap gia")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000 đến 1000000")]
        public int Price { get; set; }
    }
}
