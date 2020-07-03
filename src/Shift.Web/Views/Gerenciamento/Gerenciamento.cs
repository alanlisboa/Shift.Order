using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shift.Web.Views.Gerenciamento
{
    public static class Gerenciamento
    {
        public static string Convenio => "Convenio";

        public static string Exame => "Exame";

        public static string Medico => "Medico";

        public static string Paciente => "Paciente";

        public static string Posto => "Posto";

        public static string ConvenioNavClass(ViewContext viewContext) => PageNavClass(viewContext, Convenio);

        public static string ExameNavClass(ViewContext viewContext) => PageNavClass(viewContext, Exame);

        public static string MedicoNavClass(ViewContext viewContext) => PageNavClass(viewContext, Medico);

        public static string PacienteNavClass(ViewContext viewContext) => PageNavClass(viewContext, Paciente);

        public static string PostoNavClass(ViewContext viewContext) => PageNavClass(viewContext, Posto);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
