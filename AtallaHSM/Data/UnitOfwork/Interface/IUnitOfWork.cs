using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtallaHSM.Data.Repositories;

namespace AtallaHSM.Data.UnitOfwork
{
    public interface IUnitOfWork
    {
        ITerminal TerminalRepository { get; }
    }
}
