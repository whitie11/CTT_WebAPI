using System;
using System.Collections.Generic;

namespace WebApi.Entities2
{
    public partial class Types
    {
        public Types()
        {
            Appts = new HashSet<Appts>();
        }

        public int TypeId { get; set; }
        public string TypeText { get; set; }
        public string TypeCode { get; set; }
        public int? Order { get; set; }

        public virtual ICollection<Appts> Appts { get; set; }
    }
}
