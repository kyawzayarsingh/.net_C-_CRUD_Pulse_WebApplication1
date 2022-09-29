using MVCCrudCodeFirst.interfaces;

namespace MVCCrudCodeFirst.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        public int GetTotalStudent()
        {
            return 10;
        }
    }
}