using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Application
{
  public  class OperationResult
    {
        public bool IsSuccedded { get; set; }
        public string Message { get; set; }

        public OperationResult()
        {
            IsSuccedded = false;
        }
        public OperationResult seccedded(string message ="عملایات با موفقیت انجام شد")
        {
            IsSuccedded = true;
            Message = message;
            return this;
        }

        public OperationResult Faild(string message = "عملایات با موفقیت انجام نشد")
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
