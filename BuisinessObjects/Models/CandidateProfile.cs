using System.ComponentModel.DataAnnotations;

namespace Candidate_BuisinessObjects.Models
{
    public partial class CandidateProfile
    {
        public string CandidateId { get; set; } = null!;

        [Required(ErrorMessage = "Fullname is required.")]
        public string Fullname { get; set; } = null!;

        [Required(ErrorMessage = "Birthday is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        [CustomValidation(typeof(CandidateProfile), nameof(ValidateBirthday))]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Profile description is required.")]
        [Display(Name = "Profile Description")]
        public string? ProfileShortDescription { get; set; }

        [Required(ErrorMessage = "Profile URL is required.")]
        [Display(Name = "Profile URL")]
        public string? ProfileUrl { get; set; }

        public string? PostingId { get; set; }

        public virtual JobPosting? Posting { get; set; }

        public static ValidationResult? ValidateBirthday(DateTime birthday, ValidationContext context)
        {
            return birthday < DateTime.Now
                ? ValidationResult.Success
                : new ValidationResult("Birthday must be in the past.");
        }
    }

}
