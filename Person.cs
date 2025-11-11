using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Person :INotifyPropertyChanged
    {
        private string name;
        private int age;
        private DateTime birthDate = new DateTime(2000, 1,1);
        public string Name
        { get { return name; }
            set 
            { 
                name = value;
                OnPropertyChanged("Name");
            }
        }
        //public int Age
        //{
        //    get { return age; }
        //    set { 
        //        age = value;
        //        OnPropertyChanged("Age"); }
        //}
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
                OnPropertyChanged("Age");
            }
        }
        public int Age => DateTime.Now.Year - BirthDate.Year -
                 (DateTime.Now.DayOfYear < BirthDate.DayOfYear ? 1 : 0);
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
