using System;
using System.Collections.Generic;
using System.Text;

namespace App.Utility
{
   /// <summary>
   /// response api of giaohangnhanh
   /// </summary>
   public class GHNResponse<T>
   {
      public int Code { get; set; }
      public string Message { get; set; }
      public T Data { get; set; }
      public string Code_message { get; set; }
      public string Code_message_value { get; set; }
      public bool Success => Message.Equals("success", StringComparison.OrdinalIgnoreCase);
   }
}
