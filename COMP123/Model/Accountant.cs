using static COMP123.Utility.Parameters;

namespace COMP123.Model
{
    public class Accountant : Staff
    {
        public Accountant(string name, string staffId, string email, string password, bool isActive) : base(name, staffId, email, (int)(Roles)Roles.Accountant, password, isActive) { }

        public override Manager GetDashBoardRecords<Manager>()
        {
            return new Manager();
        }
    }
}
