using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Homework.Models;
using MVC_Homework.Service;

namespace MVC_Homework.Controllers.ViewModels
{
    public class AccountingController : Controller
    {
        private readonly AccountingNoteService _accountingNoteService;

        public AccountingController()
        {
            _accountingNoteService = new AccountingNoteService();
        }

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
                _accountingNoteService.Add(source);
                _accountingNoteService.Save();
            }
            return View();
        }


        [ChildActionOnly]
        public ActionResult ShowAccounting()
        {

            List<AccountingNoteViewModel> accountingNote = new List<AccountingNoteViewModel>();

            var fromDb = _accountingNoteService.GetAll();
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