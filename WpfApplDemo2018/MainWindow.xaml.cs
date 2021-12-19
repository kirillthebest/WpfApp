using System.Windows;
using WpfApplDemo2018.View;
using WpfApplDemo2018.ViewModel;

namespace WpfApplDemo2018
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int IdEmployee { get; set; }
        public static int IdRole { get; set; }
        public static RoleViewModel VmRole { get; set; }
        public static PersonViewModel VmPerson { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            VmRole = new RoleViewModel();
        }

        private void Employee_OnClick(object sender, RoutedEventArgs e)
        {
            WindowEmployee wEmployee = new WindowEmployee();
            wEmployee.Show();
        }

        private void Role_OnClick(object sender, RoutedEventArgs e)
        {
            WindowRole wRole = new WindowRole();
            wRole.Show();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
