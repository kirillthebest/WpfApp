using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApplDemo2018.Annotations;
using WpfApplDemo2018.ViewModel;

namespace WpfApplDemo2018.Model
{
    /// <summary>
    /// класс отображения данных по сотруднику
    /// </summary>
    public class PersonDpo: INotifyPropertyChanged
    {
        /// <summary>
        /// код сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// должность сотрудника
        /// </summary>
        private string _roleName;
        /// <summary>
        /// должность сотрудника
        /// </summary>
        public string RoleName
        {
            get { return _roleName; }
            set
            {
                _roleName = value;
                OnPropertyChanged("RoleName");
            }
        }

        /// <summary>
        /// имя сотрудника
        /// </summary>
        private string firstName;
        /// <summary>
        /// имя сотрудника
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// фамилия сотрудника
        /// </summary>
        private string lastName;
        /// <summary>
        /// фамилия сотрудника
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// дата рождения сотрудника
        /// </summary>
        private DateTime birthday;
        /// <summary>
        /// дата рождения сотрудника
        /// </summary>
        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public PersonDpo() { }

        public PersonDpo(int id, string roleName, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.RoleName = roleName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }

        /// <summary>
        /// Метод поверхностного копирования 
        /// </summary>
        /// <returns></returns>
        public PersonDpo ShallowCopy()
        {
            return (PersonDpo)this.MemberwiseClone();
        }

        /// <summary>
        /// копирование данных из класса Person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonDpo CopyFromPerson(Person person)
        {
            PersonDpo perDpo = new PersonDpo();
            RoleViewModel vmRole = new RoleViewModel();
            string role = string.Empty;
            foreach (var r in vmRole.ListRole)
            {
                if (r.Id == person.RoleId)
                {
                    role = r.NameRole;
                    break;
                }
            }
            if (role != string.Empty)
            {
                perDpo.Id = person.Id;
                perDpo.RoleName = role;
                perDpo.FirstName = person.FirstName;
                perDpo.LastName = person.LastName;
                perDpo.Birthday = person.Birthday;
            }
            return perDpo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
