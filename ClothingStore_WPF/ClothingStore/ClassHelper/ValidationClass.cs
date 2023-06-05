using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace ClothingStore.ClassHelper
{
    class ValidationClass
    {
        public ValidationClass() { 
        char[] char2 = Enumerable.Range('а', 'я' - 'а' + 1).Select(c => (char)c).ToArray();
        char[] char5 = Enumerable.Range('А', 'Я' - 'А' + 1).Select(c => (char)c).ToArray();
        char[] char3 = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();
        char[] char4 = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToArray();
    }    
       
        public static bool ValidateNumbersAndSpecialSymbols(string text)
        {
            char[] char1 = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', ';', ':', '+', '-', '=', '|', '№', '"', '_', '`', '~', '/', '<', '>'};

            text = text.Trim();
            foreach (var i in char1)
            {
                if (text.Contains(i))
                {
                    return false;
                }
                
            }
            return true;
        }
        public static bool ValidateSymbols(string text)
        {
            char[] char2 = Enumerable.Range('а', 'я' - 'а' + 1).Select(c => (char)c).ToArray();
            char[] char5 = Enumerable.Range('А', 'Я' - 'А' + 1).Select(c => (char)c).ToArray();
            char[] char3 = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();
            char[] char4 = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToArray();
            text = text.Trim();
            foreach (char i in char2)
            {
                if (text.Contains(i))
                {
                    return false;
                }
                else
                {
                    foreach (char c in char5)
                    {

                        if (text.Contains(c))
                        {
                            return false;

                        }
                        else
                        {
                            foreach (char j in char3)
                            {
                                if (text.Contains(j))
                                {
                                    return false;
                                }
                                else
                                {
                                    foreach (char s in char4)
                                    {
                                        if (text.Contains(s))
                                        {
                                            return false;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

            }
            return true;
        }

        public static bool ValidationText(string text)
        {
            text= text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }

            if (ValidateNumbersAndSpecialSymbols(text))
            {
                return true;
            }

            return false;
        }
        public static bool ValidationPhone(string phone)
        {
            phone= phone.Trim();
            if (string.IsNullOrEmpty(phone))
            {
                return true;
            }
                

            if (ValidateSymbols(phone))
            {
                return true;
            }
                

           
                

            return false;
        }

        public static bool ValidationEmail(string email)
        {
            email= email.Trim();
            string conde = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";

            if (Regex.IsMatch(email, conde))
            {
                
                return true;
            }
            return false;
        }

        public static bool ValidationDate(string date)
        {
            date= date.Trim();
          
            string conddate = @"(\w+([-+.]\w+)*.\w+([-.]\w+)*\.\w+([-.]\w+)*)";

            if (string.IsNullOrEmpty(date))
            {
                return false;
            }

            if (Regex.IsMatch(date, conddate))
            {
                return false;
            }


            return true;
        }

        public static string GetFormatedPhoneNumber(string phone)
        {
            phone= phone.Trim();


            
            if (string.IsNullOrEmpty(phone))
                return null;

           
               
            
            if (phone != null && phone.Length == 11 && phone[0] != '+')
                return string.Format("+{0}({1}){2}-{3}-{4}", phone.Substring(0, 1), phone.Substring(1, 3), phone.Substring(4, 3), phone.Substring(7, 2), phone.Substring(9, 2));

            if (phone != null && phone.Length ==12 && phone[0] =='+')
            {
                return string.Format("+{0}({1}){2}-{3}-{4}", phone.Substring(1, 1), phone.Substring(2, 3), phone.Substring(5, 3), phone.Substring(8, 2), phone.Substring(10, 2));
            }

            return phone;
        }



    }
}
