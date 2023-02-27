using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public static class Utils
    {
        //Check is window already open
        public static bool FormIsOpen(string name)
        {
            var OpenForms = Application.OpenForms.Cast<Form>();
            var isOpen = OpenForms.Any(q => q.Name == name);
            return isOpen;
        }

        public static string HashPassword(string password)
        {
            SHA256 sHA = SHA256.Create();

            //Convert the imput string to a byte array and compute the hash
            byte[] data = sHA.ComputeHash(Encoding.UTF8.GetBytes(password));

            //Create a new Stringbuilder to collect the bytes
            //and create a string
            StringBuilder sBuilders = new StringBuilder();

            //Loop through each byte of the hashed data and format each one
            //as a hexidecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilders.Append(data[i].ToString("x2"));
            }

            return sBuilders.ToString();
        }

        public static string DefaultHashedPassword()
        {
            SHA256 sHA = SHA256.Create();

            //Convert the imput string to a byte array and compute the hash
            byte[] data = sHA.ComputeHash(Encoding.UTF8.GetBytes("Password@123"));

            //Create a new Stringbuilder to collect the bytes
            //and create a string
            StringBuilder sBuilders = new StringBuilder();

            //Loop through each byte of the hashed data and format each one
            //as a hexidecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilders.Append(data[i].ToString("x2"));
            }

            return sBuilders.ToString();
        }
    }
}
