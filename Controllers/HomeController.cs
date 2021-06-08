using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleMVC5_0.Models;

namespace SampleMVC5_0.Controllers
{
    public class HomeController : Controller
    {
        private readonly GestionBanquesContext context;
        public HomeController(GestionBanquesContext _context)
        {
            context = _context;
        }
        public IActionResult Index()
        {
            return View("Banques", context.Banques);
        }

        public IActionResult ClientsBanque(int id)
        {
            return View("Clients", context.Clients.Where(c => c.Comptes.Where(cpt => cpt.BanqueId == id).ToList().Count > 0).ToList());
        }
    }
}
