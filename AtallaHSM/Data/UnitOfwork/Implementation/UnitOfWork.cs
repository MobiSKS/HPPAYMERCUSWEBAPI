using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtallaHSM.Data.UnitOfwork;
using AtallaHSM.Data.Repositories;

namespace AtallaHSM.Data.UnitOfwork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(

                          ITerminal terminalRepository
                         

                       )
        {

            TerminalRepository = terminalRepository;
           
        }


        public ITerminal TerminalRepository { get; }

      
    }
}
