
using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contraccts.Account
{
    public interface IAccountApplication
    {
        OperationResult Careat(CreateAccount command);
        OperationResult Edit(EditAccount command);
        EditAccount GetDetails(long id);
        OperationResult ChangePassword(ChangePassword command);
        List<AccountViewModel> serach(AccountSearchModel searchmodel);
    }
}
