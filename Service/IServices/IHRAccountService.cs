﻿using Candidate_BuisinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Service.IServices
{
    public interface IHRAccountService
    {
        public Hraccount GetHraccountByEmail(string email);
        public List<Hraccount> GetHraccountByEmail();
        public bool UpdateHrAccount(string email, string fullName, string password);

    }
}
