//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TAgency
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale
    {
        public int sale_ID { get; set; }
        public int client_ID { get; set; }
        public System.DateTime sale_date { get; set; }
        public int tour_ID { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
