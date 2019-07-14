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
        private Model1 db = new Model1();
        // GET: Accounting
        public ActionResult Add()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AccountingNoteViewModel source)
        {
            if (ModelState.IsValid)
            {
                var distin = new AccountBook()
                {
                    Id = Guid.NewGuid(),
                    Categoryyy = int.Parse(source.CostType),
                    Amounttt = source.CostMoney,
                    Dateee = source.CostDate,
                    Remarkkk = source.Remark
                };

                db.AccountBook.Add(distin);
                db.SaveChanges();
            }
            return View();
        }


        [ChildActionOnly]
        public ActionResult ShowAccounting()
        {

            List<AccountingNoteViewModel> accountingNote = new List<AccountingNoteViewModel>();

            var fromDb = db.AccountBook.ToList();
            foreach (var item in fromDb)
            {
                var result = new AccountingNoteViewModel()
                {
                    CostType = item.Categoryyy == CostTypeEnum.支出.GetHashCode() ? CostTypeEnum.支出.ToString() : CostTypeEnum.收入.ToString(),
                    CostDate = item.Dateee,
                    CostMoney = item.Amounttt,
                    Remark = item.Remarkkk
                };
                accountingNote.Add(result);
            }

            return View(accountingNote);
        }
    }
}