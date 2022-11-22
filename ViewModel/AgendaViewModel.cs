using Adm_Agenda.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Adm_Agenda.ViewModel
{
    public class AgendaViewModel
    {
        private readonly Context_db _context;

        public AgendaViewModel()
        {
            Contatos = CarregaContatos();
        }

        public int id { get; set; }
        public string? nome { get; set; }
        public List<SelectListItem> Contatos { get; set; }

        #region "Metodos"

        public List<SelectListItem> CarregaContatos()
        {
            var lista = new List<SelectListItem>();
            var lstContatos = _context.DbSetContatos.ToList();

            try
            {
                foreach (var item in lstContatos)
                {
                    var option = new SelectListItem()
                    {
                        Text = item.Nome,
                        Value = item.IdContato.ToString()
                    };
                    lista.Add(option);
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return lista;
        }

        #endregion
    }
}