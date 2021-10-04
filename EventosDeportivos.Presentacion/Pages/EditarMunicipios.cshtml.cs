using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventosDeportivos.Dominio;
using EventosDeportivos.Persistencia;

namespace EventosDeportivos.Presentacion.Pages
{
    public class EditarMunicipiosModel : PageModel
    {
        private readonly IRepositorioMunicipio _repositorioMunicipio; // = new RepositorioMunicipio(new EventosDeportivos.Persistencia.AppContext());

        [BindProperty]
        public Municipio Municipio { get; set; }

        public EditarMunicipiosModel(IRepositorioMunicipio repositorioMunicipio)
        {
            //Constructor
            _repositorioMunicipio = repositorioMunicipio;
        }
        public ActionResult OnGet(int id)
        {
            Municipio = _repositorioMunicipio.BuscarMunicipio(id);
            return Page();
        }
    }
}
