using Candidate_BuisinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace Candidate_DAO
{
    public class CandidateProfileDAO
    {
        private CandidateManagementContext context;
        private static CandidateProfileDAO instance;

        public CandidateProfileDAO()
        {
            context = new CandidateManagementContext();
        }

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        public List<CandidateProfile> GetCandidateProfiles()
        {
            return context.CandidateProfiles.Include(cp => cp.Posting).ToList();
        }

        public CandidateProfile GetCandidate(string id)
        {

            var entity = context.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
            if (entity != null)
            {
                context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }
        public (List<CandidateProfile> candidates, int totalItems, int totalPages) SearchCandidates(string? fullname, int pageNumber, int pageSize)
        {
            var candidates = context.CandidateProfiles.Include(c => c.Posting).ToList();

            var query = candidates.AsQueryable();

            if (!string.IsNullOrWhiteSpace(fullname))
            {
                query = query.Where(c => c.Fullname.Contains(fullname));
            }

            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return (items, totalItems, totalPages);
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfileNew)
        {
            bool result = false;
            CandidateProfile candidateProfile = GetCandidate(candidateProfileNew.CandidateId);
            try
            {
                if (candidateProfile == null)
                {
                    context.CandidateProfiles.Add(candidateProfileNew);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
            
            }
            return result;
        }
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    context.Entry<CandidateProfile>(candidateProfile).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                  
                    result = true;
                }
            } 
            catch (Exception ex)
            {
              
            }
            return result;
        }
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = GetCandidate(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    context.CandidateProfiles.Remove(candidateProfile);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
