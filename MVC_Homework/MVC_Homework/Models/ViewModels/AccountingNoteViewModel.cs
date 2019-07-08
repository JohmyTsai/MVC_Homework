using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Homework.Models
{
    public class AccountingNoteViewModel
    {
        [Display(Name = "類別")]
        [Required(AllowEmptyStrings = false)]
        public string CostType  { get; set; }
        [Display(Name = "日期")]
        public DateTime CostDate { get; set; }
        [Display(Name = "金額")]
        public int CostMoney { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
    }
}