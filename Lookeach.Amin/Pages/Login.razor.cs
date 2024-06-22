using Microsoft.AspNetCore.Components;
using Service.Services;

namespace Lookeach.Amin.Pages
{
    public partial class Login
    {
        [Inject]
        public IAdminService AdminService { get; set; }

    }
}
