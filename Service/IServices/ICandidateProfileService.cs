using Candidate_BuisinessObjects.Models;

namespace Candidate_Service.IServices
{
    public interface ICandidateProfileService
    {
        public List<CandidateProfile> GetCandidateProfiles();
        public (List<CandidateProfile> candidates, int totalItems, int totalPages) SearchCandidates(string? fullname, int pageNumber, int pageSize);
        public CandidateProfile GetCandidateProfileById(string id);
        public bool AddCandidateProfile(CandidateProfile candidateProfile);
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile);
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile);
    }
}
