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
    
    public partial class test_answers
    {
        public int test_answer_id { get; set; }
        public Nullable<int> test_result_id { get; set; }
        public Nullable<int> question_id { get; set; }
        public int student_answer { get; set; }
    
        public virtual question question { get; set; }
        public virtual test_results test_results { get; set; }
    }
}
