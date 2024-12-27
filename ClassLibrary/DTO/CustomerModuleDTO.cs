using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DTO
{
    public class CustomerModuleDTO
    {

        public int Id { get; set; }


        public int CustomerId { get; set; }

 
        public int ModuleId { get; set; }


        public virtual CustomerDTO Customer { get; set; } = null!;

        public virtual ModuleDTO Module { get; set; } = null!;
    }
}
