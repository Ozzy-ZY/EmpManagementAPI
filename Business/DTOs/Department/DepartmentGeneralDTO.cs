using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Department
{
    public class DepartmentGeneralDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? ManagerId { get; set; } = 0;
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
