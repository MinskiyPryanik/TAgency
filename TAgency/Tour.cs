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
    
    public partial class Tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tour()
        {
            this.Sale = new HashSet<Sale>();
        }
    
        public int tour_ID { get; set; }
        public string tour_name { get; set; }
        public System.DateTime date_start { get; set; }
        public System.DateTime date_end { get; set; }
        public int tour_type_ID { get; set; }
        public int food_type_ID { get; set; }
        public byte[] tour_image { get; set; }
        public int hotel_ID { get; set; }
        public int count_tickets { get; set; }
        public int price { get; set; }
    
        public virtual Food_Type Food_Type { get; set; }
        public virtual Hotel Hotel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }
        public virtual Tour_Type Tour_Type { get; set; }
    }
}
