using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatties.DTO.Tools.Mailing
{
    class Email
    {
        /// <summary>
        /// 
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsBodyHtml { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string To { get; set; }
    }
}
