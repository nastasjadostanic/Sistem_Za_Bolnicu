

using System;

namespace MainPackage.Model
{
    public class User
    {
        public void ChangeFirstName(string name)
        {
            this.FirstName = name;
        }

        public void ChangeLastName(string lastname)
        {
            this.LastName = lastname;
        }

        public void ChangeEMail(string email)
        {
            this.Email = email;
        }

        public void ChangePhone(string phone)
        {
            this.Phone = phone;
        }
        public void ChangeAdress(string address)
        {
            this.Address = address;
        }

        public void ChangePassword(string password)
        {
            this.Password = password;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String DateOfBirth { get; set; }
        public String Jmbg { get; set; } 
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

    }
}