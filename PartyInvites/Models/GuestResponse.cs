using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Proszę podać swoję imię i nazwisko.")]
        public string Name {get; set;}
        [Required(ErrorMessage = "Proszę podać swoję adres email.")]
        [RegularExpression(".+\\@.+\\..+")]
        public string Email {get; set;}
        [Required(ErrorMessage = "Proszę podać numer telefonu.")]
        public string Phone {get; set; }
        [Required(ErrorMessage = "Proszę określić, czy wezmiesz udział.")]
        public bool? WillAtend {get; set;}

    }
}