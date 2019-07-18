using Microsoft.AspNetCore.Mvc;
using PlinxApplicationForm.Data;
using PlinxApplicationForm.Helpers;
using PlinxApplicationForm.Models;
using System.Threading.Tasks;

namespace PlinxApplicationForm.Controllers
{
    public class ApplicationFormModelsController : Controller
    {

        public readonly IHttpManager _httpManager;
        public ApplicationFormModelsController(IHttpManager httpManager )
        {
            _httpManager = httpManager;
        }
   
        // GET: ApplicationFormModels
        public IActionResult Index()
        {
            return View();
        }        

        // GET: ApplicationFormModels/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult ConfirmationPage()
        {
            return View();
        }   

        // POST: ApplicationFormModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,FirstName,Surname,FirstContactDate,LastUpdateDate,CompanyName,PhoneNumber,MobileNumber,EmailAddress,Postcode,PropertyNumber,PropertyName,AddressLine1,AddressLine2,Town,County,TemplateId,PrimaryColor,SecondaryColour,Base64Logo")] ApplicationFormModel applicationFormModel)
        {
            if (ModelState.IsValid)
            {
                var response = _httpManager.Post(ModelMapper.Map(applicationFormModel));
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("ConfirmationPage");
                else
                {
                    ViewBag.errorMessage = "Error Posting orderform";
                    return View();
                }
            }

            return BadRequest();
        }

    }
}
