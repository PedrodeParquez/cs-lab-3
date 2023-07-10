using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_work_3 {
  public class ExceptionsClass : Exception  {
    public ExceptionsClass() { }
    public ExceptionsClass(string Message) : base(Message) { }
    public ExceptionsClass(string Message, Exception Inner):
      base(Message, Inner) { }
  }
}
