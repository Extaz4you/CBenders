using CBenders.Web.Models.DTOs;
using CBenders.Web.Services.Clients;
using CBenders.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CBenders.Web.Controllers;

public class MenuController : Controller
{

    public async Task<ActionResult> Index()
    {
        return View();
    }
}
