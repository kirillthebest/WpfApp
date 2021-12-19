using System.Windows;
using WpfApplDemo2018.Model;
using WpfApplDemo2018.ViewModel;

namespace WpfApplDemo2018.View
{
    /// <summary>
    /// Логика взаимодействия для WindowNewRole.xaml
    /// </summary>
    public partial class WindowNewRole : Window
    {
        private RoleViewModel vmRole;
        public Role NewRole { get; set; }

        public WindowNewRole()
        {
            InitializeComponent();
        }

        /// <summary>
        /// сохранение данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
