using Lab01.Models;
using System;
using System.Windows;

namespace Lab01.ViewModels
{
    public class HoroscopeViewModel
    {
        private DateModel _date;

        public HoroscopeViewModel(DateTime dateOfBirth)
        {
            _date = new DateModel(dateOfBirth);
        }

        public string Age
        {
            get
            {
                int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                int dob = int.Parse(_date.DateOfBirth.ToString("yyyyMMdd"));
                int age = (now - dob) / 10000;
                return age.ToString();
            }
        }
        public string WesternZodiacSign
        {
            get
            {
                return _date.GetWesternZodiacSign();
            }
        }

        public string ChineseZodiacSign
        {
            get
            {
                return _date.GetChineseZodiacSign();
            }
        }

        internal void refresh(DateTime value)
        {
            DateTime lowerLimit = new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day);
            if (value.CompareTo(lowerLimit) < 0)
            {
                MessageBox.Show($"ERROR\nAren't you too old for this...?");
            }
            else if (DateTime.Now.CompareTo(value) < 0)
            {
                MessageBox.Show($"ERROR\nYou couldn't even be born");
            }
            else
            {
                _date.DateOfBirth = value;
                MessageBox.Show($"Changes applied :)");
            }
        }

        public string Greeting
        {
            get
            {
                if (_date.DateOfBirth.Day == DateTime.Now.Day
                    && _date.DateOfBirth.Month == DateTime.Now.Month)
                    return "Congratulations!!! All Silpo discounts are for you today";
                return "Just an ordinary day for unordinary you";
            }
        }

    }
}
