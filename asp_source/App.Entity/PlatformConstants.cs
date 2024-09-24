namespace App.Entity
{
	public class PlatformConstants
	{
		#region Lazada API
		public const string LazadaCreateToken = "/auth/token/create";
		/// <summary>
		/// lấy danh sách sản phẩm
		/// </summary>
		public const string LazadaGetProducts = "/products/get";
		/// <summary>
		/// lấy thông tin sản phẩm theo ItemId hoặc SellerSku.
		/// </summary>
		public const string LazadaGetProductItem = "/product/item/get";
		/// <summary>
		/// danh sách thương hiệu
		/// </summary>
		public const string LazadaGetBrands = "/brands/get";
		/// <summary>
		/// danh sách ngành hàng
		/// </summary>
		public const string LazadaGetCategories = "/category/tree/get";
		public const string LazadaGetOrders = "/orders/get";
		public const string LazadaGetOrder = "/order/get";
		public const string LazadaGetOrdersProducts = "/order/items/get";
		public const int LazadaMaxLimitOrdersCanGet = 100;
		public const string LazadaSetOrderStatusToCanceled = "/order/cancel";
		public const string LazadaSetOrderStatusToReadyToShip = "/order/rts";
		public const string LazadaGetOrderFailureReasons = "/order/failure_reason/get";
		public const string LazadaUpdatePriceQuantity = "/product/price_quantity/update";
		public const string LazadaUpdateProduct = "/product/update";
		/// <summary>
		/// Sử dụng API này để truy xuất các tài liệu liên quan đến đơn đặt hàng, bao gồm : invoice, shippingLabel, carrierManifest
		/// </summary>
		public const string LazadaGetDocument = "/order/document/get";
		/// <summary>
		/// Sử dụng API này để truy xuất các tài liệu liên quan đến đơn đặt hàng, chỉ dành cho nhãn vận chuyển. 
		/// </summary>
		public const string LazadaGetAwbDocumentPDF = "/order/document/awb/pdf/get";
		/// <summary>
		/// xóa sản phẩm trên sàn lazada
		/// </summary>
		public const string LazadaRemoveProduct = "/product/remove";
		/// <summary>
		/// danh sách thuộc tính theo ngành hàng
		/// </summary>
		public const string GetCategoryAttributes = "/category/attributes/get";
		/// <summary>
		/// tạo mới sản phẩm
		/// </summary>
		public const string CreateProduct = "/product/create";
		public const string LazadaShipmentProviders = "/shipment/providers/get";
		/// <summary>
		/// Sử dụng API này để đánh dấu một đơn hàng là đã được đóng gói. 
		/// </summary>
		public const string LazadaSetStatusToPackedByMarketplace = "/order/pack";
		/// <summary>
		/// Sử dụng API này để đánh dấu một mặt hàng đặt hàng là đã sẵn sàng giao hàng. 
		/// </summary>
		public const string LazadaSetStatusToReadyToShip = "/order/rts";
		/// <summary>
		/// Sử dụng API này để đặt số hóa đơn cho đơn hàng đã chỉ định. 
		/// </summary>
		public const string LazadaSetInvoiceNumber = "/order/invoice_number/set";
		public const string LazadaGetMultipleOrderItems = "/orders/items/get";
		public const string LazadaFormatDateTime = "yyyy-MM-dd HH:mm:ss zzzz";
		public const string LazadaShipmentProviderFinder = "Delivery: ";
		/// <summary>
		/// giá trị default loại giao hàng
		/// </summary>
		public const string LazadaShipmentType = "dropship";
		/// <summary>
		/// default value để set status to packed by marketplace lazada
		/// </summary>
		public const string LazadaDefaultShipmentProvider = "Aramax";
		public const string LazadaFormatDateTime2 = "yyyy-MM-ddTHH:mm:ss";
		public const string LazadaGetWarehouse = "/seller/warehouse/get";
		public const string LazadaGetSellerInfo = "/seller/get";
		public const string LazadaImagesMigrate = "/images/migrate";
		public const string LazadaImagesGetResponse = "/image/response/get";
		public const string LazadaProductReviewList = "/review/seller/list";
		public static decimal PlatformComissionPercentage;
		#region Finance
		public const string LazadaPayoutStatus = "/finance/payout/status/get";
		public const string LazadaGetTransactionDetails = "/finance/transaction/detail/get";
		#endregion

		#endregion

		#region Shopee API
		/// <summary>
		/// Use this call to get information of shop
		/// </summary>
		public const string Shopee_GetShopInfo = "/api/v2/shop/get_shop_info";
		/// <summary>
		/// Use this call to get list of in-shop categories
		/// </summary>
		public const string Shopee_GetShopCategories = "/shop_categorys/get";
		/// <summary>
		/// Use this api to get categories list filtered by country and cross border without using shopID.
		/// </summary>
		public const string Shopee_GetCategoriesByCountry = "/item/categories/get_by_country";
		/// <summary>
		/// Use this call to get attributes of product item
		/// </summary>
		public const string Shopee_GetAttributes = "/api/v2/product/get_attributes";
		/// <summary>
		/// Use this call to get categories of product item
		/// </summary>
		public const string Shopee_GetCategories = "/api/v2/product/get_category";
		/// <summary>
		/// Use this call to get a list of items
		/// </summary>
		public const string Shopee_GetItemsList = "/api/v2/product/get_item_list";
		/// <summary>
		/// Use this call to get detail of item
		/// </summary>
		public const string Shopee_GetItemDetail = "/api/v2/product/get_item_base_info";
		/// <summary>
		/// Use this call to delete a product item.
		/// </summary>
		public const string Shopee_DeleteProduct = "/api/v2/product/delete_item";
		/// <summary>
		///	Use this call to delete item variation
		/// </summary>
		public const string Shopee_DeleteProductVariation = "/item/delete_variation";
		/// <summary>
		/// Use this optional API to pre-validate your image urls and convert them to Shopee image url to use in item upload APIs. This way your potential invalid urls will not block your item upload process.
		/// </summary>
		public const string Shopee_UploadImg = "/image/upload";
		/// <summary>
		/// Use this call to add a product item
		/// </summary>
		public const string Shopee_AddProduct = "/api/v2/product/add_item";
		/// <summary>
		/// Use this call to update a product item
		/// </summary>
		public const string Shopee_UpdateProduct = "/api/v2/product/update_item";
		/// <summary>
		/// Use this call to get all supported logistic channels.
		/// </summary>
		public const string Shopee_GetLogistics = "/api/v2/logistics/get_channel_list";
		/// <summary>
		/// Use this call to get list of orders
		/// </summary>
		public const string Shopee_GetOrders = "/api/v2/order/get_order_list";
		/// <summary>
		/// Use this call to retrieve detailed information about one or more orders based on OrderSN.
		/// </summary>
		public const string Shopee_GetOrderDetails = "/api/v2/order/get_order_detail";
		/// <summary>
		/// Use this call to update item stock
		/// </summary>
		public const string Shopee_UpdateStock = "/api/v2/product/update_stock";
		/// <summary>
		/// Use this call to update item price. 
		/// </summary>
		public const string Shopee_UpdatePrice = "/api/v2/product/update_price";
		/// <summary>
		/// Use this call to update item variation stock
		/// </summary>
		public const string Shopee_UpdateVariationStock = "/api/v2/product/update_stock";
		/// <summary>
		/// Use this call to update item variation price. 
		/// </summary>
		public const string Shopee_UpdateVariationPrice = "/api/v2/product/update_price";
		/// <summary>
		/// Use this call to get all required param for logistic initiation.
		/// </summary>
		public const string Shopee_GetParameterForInit = "/api/v2/logistics/get_shipping_parameter";
		public const string Shopee_LogisticsInit = "/api/v2/logistics/ship_order";
		/// <summary>
		/// Use this API to get airway bill for orders. AirwayBill is only fetchable when the order status is under READY_TO_SHIP and RETRY_SHIP.
		/// </summary>
		public const string Shopee_GetAirwayBill = "/logistics/airway_bill/get_mass";
		/// <summary>
		/// For integrated logistics channel, use this call to get dropoff location for dropoff mode order.
		/// </summary>
		public const string Shopee_GetBranch = "/logistics/branch/get";
		public const string Shopee_GetLogisticInfo = "/api/v2/logistics/get_shipping_parameter";
		public const string Shopee_BatchInit = "/logistics/batch_init";
		public const string Shopee_GetTrackingNumber = "/api/v2/logistics/get_tracking_number";
		public const string Shopee_GetShippingDocumentParameter = "/api/v2/logistics/get_shipping_document_parameter";
		public const string Shopee_GetShippingDocumentResult = "/api/v2/logistics/get_shipping_document_result";
		public const string Shopee_CreateShippingDocument = "/api/v2/logistics/create_shipping_document";
		public const string Shopee_DownloadShippingDocument = "/api/v2/logistics/download_shipping_document";
		public const string Shopee_GetProductReviews = "/api/v2/product/get_comment";
		#endregion

		#region Facebook API
		public const string Facebook_GetAccessToken = "/oauth/authorize";
		public const string Facebook_GetLongLivedUserToken = "/oauth/access_token";
		public const string Facebook_GetPage = "/oauth/access_token";
		#endregion

		#region GHN API
		/// <summary>
		/// lây danh sách tỉnh/thành phố
		/// </summary>
		public const string GetProvinceGHN = "/shiip/public-api/master-data/province";
		/// <summary>
		/// lấy danh sách quận/huyện
		/// </summary>
		public const string GetDistrictGHN = "/shiip/public-api/master-data/district";
		/// <summary>
		/// lấy danh sách phường/xã
		/// </summary>
		public const string GetWardGHN = "/shiip/public-api/master-data/ward";
		/// <summary>
		/// tạo shop trên GHN
		/// </summary>
		public const string CreateStoreGHN = "/shiip/public-api/v2/shop/register";
		/// <summary>
		/// lấy danh sách shop trên GHN
		/// </summary>
		public const string GetStoreGHN = "/shiip/public-api/v2/shop/all";
		/// <summary>
		/// tính phí ship trên GHN
		/// </summary>
		public const string CalculateFeeGHN = "/shiip/public-api/v2/shipping-order/fee";
		/// <summary>
		/// in nhãn ship trên GHN
		/// </summary>
		public const string PrintOrderGHN = "/a5/public-api/printA5?token=";
		#region Order
		public const string GetOrderInfoGHN = "/shiip/public-api/v2/shipping-order/detail";
		public const string GetFeeOfOrderInfoGHN = "/shiip/public-api/v2/shipping-order/soc";
		public const string GetOrderInfoByClientCodeGHN = "/shiip/public-api/v2/shipping-order/detail-by-client-code";
		/// <summary>
		/// Tạo đơn hàng trên hệ thống GHN
		/// </summary>
		public const string CreateOrderGHN = "/shiip/public-api/v2/shipping-order/create";
		public const string GetServiceGHN = "/shiip/public-api/v2/shipping-order/available-services";

		/// <summary>
		/// GetStationGHN
		/// </summary>
		public const string GetStationGHN = "/shiip/public-api/v2/station/get";

		/// <summary>
		/// GetOrderTokenGHN
		/// </summary>
		public const string GetOrderTokenGHN = "/shiip/public-api/v2/a5/gen-token";
		#endregion
		#region Transaction
		public const string GetCODTransactionsGHN = "/shiip/public-api/v2/cod/transactions";
		#endregion
		#endregion

		#region GHTK API
		public static string CreateOrderGHTK = "/services/shipment/order/?ver=1.5";
		public const string CalculateFeeGHTK = "/services/shipment/fee";
		public const string GetLocationGHTK = "khach-hang/services/list-dia-chi";
		#endregion

		#region Tiki API
		/// <summary>
		/// Return your seller information in the system.
		/// </summary>
		public const string Tiki_GetSeller = "/sellers/me";
		#endregion

		#region Sendo API
		/// <summary>
		/// sendo format date
		/// </summary>
		public const string SendoFormatDate = "yyyy/MM/dd";
		/// <summary>
		///lấy chi tiết tỉnh/ thành phố
		/// </summary>
		public const string Sendo_GetProvinceDetail = "/address/region/{provinceId}";
		/// <summary>
		///lấy chi tiết  Quận/Huyện
		/// </summary>
		public const string Sendo_GetDistrictDetail = "/address/district/{districtId}";
		/// <summary>
		///lấy chi tiết Phường/ Xã
		/// </summary>
		public const string Sendo_GetWardDetail = "/address/ward/{wardId}";
		/// <summary>
		/// Lấy thông tin đơn hàng theo khung thời gian
		/// </summary>
		public const string Sendo_GetListOrder = "/partner/salesorder/search";
		/// <summary>
		/// Lấy chi tiết đơn theo OrderNumber
		/// </summary>
		public const string Sendo_GetByOrderNumber = "/partner/salesorder/{orderNumber}";
		/// <summary>
		/// Lấy thông tin ngành hàng
		/// </summary>
		public const string Sendo_GetCategory = "/partner/category/{catId}";
		/// <summary>
		/// Lấy danh sách thuộc tính
		/// </summary>
		public const string Sendo_GetAttibutes = "/partner/category/attribute/{catId}";
		/// <summary>
		/// Tạo và cập nhật sản phẩm
		/// </summary>
		public const string Sendo_CreateOrUpdateProduct = "/partner/product";
		#endregion


		public const string Country = "COUNTRY";
		public const string City = "CITY";
		public const string Province = "PROVINCE";
		public const string District = "DISTRICT";
		public const string Ward = "WARD";
	}
}
