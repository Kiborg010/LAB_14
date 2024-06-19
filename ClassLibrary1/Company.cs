using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Company //Автомобильная кампания, которая владеет брендом.
    {
        public string brend; 
        public int year;
        public string country;
        public string city;

        public Company()
        {
            Brend = "No brend";
            Year = 1900;
            Country = "No country";
            City = "No city";
        }

        public Company(string brend, int year, string country, string city)
        {
            Brend = brend;
            Year = year;
            Country = country;
            City = city;
        }

        public string ToString()
        {
            return $"Компания {Brend} в {Country}, {City} (основана в {Year})";
        }

        public string Brend 
        {
            get
            {
                return brend;
            }
            set
            {
                if ((value == "") || !(Regex.IsMatch(value, @"^[а-яА-Яa-zA-Z0-9_]+$")))
                {
                    brend = "No brend";
                }
                else
                {
                    brend = value;
                }
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if ((value == "") || !(Regex.IsMatch(value, @"^[а-яА-Яa-zA-Z]+$")))
                {
                    country = "No country";
                }
                else
                {
                    country = value;
                }
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if ((value == "") || !(Regex.IsMatch(value, @"^[а-яА-Яa-zA-Z]+$")))
                {
                    city = "No city";
                }
                else
                {
                    city = value;
                }
            }
        }

        public int Year 
        {
            get
            {
                return year;
            }
            set 
            {
                if (value < 1900)
                {
                    year = 1900;
                }
                else if (value > 2024)
                {
                    year = 2024;
                }
                else
                {
                    year = value;
                }
            }
        }
    }
}
