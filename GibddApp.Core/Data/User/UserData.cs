using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GibddApp.Core.Data.User
{
    public class UserData
    {
        // required
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Sex Sex { get; set; }


        public string Patronymic { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public string JobTitle { get; set; } = "";
        public string WorkPlaceName { get; set; } = "";

        public Address WorkPlaceAddress { get; set; } = Address.Invalid();
        public Address RegistrationAddress { get; set; } = Address.Invalid();
        public Address ResidentialAddress { get; set; } = Address.Invalid();

        public UserData(string firstName, string lastName, Sex sex)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
        }

        public UserData(string firstName, string lastName, Sex sex,
            string patronymic, string phoneNumber, string email, string jobTitle, string workPlaceName,
            Address workPlaceAddress, Address registrationAddress, Address residentialAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Email = email;
            JobTitle = jobTitle;
            WorkPlaceName = workPlaceName;
            WorkPlaceAddress = workPlaceAddress;
            RegistrationAddress = registrationAddress;
            ResidentialAddress = residentialAddress;
        }
    }
}
