using Adm_Agenda.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Adm_Agenda.ViewModel
{
    public class ContatoViewModel
    {
        private readonly Context_db _context;

        public ContatoViewModel()
        {
            Endereco = CarregaEnderecos();
        }

        public int id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? Telefone { get; set; }

        public int idEndereco { get; set; } 

        public List<SelectListItem> Endereco { get; set; }


        #region "Metodos"

        public List<SelectListItem> CarregaEnderecos()
        {
            var lista = new List<SelectListItem>();
            var enderecos = _context.DbSetEndereco.ToList();

            try
            {
                foreach (var endereco in enderecos)
                {
                    var option = new SelectListItem()
                    {
                        Text = endereco.Rua,
                        Value = endereco.IdEndereco.ToString()
                    };
                    lista.Add(option);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        #endregion


    }
}
