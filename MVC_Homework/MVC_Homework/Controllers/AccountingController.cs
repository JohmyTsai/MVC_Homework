using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Homework.Models;

namespace MVC_Homework.Controllers.ViewModels
{
    public class AccountingController : Controller
    {
        // GET: Accounting
        public ActionResult Add()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult ShowAccounting()
        {

            List< AccountingNoteViewModel > accountingNote = new List<AccountingNoteViewModel>();
            Random Rnd = new Random();
            for (int i = 1; i < 100; i++)
            {
                
                var result = new AccountingNoteViewModel()
                {
                    CostType = "支出",
                    CostDate = DateTime.Now.AddDays(Rnd.Next(-100, 10)),
                    CostMoney = Rnd.Next(1, 10000),
                    Remark = "TEST"
                };
                accountingNote.Add(result);
            }

            return View(accountingNote);
        }
    }
}