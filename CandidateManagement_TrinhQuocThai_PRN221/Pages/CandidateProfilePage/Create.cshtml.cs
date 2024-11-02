using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Candidate_BuisinessObjects.Models;
using Candidate_DAO;
using Candidate_Service.IServices;
using Candidate_Service.Services;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.CandidateProfilePage
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileService candidateProfileService;
        private readonly IJobPostingService jobPostingService;

        public CreateModel(ICandidateProfileService candidateProfileService, IJobPostingService jobPostingService)
        {
            this.candidateProfileService = candidateProfileService;
            this.jobPostingService = jobPostingService;
        }

        public IActionResult OnGet()
        {
            ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || candidateProfileService.GetCandidateProfiles() == null || CandidateProfile == null)
            {
                ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
                return Page();
            }
            var existedCandidate = candidateProfileService.GetCandidateProfileById(CandidateProfile.CandidateId);
            if (existedCandidate != null)
            {
                ModelState.AddModelError("CandidateProfile.CandidateId", "This ID already exists.");
                ViewData["PostingId"] = new SelectList(jobPostingService.GetJobPostings(), "PostingId", "JobPostingTitle");
                return Page();
            }
            candidateProfileService.AddCandidateProfile(CandidateProfile);
            return RedirectToPage("./Index");
        }
    }
}
