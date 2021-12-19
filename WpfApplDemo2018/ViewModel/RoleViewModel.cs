﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApplDemo2018.Helper;
using WpfApplDemo2018.Model;
using WpfApplDemo2018.View;

namespace WpfApplDemo2018.ViewModel
{
    public class RoleViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// выбранная в списке должность
        /// </summary>
        private Role selectedRole; 
        /// <summary>
        /// коллекция должностей сотрудников
        /// </summary>
        public ObservableCollection<Role> ListRole { get; set; } = new ObservableCollection<Role>();

        /// <summary>
        /// выбранная в списке должность
        /// </summary>
        public Role SelectedRole
        {
            get
            {
                return selectedRole;
            }
            set
            {
                selectedRole = value;
                OnPropertyChanged("SelectedRole");
                EditRole.CanExecute(true);
            }
        }

        public RoleViewModel()
        {
            this.ListRole.Add(new Role
            {
                Id = 1,
                NameRole = "Директор"
            });

            this.ListRole.Add(new Role
            {
                Id = 2,
                NameRole = "Бухгалтер"
            });

            this.ListRole.Add(new Role
            {
                Id = 3,
                NameRole = "Менеджер"
            });
        }

        /// <summary>
        /// Нахождение максимального Id в коллекции
        /// </summary>
        /// <returns></returns>
        public int MaxId()
        {
            int max = 0;
            foreach (var r in this.ListRole)
            {
                if (max < r.Id)
                {
                    max = r.Id;
                };
            }
            return max;
        }

        #region command AddRole

        /// команда добавления новой должности
        private RelayCommand addRole;
        public RelayCommand AddRole
        {
            get
            {
                return addRole ??
                       (addRole = new RelayCommand(obj =>
                       {
                           WindowNewRole wnRole = new WindowNewRole
                           {
                               Title = "Новая должность",
                           };
                           // формирование кода новой должности
                           int maxIdRole = MaxId() + 1;
                           Role role = new Role{Id = maxIdRole};
                           wnRole.DataContext = role;
                           if (wnRole.ShowDialog() == true)
                           {
                               ListRole.Add(role);
                           }
                           SelectedRole = role;
                       },
                           (obj) => true));
            }
        }

        #endregion

        #region Command EditRole 

        /// команда добавления новой должности
        private RelayCommand editRole;
        public RelayCommand EditRole
        {
            get
            {
                return editRole ??
                       (editRole = new RelayCommand(obj =>
                       {
                           WindowNewRole wnRole = new WindowNewRole
                           {
                               Title = "Редактирование должности",
                           };

                           Role role = SelectedRole;
                           Role tempRole = new Role();
                           tempRole = role.ShallowCopy();
                           wnRole.DataContext = tempRole;
                           if (wnRole.ShowDialog() == true)
                           {
                               // сохранение данных в оперативной памяти
                               role.NameRole = tempRole.NameRole;
                           }
                       }, (obj) => SelectedRole != null && ListRole.Count > 0));
            }
        }

        #endregion

        #region DeleteRole

        /// команда добавления новой должности
        private RelayCommand deleteRole;
        public RelayCommand DeleteRole
        {
            get
            {
                return deleteRole ??
                       (deleteRole = new RelayCommand(obj =>
                       {
                           Role role = SelectedRole;
                           MessageBoxResult result = MessageBox.Show("Удалить данные по должности: " + role.NameRole,
                               "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                           if (result == MessageBoxResult.OK)
                           {
                               ListRole.Remove(role);
                           }
                      }, (obj) => SelectedRole != null && ListRole.Count > 0));
            }
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
