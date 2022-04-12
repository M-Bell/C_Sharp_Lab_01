using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab01.Models
{
    public class DateModel
    {
        private DateTime _dateOfBirth;

        public DateModel(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
            }
        }



        internal string GetChineseZodiacSign()
        {
            return ((ChineseZodiacSigns)(_dateOfBirth.Year % 12)).ToString();
        }

        internal string GetWesternZodiacSign()
        {
            int signCode = _dateOfBirth.Date.Month - 1;
            int signStart = 0;
            switch (signCode)
            {
                case 1:
                    signStart = 19;
                    break;
                case 0:
                case 2:
                case 3:
                    signStart = 21;
                    break;
                case 4:
                case 5:
                case 11:
                    signStart = 22;
                    break;
                case 6:
                case 10:
                    signStart = 23;
                    break;
                case 7:
                case 8:
                case 9:
                    signStart = 24;
                    break;
            }
            if (_dateOfBirth.Date.Day >= signStart)
            {
                signCode++;
            }
            if (signCode >= 12) signCode = 0;
            return ((WesternZodiacSigns)signCode).ToString();
        }

        enum WesternZodiacSigns : ushort
        {
            Capricorn,
            Aquarius,
            Pisces,
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius
        }

        enum ChineseZodiacSigns
        {
            Monkey,
            Rooster,
            Dog,
            Pig,
            Rat,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Sheep
        }
    }
}
