﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TFU.Common.Models
{
  public class Recursively
   {
      public long ParentId { get; set; }
      public long Id { get; set; }
      public string Name { get; set; }
      public int Index { get; set; }
      public bool IsDisabled { get; set; }
      public List<Recursively> Childs { get; set; }
   }
}
