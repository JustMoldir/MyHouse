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
    public class RentHouse
    {

        [Key]
        public int SaleId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TipRent { get; set; }

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
        [DisplayName("RImage Name1")]
        public string RImageName1 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("RImage Name2")]
        public string RImageName2 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("RImage Name3")]
        public string RImageName3 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("RImage Name4")]
        public string RImageName4 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("RImage Name5")]
        public string RImageName5 { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("RImage Name6")]
        public string RImageName6 { get; set; }

        [NotMapped]
        [DisplayName("Upload File1")]
        public IFormFile RImageFile1 { get; set; }
        [NotMapped]
        [DisplayName("Upload File2")]
        public IFormFile RImageFile2 { get; set; }
        [NotMapped]
        [DisplayName("Upload File3")]
        public IFormFile RImageFile3 { get; set; }
        [NotMapped]
        [DisplayName("Upload File4")]
        public IFormFile RImageFile4 { get; set; }
        [NotMapped]
        [DisplayName("Upload File5")]
        public IFormFile RImageFile5 { get; set; }
        [NotMapped]
        [DisplayName("Upload File6")]
        public IFormFile RImageFile6 { get; set; }
    }
}
