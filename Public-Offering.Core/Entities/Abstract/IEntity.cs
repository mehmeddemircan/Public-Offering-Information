using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public_Offering.Core.Entities.Abstract
{
    public interface IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
