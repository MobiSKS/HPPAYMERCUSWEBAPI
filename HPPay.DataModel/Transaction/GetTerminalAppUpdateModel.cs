using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HPPay.DataModel.Transaction
{
    public class GetTerminalAppUpdateModelInput: BaseClassTerminal
    {

        [Required]
        [JsonPropertyName("TerminalId")]
        [DataMember]
        public string TerminalId { get; set; }
    }

    public class GetTerminalAppUpdateModelOutput : BaseClassOutput
    {

     
    }
}
