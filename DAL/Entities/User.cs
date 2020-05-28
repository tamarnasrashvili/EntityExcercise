using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "სახელი სავალდებულოა")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "გვარი სავალდებულოა")]
        public string Lastname { get; set; }
        [Required(ErrorMessage ="მეილი სავალდებულოა")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "პაროლი სავალდებულოა")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public ICollection<UserRate> UserRates { get; set; }
    }
}
