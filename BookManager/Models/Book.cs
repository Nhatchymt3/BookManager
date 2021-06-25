namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        
        public int ID { get; set; }
        [Required(ErrorMessage = "nhập đi đường có mà lười")]
        [StringLength(100,ErrorMessage ="nhập ít thôi siêng thế dưới 100")]
        public string Title { get; set; }
        [Required(ErrorMessage = "nhập đi đường có mà lười")]
        public string Description { get; set; }
        [Required(ErrorMessage = "nhập đi đường có mà lười")]
        [StringLength(30, ErrorMessage = "nhập ít thôi siêng thế dưới 30")]
        public string Athour { get; set; }
        [Required(ErrorMessage = "nhập đi đường có mà lười")]
        public string Images { get; set; }
        [Required(ErrorMessage = "nhập đi đường có mà lười")]
        [Range(1000,1000000,ErrorMessage ="bán vừa thôi 1k đến 1m oke?")]
        public int? Price { get; set; }
    }
}
