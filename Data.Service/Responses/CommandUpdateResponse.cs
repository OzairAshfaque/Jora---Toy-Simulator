using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Response
{
    public class CommandUpdateResponse
    {
        public CommandUpdateDto ComandToExecute { get; set; }
        public CommandUpdateResponse()
        {
            ComandToExecute = new CommandUpdateDto();
        }

        
    }
}
