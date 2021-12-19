using WpfApplDemo2018.Model;

namespace WpfApplDemo2018.Helper
{
    /// <summary>
    /// предикат для нахождения должности по id
    /// </summary>
    public class FindRole
    {
        int id;
        public FindRole(int id)
        {
            this.id = id;
        }
        /// <summary>
        /// предикат
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool RolePredicate(Role role )
        {
            return role.Id == id;
        }
    }
}
