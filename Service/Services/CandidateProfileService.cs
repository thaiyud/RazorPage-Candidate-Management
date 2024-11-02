using Candidate_BuisinessObjects.Models;
using Candidate_Service.IServices;
using Candidate_Repository.IRepositories;
using Candidate_Repository.Repositories;

namespace Candidate_Service.Services
{
    public class CandidateProfileService : ICandidateProfileService
    {
        private readonly ICandidateProfileRepo candidateProfileRepo;
        public CandidateProfileService()
        {
            candidateProfileRepo = new CandidateProfileRepo();
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return candidateProfileRepo.GetCandidateProfiles();
        }

        public (List<CandidateProfile> candidates, int totalItems, int totalPages) SearchCandidates(string? fullname, int pageNumber, int pageSize) => candidateProfileRepo.SearchCandidates(fullname, pageNumber, pageSize);


        public CandidateProfile GetCandidateProfileById(string id)
        {
            return candidateProfileRepo.GetCandidateProfileById(id);
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            return candidateProfileRepo.AddCandidateProfile(candidateProfile);
        }

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {

            return candidateProfileRepo.UpdateCandidateProfile(candidateProfile);
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            return candidateProfileRepo.DeleteCandidateProfile(candidateProfile);
        }
    }
}
