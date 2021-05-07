using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBookApp.Models
{
    [MetadataType(typeof(AddressMetadata))]
    public partial class Address
    {

    }
    public class AddressMetadata
    {
        [DisplayName("氏名")]
        [Required]
        public string Name { get; set; }
        [DisplayName("カナ")]
        [Required]
        public string Kana { get; set; }
        [DisplayName("郵便番号")]
        public string ZipCode { get; set; }
        [DisplayName("都道府県")]
        public string Prefecture { get; set; }
        [DisplayName("住所")]
        public string StreetAddress { get; set; }
        [DisplayName("電話番号")]
        public string Telephone { get; set; }
        [DisplayName("メール")]
        public string Mail { get; set; }
        [DisplayName("グループ")]
        public Nullable<int> Group_Id { get; set; }

    }
}