using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Lab_20.Models
{
    public class UserInfo
    {
        private string firstname;
        private string lastname;
        private string email;
        private string drink;
        private string state;
        private string phone;
        private string password;


        public string UserFirstName
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        public string UserLastName
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }

        public string UserEmail
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string UserPhone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string UserState
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
            }
        }

        public string UserDrink
        {
            get
            {
                return drink;
            }

            set
            {
                drink = value;
            }
        }

        public UserInfo()
        {
            firstname = "";
            lastname = "";
            email = "";
            phone = "";
            password = "";
        }

        public UserInfo(string FirstName, string LastName, string Email, string Phone, string Password, string State, string Drink)
        {
            firstname = FirstName;
            lastname = LastName;
            email = Email;
            phone = Phone;
            password = Password;
            state = State;
            drink = Drink;
        }
    }
}