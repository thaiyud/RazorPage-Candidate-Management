using Candidate_BuisinessObjects.Models;
using Candidate_Repository.IRepositories;
using Candidate_Repository.Repositories;
using Candidate_Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service.Services
{
    public class HRAccountService : IHRAccountService
    {
        private readonly IHRAccountRepo HRAccountRepo;
        public HRAccountService()
        {
            HRAccountRepo = new HRAccountRepo();
        }
        public Hraccount GetHraccountByEmail(string email)
        {
           return HRAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccountByEmail()
        {
            return HRAccountRepo.GetHraccounts();
        }
        public bool UpdateHrAccount(string email, string fullName, string password) => HRAccountRepo.UpdateHrAccount(email, fullName, password);
    }
}
