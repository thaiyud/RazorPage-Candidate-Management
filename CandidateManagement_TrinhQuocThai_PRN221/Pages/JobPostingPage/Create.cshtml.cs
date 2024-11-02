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

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.JobPostingPage
{
    public class CreateModel : PageModel
    {
        private readonly IJobPostingService jobPostingService;

        public CreateModel(IJobPostingService context)
        {
            jobPostingService = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;



        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || jobPostingService.GetJobPostings() == null || JobPosting == null)
            {
                return Page();
            }
            var existedJobPosting = jobPostingService.GetJobPosting(JobPosting.PostingId);
            if (existedJobPosting != null)
            {
                ModelState.AddModelError("JobPosting.PostingId", "A job post with this ID already exists.");
                return Page();
            }
            jobPostingService.AddJobPosting(JobPosting);
            return RedirectToPage("./Index");
        }
    }
}
