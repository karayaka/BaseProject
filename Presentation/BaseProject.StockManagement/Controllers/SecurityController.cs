using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseProject.Domain.DTO.SecurityDTO;
using Microsoft.AspNetCore.Mvc;


namespace BaseProject.StockManagement.Controllers
{
    public class SecurityController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginDTO model)
        {
            return View();
        }
    }
}

