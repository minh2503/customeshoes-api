using App.Entity.DTO;
using TFU.Common;
namespace App.Entity.Models
{
	public class MuscleModel : IEntity<App_MuscleDTO>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Thumbnail { get; set; }
		public int OrderNumber { get; set; }
        public MuscleModel()
		{

		}
		public MuscleModel(App_MuscleDTO dTO)
		{
			Id = dTO.Id;
			Name = dTO.Name;
			Thumbnail = dTO.Thumbnail;
			OrderNumber = dTO.OrderNumber;
		}
		public App_MuscleDTO GetEntity()
		{
			return new App_MuscleDTO
			{
				Id = Id,
				Name = Name,
				Thumbnail = Thumbnail,
				OrderNumber = OrderNumber
			};
		}
	}
}
