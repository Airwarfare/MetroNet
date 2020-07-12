using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MetroNet
{
    public class Contact
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("cityName")]
        public string CityName { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        public Contact(string fullName, string cityName, string phoneNumber, string emailAddress)
        {
            FullName = fullName;
            CityName = cityName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }

        public string Validate()
        {
            bool validPhonenumber = new Regex(@"(^[0-9 -]+$)").IsMatch(this.PhoneNumber);
            bool validEmail = new Regex(@"(?<=.)(@)(?=.)").IsMatch(this.EmailAddress);

            //Considered doing a K-map but for readability and simplicity simple if checks are fine
            if (validPhonenumber && validEmail)
            {
                return "Valid";
            }

            if (!validEmail && validPhonenumber)
            {
                return "Email is invalid";
            }

            if (!validPhonenumber && validEmail)
            {
                return "Phone is invalid";
            }

            return "Email and Phone are invalid";
        }
    }

    public class DataValidation
    {
        public static Dictionary<string, int> cityErrors = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            TextReader textReader = new StreamReader(@"Contacts.json");
            List<Contact> contacts = JsonConvert.DeserializeObject<List<Contact>>(textReader.ReadToEnd());

            Console.WriteLine("Contacts\n------------------");
            contacts.ForEach(contact =>
            {
                string valid = contact.Validate();
                //If we don't have the city in the hashmap add it
                if (!cityErrors.ContainsKey(contact.CityName))
                    cityErrors.Add(contact.CityName, 0);

                if (valid != "Valid")
                    cityErrors[contact.CityName] += 1; 

                Console.WriteLine($"{contact.FullName}, {valid}");
            });

            Console.WriteLine("\nCities\n------------------");
            cityErrors.Keys.ToList().ForEach(key =>
            {
                Console.WriteLine($"{key}: {cityErrors[key]}");
            });
        }
    }
}
