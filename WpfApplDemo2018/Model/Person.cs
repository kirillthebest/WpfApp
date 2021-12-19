using System;
using WpfApplDemo2018.ViewModel;

namespace WpfApplDemo2018.Model
{
    /// <summary>
    /// Класс сотрудник
    /// </summary>
    public class Person
    {
        /// <summary>
        /// код сотрудника
        /// </summary>
        public  int Id { get; set;}              // код
        /// <summary>
        /// код должности сотрудника
        /// </summary>
        public int RoleId { get; set; }          // код должности
        /// <summary>
        /// имя сотрудника
        /// </summary>
        public string FirstName { get; set; }    // имя
        /// <summary>
        /// фамилия сотрудника
        /// </summary>
        public string LastName { get; set; }     // фамилия
        /// <summary>
        /// дата рождения сотрудника
        /// </summary>
        public DateTime Birthday { get; set; }   // дата рождения

        public Person() { }

        public Person(int id, int roleId, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.RoleId = roleId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }

        /// <summary>
        /// Метод поверхностного копирования 
        /// </summary>
        /// <returns></returns>
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        /// <summary>
        /// копирование данных из класса PersonDPO
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Person CopyFromPersonDPO(PersonDpo p)
        {
            RoleViewModel vmRole = new RoleViewModel();
            int roleId = 0;
            foreach (var r in vmRole.ListRole)
            {
                if (r.NameRole == p.RoleName)
                {
                    roleId = r.Id;
                    break;
                }
            }
            if (roleId != 0)
            {
                this.Id = p.Id;
                this.RoleId = roleId;
                this.FirstName = p.FirstName;
                this.LastName = p.LastName;
                this.Birthday = p.Birthday;
            }
            return this;
        }
    }
}
