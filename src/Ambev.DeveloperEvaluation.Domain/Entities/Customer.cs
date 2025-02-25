using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
    }
}
