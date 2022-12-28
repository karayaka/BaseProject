using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BaseProject.Application.Repositorys;
using BaseProject.Application.Services.SecurityServices;
using BaseProject.Domain.DTO.SecurityDTO;
using Microsoft.AspNetCore.Mvc;


namespace BaseProject.StockManagement.Controllers
{
    public class SecurityController : Controller
    {
        private readonly ISecurityRepository security;
        private readonly ISessionServices sessionService;
        private readonly IMapper mapper;

        public SecurityController(ISecurityRepository _security,ISessionServices _sessionService,IMapper _mapper)
        {
            security = _security;
            sessionService = _sessionService;
            mapper = _mapper;
        }
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
            var user = await security.Login(model);
            if (user == null)
            {
                ModelState.AddModelError("All", "Kullanıcı Adı Veya Şifre Hatalı");
            }

            sessionService.SetUser(user);
            //redireck index
            return View(model);
        }
    }
}

