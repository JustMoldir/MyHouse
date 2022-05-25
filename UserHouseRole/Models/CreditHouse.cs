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
    public class CreditHouse
    {

        [Key]
        public int CreditId { get; set; }

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
        [DisplayName("CImage Name1")]
        public string CImageName1 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("CImage Name2")]
        public string CImageName2 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("CImage Name3")]
        public string CImageName3 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("CImage Name4")]
        public string CImageName4 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("CImage Name5")]
        public string CImageName5 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("CImage Name6")]
        public string CImageName6 { get; set; }

        [NotMapped]
        [DisplayName("Upload File1")]
        public IFormFile CImageFile1 { get; set; }
        [NotMapped]
        [DisplayName("Upload File2")]
        public IFormFile CImageFile2 { get; set; }
        [NotMapped]
        [DisplayName("Upload File3")]
        public IFormFile CImageFile3 { get; set; }
        [NotMapped]
        [DisplayName("Upload File4")]
        public IFormFile CImageFile4 { get; set; }
        [NotMapped]
        [DisplayName("Upload File5")]
        public IFormFile CImageFile5 { get; set; }
        [NotMapped]
        [DisplayName("Upload File6")]
        public IFormFile CImageFile6 { get; set; }



    }
}
