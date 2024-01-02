using static COMP123.Utility.Parameters;

namespace COMP123.Model
{
    public class Admin : Staff
    {
        public Admin(string name, string staffId, string email, string password, bool isActive) : base(name, staffId, email, (int)(Roles)Roles.Admin, password, isActive) { }

        public override Accountant GetDashBoardRecords<Accountant>()
        {
            return new Accountant();
        }
    }
}
