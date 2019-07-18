using System.Net.Http;
using System.Threading.Tasks;
using PlinxApplicationForm.Models;
using PlinxApplicationForm.Models.Request;

namespace PlinxApplicationForm.Data
{
    public interface IHttpManager
    {
        HttpResponseMessage Post(Customer applicationFormModel);
    }
}