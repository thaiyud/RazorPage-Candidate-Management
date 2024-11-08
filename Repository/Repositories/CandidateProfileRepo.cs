﻿using Candidate_BuisinessObjects.Models;
using Candidate_DAO;
using Candidate_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository.Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {

        public List<CandidateProfile> GetCandidateProfiles() => CandidateProfileDAO.Instance.GetCandidateProfiles();

        public CandidateProfile GetCandidateProfileById(string id) => CandidateProfileDAO.Instance.GetCandidate(id);

        public (List<CandidateProfile> candidates, int totalItems, int totalPages) SearchCandidates(string? fullname, int pageNumber, int pageSize) => CandidateProfileDAO.Instance.SearchCandidates(fullname, pageNumber, pageSize);
        public bool AddCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile) => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfile);

    }
}
