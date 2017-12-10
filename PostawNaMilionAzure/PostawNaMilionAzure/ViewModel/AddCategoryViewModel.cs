using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.ViewModel
{
    public class AddCategoryViewModel
    {
        public CategoryDict CategoryDict { get; set; }
        public IEnumerable<KnowledgeArea> KnowledgeAreaList { get; set; }

        public string NameAction { get; set;}
    }
}