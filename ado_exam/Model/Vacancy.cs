using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado_exam.Model
{
    public class Vacancy
    {
        [Key]
        public int VacancyId { get; set; }
        public string VacancyName { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime PublicDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
