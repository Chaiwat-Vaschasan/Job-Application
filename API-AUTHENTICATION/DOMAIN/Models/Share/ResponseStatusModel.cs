using System;
using System.Collections.Generic;
using System.Text;

namespace DOMAIN.Models.Share
{
    public class ResponseStatusModel
    {
        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
