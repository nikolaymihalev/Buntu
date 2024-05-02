using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Buntu.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
