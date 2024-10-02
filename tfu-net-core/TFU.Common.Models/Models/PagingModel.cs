using System;

namespace TFU.Common.Models
{
    public class PagingModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Keyword { get; set; }
        public string BrandName { get; set; }
		public PriceFilter? PriceFilter { get; set; }
		public OrderStatusFilter? OrderStatus { get; set; }
		public long ShoesId { get; set; }
		public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
        [OutputParam]
        public int TotalRecord { get; set; }
        public int Day { get; set; }
        public int Week { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalRecord * 1f / PageSize);
        public string CreatedBy { get; set; }

        public static PagingModel Default = new PagingModel()
        {
            PageNumber = 1,
            PageSize = 10
        };
    }

	#region Filter
	public enum BrandNameFilter
	{
		JordanBestQuality = 1,
		Nike = 2,
		Adidas = 3,
		HangChinhHang = 4,
		Converse = 5,
	}

	public enum OrderStatusFilter
	{
		Pending = 1,
		Confirmed = 2,
		Shipped = 3,
		Delivered = 4,
		Cancelled = 5
	}
	public enum PriceFilter
	{
		Under500K = 1,        // Dưới 500.000đ
		From500KTo1M = 2,     // 500.000đ - 1.000.000đ
		From1MTo2M = 3,       // 1.000.000đ - 2.000.000đ
		From2MTo3M = 4,       // 2.000.000đ - 3.000.000đ
		Above3M = 5,
	}

	public class PriceRangeHelper
	{
		// Hàm trả về khoảng giá tương ứng với từng enum
		public static (double min, double max) GetPriceRange(PriceFilter range)
		{
			switch (range)
			{
				case PriceFilter.Under500K:
					return (0, 499999);
				case PriceFilter.From500KTo1M:
					return (500000, 1000000);
				case PriceFilter.From1MTo2M:
					return (1000000, 2000000);
				case PriceFilter.From2MTo3M:
					return (2000000, 3000000);
				case PriceFilter.Above3M:
					return (3000000, double.MaxValue);
				default:
					throw new ArgumentOutOfRangeException(nameof(range), range, null);
			}
		}
	}
	#endregion
}
