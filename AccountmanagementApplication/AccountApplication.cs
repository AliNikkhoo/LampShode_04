
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contraccts.Account;
using AccountManagement.Domain.AccountAgg;
using System.Collections.Generic;

namespace AccountmanagementApplication
{
    public class AccountApplication : IAccountApplication
    {

        private readonly IPasswordHasher _passwordHasher;
        private readonly IAccountRepository _accountRepository;
        public AccountApplication(IAccountRepository accountRepository, IPasswordHasher passwordHasher
           )
        {
           _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
           
        }
        public OperationResult Careat(CreateAccount command)
        {
            OperationResult operation = new OperationResult();
            if (_accountRepository.Exists(x => x.UserName == command.UserName || x.Mobile == command.Mobile))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

         
            
            var password = _passwordHasher.Hash(command.PassWord);
            var account = new Account(command.FullName, command.UserName,
                password, command.Mobile,command.RolId,command.ProfilePhoto);

            _accountRepository.Creat(account);
            _accountRepository.SaveChanges();
           return operation.seccedded();

        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            OperationResult operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if(account == null)
                return operation.Faild(ApplicationMessages.RecordNontFound);
            if(command.Password != command.RePassword)
                return operation.Faild(ApplicationMessages.RecordNontFound);
            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassWord(password);
            _accountRepository.SaveChanges();
            return operation.seccedded();

        }

        public OperationResult Edit(EditAccount command)
        {
            OperationResult operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Faild(ApplicationMessages.RecordNontFound);

            if (_accountRepository.Exists(x =>( x.UserName == command.UserName 
                                                || x.Mobile == command.Mobile) &&x.Id==command.Id))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            account.Edit(command.FullName, command.UserName, 
                command.Mobile, command.RolId, command.ProfilePhoto);
            _accountRepository.SaveChanges();
            return operation.seccedded();
            ;
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> serach(AccountSearchModel searchmodel)
        {
            return _accountRepository.serach(searchmodel);
        }
    }
}
