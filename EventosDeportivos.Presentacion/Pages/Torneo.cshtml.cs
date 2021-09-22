using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EventosDeportivos.Presentacion.Pages
{
    public class TorneoModel : PageModel
    {
        private readonly ILogger<TorneoModel> _logger;

        public TorneoModel(ILogger<TorneoModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
