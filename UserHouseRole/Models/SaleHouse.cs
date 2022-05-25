using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserHouseRole.Models
{
    public class SaleHouse
    {

        [Key]
        public int SaleId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

        [Column(TypeName = "int")]
        public int KolKomnat { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Price { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TipStroenie { get; set; }

        [Column(TypeName = "int")]
        public int Year { get; set; }

        [Column(TypeName = "int")]
        public int Floor { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Ploshad { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Street { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Sostoyanie { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Internet { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Bolkony { get; set; }

        [Column(TypeName = "int")]
        public int Uchastok { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Text { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("SImage Name1")]
        public string SImageName1 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("SImage Name2")]
        public string SImageName2 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("SImage Name3")]
        public string SImageName3 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("SImage Name4")]
        public string SImageName4 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("SImage Name5")]
        public string SImageName5 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("SImage Name6")]
        public string SImageName6 { get; set; }

        [NotMapped]
        [DisplayName("Upload File1")]
        public IFormFile SImageFile1 { get; set; }
        [NotMapped]
        [DisplayName("Upload File2")]
        public IFormFile SImageFile2 { get; set; }
        [NotMapped]
        [DisplayName("Upload File3")]
        public IFormFile SImageFile3 { get; set; }
        [NotMapped]
        [DisplayName("Upload File4")]
        public IFormFile SImageFile4 { get; set; }
        [NotMapped]
        [DisplayName("Upload File5")]
        public IFormFile SImageFile5 { get; set; }
        [NotMapped]
        [DisplayName("Upload File6")]
        public IFormFile SImageFile6 { get; set; }






    }
}
