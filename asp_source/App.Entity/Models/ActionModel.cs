using App.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using TFU.Common;

namespace App.Entity.Models
{
  public class ActionModel : IEntity<SYS_ActionDTO>
   {
      public int Id { get; set; }
      [Required(ErrorMessage = Constants.Required)]
      public string Name { get; set; }
      [Required(ErrorMessage = Constants.Required)]
      public string ActionCode { get; set; }
      public string Description { get; set; }
      public string MethodType { get; set; }
      public string ApiUrl { get; set; }
      public ActionModel() { }
      public ActionModel(SYS_ActionDTO dto)
      {
         Id = dto.Id;
         Name = dto.Name;
         ActionCode = dto.ActionCode;
      }
      public SYS_ActionDTO GetEntity()
      {
         return new SYS_ActionDTO
         {
            Id = Id,
            Name = Name,
            ActionCode = ActionCode,
         };
      }
   }
}
