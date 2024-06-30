using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lead_LandingPage.Models
{
    public class ClsLeadsForm
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(255)]
        public string NOMBRE { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
        [StringLength(255)]
        public string EMAIL { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(50)]
        public string TELEFONO { get; set; }

        [Required(ErrorMessage = "La empresa es obligatoria.")]
        [StringLength(255)]
        public string EMPRESA { get; set; }
    }
}