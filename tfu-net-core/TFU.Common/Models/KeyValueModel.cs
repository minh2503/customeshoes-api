﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TFU.Common.Models
{
   public class KeyValueModel
   {
      public KeyValueModel(long id, string name, string value)
      {
         Id = id;
         Name = name;
         Value = value;
      }
      public long Id { get; set; }
      public string Name { get; set; }
      public string Value { get; set; }
   }
}
