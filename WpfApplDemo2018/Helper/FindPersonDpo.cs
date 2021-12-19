using WpfApplDemo2018.Model;

namespace WpfApplDemo2018.Helper
{
    public class FindPersonDpo
    {
        private readonly int id;

        public FindPersonDpo(int id)
        {
            this.id = id;
        }

        public bool PersonDpoPredicate(PersonDpo person)
        {
            return person.Id == id;
        }
    }
}
