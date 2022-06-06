
using _0_FrameWork.Domain;
using AccountManagement.Application.Contraccts.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository :IRepository<long, Account>
    {
        EditAccount GetDetails(long id);
        List<AccountViewModel> serach(AccountSearchModel command);
    }
}
