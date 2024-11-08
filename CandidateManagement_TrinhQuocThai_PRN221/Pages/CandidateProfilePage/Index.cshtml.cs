﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using Candidate_Service.IServices;
using Candidate_BuisinessObjects.Models;
using Candidate_Service.Services;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;

        public IndexModel(ICandidateProfileService context)
        {
            candidateProfileService = context;
        }

        public IList<CandidateProfile> CandidateProfiles { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public void OnGet(string fullname, DateTime? birthday, int pageNumber = 1, int pageSize =5)
        {
            var (items, totalItems, totalPages) = candidateProfileService.SearchCandidates(fullname, pageNumber, pageSize);

            CandidateProfiles = items;
            CurrentPage = pageNumber;
            TotalPages = totalPages;
        }
    }
}
