//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tests
{
    using System;
    using System.Collections.Generic;
    
    public partial class test_results
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public test_results()
        {
            this.test_answers = new HashSet<test_answers>();
        }
    
        public int test_result_id { get; set; }
        public Nullable<int> test_id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<int> mark { get; set; }
        public int test_duration_minutes { get; set; }
    
        public virtual student student { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<test_answers> test_answers { get; set; }
        public virtual test test { get; set; }
    }
}
