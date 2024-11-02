using Candidate_BuisinessObjects.Models;
using Candidate_Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_TrinhQuocThai_PRN221.Pages.Login
{
    public class IndexModel : PageModel
    {
        private readonly IHRAccountService _hrAccountService;
        public IndexModel(IHRAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }
        public void OnGet()
        {
        }
  
        public void OnPost()
        {
            string? email = Request.Form["txtEmail"];
            string? password = Request.Form["txtPassword"];
            if (email != null && password != null)
            {
                Hraccount account = _hrAccountService.GetHraccountByEmail(email);
                if (account != null && account.Password!.Equals(password))
                {
                    string? roleId = account.MemberRole.ToString() ?? "";
                    string? emailUser = account.Email ?? "";
                    HttpContext.Session.SetString("RoleID", roleId);
                    HttpContext.Session.SetString("EmailUser", email);
                    Response.Redirect("/CandidateProfilePage/index");
                }
                else
                    Response.Redirect("/Error");
            }

        }
        public void OnGetLogout()
        {
            HttpContext.Session.SetString("RoleID", "");
            Response.Redirect("/Login/LoginPage");
        }
    }
}
