using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account :EntityBase
    {
       

        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public string Mobile { get; private set; }
        public long RolId { get; private set; }
        public string ProfilePhoto { get; private set; }


        public Account(string fullName, string userName, string passWord, string mobile, long rolId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            PassWord = passWord;
            Mobile = mobile;
            RolId = rolId;
            ProfilePhoto = profilePhoto;
        }

        public void Edit(string fullName, string userName, string mobile, long rolId, string profilePhoto)
        {
            FullName = fullName;
            UserName = userName;
            Mobile = mobile;
            RolId = rolId;
            if(!string.IsNullOrWhiteSpace(profilePhoto))
            ProfilePhoto = profilePhoto;
        }

        public void ChangePassWord(string password)
        {
            PassWord = password;
        }
    }
}
