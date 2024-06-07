using ClinicBookingSystem_Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem_API.Controllers;

[ApiController]
[Route("/api/role")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }
    
}