using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Customer
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter name"), MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter email correct format")]
        public string Email { get; set; }
        [Required]
        [Range(0, 110, ErrorMessage = "Please enter correct value")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter gender"), MaxLength(20)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please enter image")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
    }
}