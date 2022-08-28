//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WatchStore.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Wrong type email")]
        public string Email { get; set; }
    /*    [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        // dung maxvalue thi khong gap bug khi encrypted password
        [StringLength(int.MaxValue, ErrorMessage = "Password must > 5", MinimumLength = 6)]*/
        public string Password { get; set; }
        // bug neu dung confirm password        
        /*[Required(ErrorMessage = "Please enter confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password not correct")]
        [JsonIgnore]
        [NotMapped]*/
        public string ConfirmPassword { get; set; }
        public string Avatar { get; set; }
        [Required(ErrorMessage = "Please enter phone")]
        [RegularExpression(@"\d{9}", ErrorMessage = "Please enter 10 digit")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your name")]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int isAdmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}