using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Filters
{
  public class TFUActionRequirement : IAuthorizationRequirement
  {
    public string FunctionCode { get; private set; }
    public string ActionCode { get; private set; }

    public TFUActionRequirement(string fnc, string act)
    {
      FunctionCode = fnc;
      ActionCode = act;
    }
  }
  
  public class TFUEmailConfirmRequirement : IAuthorizationRequirement
  {
  }
  
  public class TFURoleRequirement : IAuthorizationRequirement
  {
    public string Roles { get; private set; }
    public TFURoleRequirement(string roles)
    {
      Roles = roles;
    }
  }
}
