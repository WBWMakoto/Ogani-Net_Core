using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication1.Data.Entities;

namespace WebApplication1.Areas.Identity.Pages.Account.Manage
{
    public class DownloadPersonalDataModel : PageModel
    {
        private readonly UserManager<ManageUser> _userManager;
        private readonly ILogger<DownloadPersonalDataModel> _logger;

        public DownloadPersonalDataModel(
            UserManager<ManageUser> userManager,
            ILogger<DownloadPersonalDataModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Lấy entity user từ database
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            // Ghi log
            _logger.LogInformation("User with ID '{UserId}' asked for their personal data.", _userManager.GetUserId(User));

            // Only include personal data for download / Chuẩn bị dữ liệu
            var personalData = new Dictionary<string, string>();
            var personalDataProps = typeof(ManageUser).GetProperties()
                        .Where(prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));
            foreach (var p in personalDataProps)
            {
                personalData[p.Name] = p.GetValue(user)?.ToString() ?? "null";
            }

            //ghi thêm các login providers
            var logins = await _userManager.GetLoginsAsync(user);
            foreach (var l in logins)
            {
                personalData[$"{l.LoginProvider} external login provider key"] = l.ProviderKey;
            }

             // Serialize ra byte[]
            var fileContents = JsonSerializer.SerializeToUtf8Bytes(personalData);

            // Trả FileContentResult và thiết lập FileDownloadName
            // => ASP.NET Core sẽ tự thêm header Content-Disposition: attachment; filename=...
            var result = new FileContentResult(fileContents, "application/json")
            {
                FileDownloadName = $"PersonalData_{_userManager.GetUserId(User)}.json"
            };

            return result;
        }
    }
}
