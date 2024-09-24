using System;
using System.Collections.Generic;
using System.Text;

namespace App.Utility
{
   /// <summary>
   /// sử dụng chung cho các response từng platform
   /// </summary>
   public class PlatformResponse<T>
   {
      public T Data { get; set; }
      public bool Success { get; set; }
   }
}
