using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCoreBaseDemo.DBEntity.Base
{
   public abstract class RootEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
