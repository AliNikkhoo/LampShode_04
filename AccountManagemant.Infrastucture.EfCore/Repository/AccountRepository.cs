using _0_Framework.Application;
using _0_FrameWork.Domain;
using AccountManagement.Application.Contraccts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagemant.Infrastucture.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context; 
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount 
            {
                Id= x.Id,
                FullName= x.FullName,
                Mobile=x.Mobile,
                PassWord= x.PassWord,
                ProfilePhoto=x.ProfilePhoto,
                UserName=x.UserName,
                
            }).FirstOrDefault(x => x.Id == id) ;
        }

        public List<AccountViewModel> serach(AccountSearchModel searchmodel)
        {
            var query = _context.Accounts.Select(x => new AccountViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                UserName = x.UserName,
                RoleId = 2,
                Rol = "l",
                CreationDate = x.CreationDate.ToFarsi()
            }) ;

            if (!string.IsNullOrWhiteSpace(searchmodel.FullName))
                query = query.Where(x=>x.FullName.Contains(searchmodel.FullName));

            if (!string.IsNullOrWhiteSpace(searchmodel.UserName))
                query = query.Where(x => x.UserName.Contains(searchmodel.UserName));

            if (!string.IsNullOrWhiteSpace(searchmodel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchmodel.Mobile));

            if (searchmodel.RolId > 0)
                query = query.Where(x => x.RoleId == searchmodel.RolId);
            return query.OrderByDescending(x => x.Id).ToList();
        }


        EditAccount IAccountRepository.GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                PassWord = x.PassWord,
                ProfilePhoto = x.ProfilePhoto,
                UserName = x.UserName,
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
