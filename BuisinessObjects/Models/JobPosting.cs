using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candidate_BuisinessObjects.Models
{
    public partial class JobPosting
    {
        public JobPosting()
        {
            CandidateProfiles = new HashSet<CandidateProfile>();
        }

        public string PostingId { get; set; } = null!;
        [Required(ErrorMessage = "Title is required.")]
        public string JobPostingTitle { get; set; } = null!;
        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "PostedDate is required.")]
        [DataType(DataType.Date)]
        public DateTime? PostedDate { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
    }
}
