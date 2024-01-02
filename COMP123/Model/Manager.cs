using static COMP123.Utility.Parameters;

namespace COMP123.Model
{
    public class Manager : Staff
    {
        public Manager(string name, string staffId, string email, string password, bool isActive) : base(name, staffId, email, (int)(Roles)Roles.Manager, password, isActive) { }

        public override Encryption GetDashBoardRecords<Encryption>()
        {
            return new Encryption();
        }

    }
}
