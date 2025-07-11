using CBenders.Web.Models.DTOs;
using CBenders.Web.Services.Clients;
using CBenders.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CBenders.Web.Controllers;

public class MenuController : Controller
{
    private IApiClient<MenuDto, int> apiClient;

    public MenuController(MenuClient menuClient)
    {
        apiClient = menuClient;
    }
    public async Task<ActionResult> Index()
    {
        var x = await apiClient.All();
        return View();
    }
}
