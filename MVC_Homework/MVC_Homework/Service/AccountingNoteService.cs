using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Homework.Models;

namespace MVC_Homework.Service
{
    public class AccountingNoteService
    {
        private readonly Model1 dbContext;
        public AccountingNoteService()
        {
            dbContext = new Model1();
        }

        public void Add(AccountingNoteViewModel source)
        {
            var distin = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Categoryyy = int.Parse(source.CostType),
                Amounttt = source.CostMoney,
                Dateee = source.CostDate,
                Remarkkk = source.Remark
            };

            dbContext.AccountBook.Add(distin);
        }

        public IEnumerable<AccountBook> GetAll()
        {
            return dbContext.AccountBook.ToList();
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}