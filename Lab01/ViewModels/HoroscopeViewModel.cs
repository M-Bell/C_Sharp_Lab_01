using GalaSoft.MvvmLight.Command;
using Lab01.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Lab01.ViewModels
{
    public class HoroscopeViewModel : INotifyPropertyChanged
    {
        private DateModel _date;

        public DateTime Date
        {
            get
            {
                return _date.DateOfBirth;
            }
            set
            {
                _date = new DateModel(value);
            }
        }

        private RelayCommand<object> _submitCommand;
        public RelayCommand<object> SubmitCommand
        {
            get
            {
                return _submitCommand ??= new RelayCommand<object>(_ => Refresh(), CanExecute);
            }
        }

        private bool CanExecute(object arg)
        {
            if (_date == null) return false;
            DateTime lowerLimit = new DateTime(DateTime.Now.Year - 135, DateTime.Now.Month, DateTime.Now.Day);
            if (_date.DateOfBirth.CompareTo(lowerLimit) < 0)
            {
                MessageBox.Show($"ERROR\nAren't you too old for this...?");
                return false;
            }
            else if (DateTime.Now.CompareTo(_date.DateOfBirth) < 0)
            {
                MessageBox.Show($"ERROR\nYou couldn't even be born");
                return false;
            }
            return true;
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        internal void Refresh()
        {
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(WesternZodiacSign));
            OnPropertyChanged(nameof(ChineseZodiacSign));
            OnPropertyChanged(nameof(Greeting));
            MessageBox.Show($"Changes applied :)");
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
