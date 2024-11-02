using Candidate_BuisinessObjects.Models;

namespace Candidate_DAO
{
    public class HRAccountDAO
    {
        private CandidateManagementContext dbContext;
        private static HRAccountDAO instance = null;

        public static HRAccountDAO Instance 
        { 
            get
            {
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                    return instance;
            }
        }
        public HRAccountDAO() { 
        dbContext = new CandidateManagementContext();

                }
        public Hraccount GetHraccount(string email) {
            return dbContext.Hraccounts.SingleOrDefault(m => m.Email.Equals(email));
        }
        public List<Hraccount> GetHraccounts()
        {
         return dbContext.Hraccounts.ToList();
        }

        public bool UpdateHrAccount(string email, string fullName, string password)
        {
            bool isSuccess = false;
            Hraccount? hraccount = GetHraccount(email);
            try
            {
                if (hraccount != null)
                {
                    hraccount.FullName = fullName;
                    hraccount.Password = password;
                    dbContext.Entry(hraccount).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                    dbContext.Entry(hraccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

    }
}
