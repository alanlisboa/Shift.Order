using Shift.Core.Domain;
using Shift.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shift.Application.ViewModels
{
    public class OrdemServicoViewModel 
    {
        public Guid Id { get; set; }

        [DisplayName("Número")]
        public int Numero { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data")]
        public DateTime DataOrdem { get; set; }

        [Required(ErrorMessage = "Paciente é obrigatório")]
        public PacienteViewModel Paciente { get; set; }

        [DisplayName("Convênio")]
        [Required(ErrorMessage = "Convênio é obrigatório")]
        public ConvenioViewModel Convenio { get; set; }

        [DisplayName("Posto de Coleta")]
        [Required(ErrorMessage = "Posto de coleta é obrigatório")]
        public PostoColetaViewModel PostoColeta { get; set; }

        [DisplayName("Médico")]
        [Required(ErrorMessage = "Médico é obrigatório")]
        public MedicoViewModel Medico { get; set; }

        public List<OrdemServicoExameViewModel> Exames { get; set; }
    }
}
