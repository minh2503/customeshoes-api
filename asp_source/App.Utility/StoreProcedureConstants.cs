namespace App.Utility
{
	public class StoreProcedureConstants
	{
		public const string App_Products_Get_Page = "App_Products_Get_Page";

		#region Product Preview
		public const string App_ProductReview_GetId = "App_ProductReview_GetId";
		public const string App_ReplyProducReview_Get_ProductReviewId = "App_ReplyProducReview_Get_ProductReviewId";
		public const string App_ProductReview_GetSellerId = "App_ProductReview_GetSellerId";
		public const string App_ProductReview_Get_Page = "App_ProductReview_Get_Page";
		#endregion

		#region Campaign Buy More
		public const string App_CampaignBuyMore_GetById = "App_CampaignBuyMore_GetById";
		public const string App_CampaignBuyMore_GetPaging = "App_CampaignBuyMore_GetPaging";
		#endregion

		#region Campaign FreeShip
		public const string App_CampaignFreeShip_GetPaging = "App_CampaignFreeShip_GetPaging";
		public const string App_CampaignFreeShip_GetById = "App_CampaignFreeShip_GetById";
		public const string App_CampaignFreeShip_GetActive = "App_CampaignFreeShip_GetActive";
		#endregion

		#region Combo
		public const string COM_ComboDTO_GetById = "COM_ComboDTO_GetById";
		public const string COM_Combo_GetPage = "COM_Combo_GetPage";
		public const string ComboProductSelectModel_GetPage = "ComboProductSelectModel_GetPage";
		public const string GetPDPComboById = "GetPDPComboById";
		public const string PDPComboImageModel_GetById = "PDPComboImageModel_GetById";
		public const string PDPCombo_AgeProduct_ById = "PDPCombo_AgeProduct_ById";
		public const string PDPComboItem_Get_Page = "PDPComboItem_Get_Page";
		#endregion

		#region 	Variant
		public const string App_ProductVariant_Get_ByProductId = "App_ProductVariant_Get_ByProductId";
		public const string App_FilterSearchPage_Get_ByKeyword = "App_FilterSearchPage_Get_ByKeyword";
		public const string App_ProductVariantList_Get_Page = "App_ProductVariantList_Get_Page";
		#endregion

		#region Product
		public const string App_ProductList_Get_Page = "App_ProductList_Get_Page";
		public const string App_Product_Get_ByProductId = "App_Product_Get_ByProductId";
		public const string App_Products_Get_ListProductId = "App_Products_Get_ListProductId";
		public const string App_ProductVariants_Get_Ids = "App_ProductVariants_Get_Ids";
		public const string App_Product_Get_HotProducts = "App_Products_Get_HotProducts";
		public const string App_Products_Get_Products_ByCategory = "App_Products_Get_Products_ByCategory";
		public const string App_Products_Get_CampaignProducts = "App_Products_Get_CampaignProducts";
		public const string App_Products_Get_TopProducts_ForUser = "App_Products_Get_TopProducts_ForUser";
		public const string App_Products_Get_Favorite_ForUser = "App_Products_Get_Favorite_ForUser";
		public const string App_Products_Get_Products_ByCreatorId = "App_Products_Get_Products_ByCreatorId";
		public const string App_Product_Get_Page_Dropdown = "App_Product_Get_Page_Dropdown";
		public const string LandingPage_Products_GetCreator_SetId = "LandingPage_Products_GetCreator_SetId";
		#endregion

		#region ProductVariant
		public const string App_ProductVariants_Get_ByProductId = "App_ProductVariants_Get_ByProductId";
		public const string App_ProductVariants_Get_ById = "App_ProductVariants_Get_ById";
		public const string App_ProductVariantsFrame_Get_ByArtworkId = "App_ProductVariantsFrame_Get_ByArtworkId";
		public const string App_ProductVariantsFrame_Get_ByAppProductVariantId = "App_ProductVariantsFrame_Get_ByAppProductVariantId";
		public const string App_ProductVariantsFrame_Get_ByArtworkId_NoArtworkCost = "App_ProductVariantsFrame_Get_ByArtworkId_NoArtworkCost";
		#endregion

		#region Question
		public const string App_Questions_Get_ByUserName = "App_Questions_Get_ByUserName";
		#endregion

		#region Category
		public const string App_Categories_Get_ById = "App_Categories_Get_ById";
		public const string App_Categories_GetListLastChildren = "App_Categories_GetListLastChildren";
		public const string App_Categories_Get_ByLevel = "App_Categories_Get_ByLevel";
		public const string App_Category_Get_DisplayProducts = "App_Category_Get_DisplayProducts";
		#endregion

		#region Campaign
		public const string App_CampaignList_Get_Page = "App_CampaignList_Get_Page";
		public const string App_Campaigns_Get_ById = "App_Campaigns_Get_ById";
		public const string App_CampaignHighLights_Get_ByCampaignId = "App_CampaignHighLights_Get_ByCampaignId";
		public const string App_CampaignProducts_Get_ByCampaignHighLightId = "App_CampaignProducts_Get_ByCampaignHighLightId";
		public const string App_CampaignBoostings_GetDashboard = "App_CampaignBoostings_GetDashboard";
		public const string App_CampaignBoostings_Save = "App_CampaignBoostings_Save";
		public const string App_CampaignBoostings_GetPaging = "App_CampaignBoostings_GetPaging";
		public const string App_CampaignBoostings_GetById = "App_CampaignBoostings_GetById";
		public const string App_CampaignBoostings_Deletes = "App_CampaignBoostings_Deletes";
		public const string App_CampaignBoostings_Marketer_GetPaging = "App_CampaignBoostings_Marketer_GetPaging";
		public const string App_CampaignBoostings_Register = "App_CampaignBoostings_Register";
		public const string App_CampaignBoostings_UnRegister = "App_CampaignBoostings_UnRegister";
		public const string App_CampaignBoostings_Marketer_Master_GetPaging = "App_CampaignBoostings_Marketer_Master_GetPaging";
		public const string App_CampaignBoostings_Traffics_Detail = "App_CampaignBoostings_Traffics_Detail";
		public const string App_CampaignMilestone_GetDashboard = "App_CampaignMilestone_GetDashboard";
		public const string App_Campaigns_Validate_Save_Milestone = "App_Campaigns_Validate_Save_Milestone";
		public const string App_CampaignProductMilestone_Get_Paging = "App_CampaignProductMilestone_Get_Paging";
		public const string App_CampaignProductMilestone_Delete = "App_CampaignProductMilestone_Delete";
		public const string App_CampaignProductMilestone_Get_Id = "App_CampaignProductMilestone_Get_Id";
		#endregion

		#region Location
		public const string App_Provinces_GetList = "App_Provinces_GetList";
		public const string App_Districts_Get_ByProvinceCode = "App_Districts_Get_ByProvinceCode";
		public const string App_Wards_Get_ByDistrictCode = "App_Wards_Get_ByDistrictCode";
		#endregion

		#region MyRegion
		public const string App_MagazineCategoryList_Get_Page = "App_MagazineCategoryList_Get_Page";
		public const string App_MagazineCategories_AddOrUpdate = "App_MagazineCategories_AddOrUpdate";
		public const string App_MagazineCategories_Delete = "App_MagazineCategories_Delete";
		public const string App_MagazineList_Get_Page = "App_MagazineList_Get_Page";
		public const string App_Magazines_Get_ById = "App_Magazines_Get_ById";
		#endregion

		#region Brand
		public const string App_Brands_Get_Page = "App_Brands_Get_Page";
		public const string App_BrandsCreator_Get_Page = "App_BrandsCreator_Get_Page";
		public const string App_Brands_Get_ById = "App_Brands_Get_ById";
		public const string App_Brands_Approved = "App_Brands_Approved";
		public const string App_Brands_HandleLogo_Get_Page = "App_Brands_HandleLogo_Get_Page";
		public const string App_Brands_HandleLogo = "App_Brands_HandleLogo";
		public const string App_Brands_Deletes = "App_Brands_Deletes";
		#endregion

		#region FlashSale
		public const string App_FlashSale_Get_Page = "App_FlashSale_Get_Page";
		#endregion

		#region Voucher
		public const string App_Voucher_Get_ById = "App_Vouchers_Get_ById";
		public const string App_Voucher_GetDetail_ById = "App_Voucher_GetDetail_ById";
		public const string App_VoucherProduct_Get_Page = "App_VoucherProduct_Get_Page";
		public const string App_VoucherUser_Get_Page = "App_VoucherUser_Get_Page";
		public const string App_Voucher_Get_Paging_Type = "App_Voucher_Get_Paging_Type";
		public const string App_VoucherGifts_Get_ById = "App_VoucherGifts_Get_ById";
		public const string App_VoucherGifts_Validate_AppliedQuantity = "App_VoucherGifts_Validate_AppliedQuantity";
		public const string App_Voucher_Get_ById_VoucherType = "App_Voucher_Get_ById_VoucherType";
		public const string App_VoucherGifts_Get_Dashboard = "App_VoucherGifts_Get_Dashboard";
		public const string App_VoucherFreeGiftProduct_Get_Page = "App_VoucherFreeGiftProduct_Get_Page";
		public const string App_VoucherFreeGiftProduct_Get_VoucherId = "App_VoucherFreeGiftProduct_Get_VoucherId";
		public const string App_VoucherPromotes_GetPage_ToRegister = "App_VoucherPromotes_GetPage_ToRegister";
		public const string App_VoucherPromoteProducts_GetPage_ToRegister = "App_VoucherPromoteProducts_GetPage_ToRegister";
		public const string App_VoucherPromoteProducts_GetIds_ToRegister = "App_VoucherPromoteProducts_GetIds_ToRegister";
		public const string App_VoucherPromoteProducts_Save = "App_VoucherPromoteProducts_Save";
		public const string App_VoucherPromoteProducts_UnJoined = "App_VoucherPromoteProducts_UnJoined";
		public const string App_Voucher_Get_VoucherProduct = "App_Voucher_Get_VoucherProduct";
		public const string App_Voucher_Get_Active_Vouchers = "App_Voucher_Get_Active_Vouchers";
		public const string App_VoucherAffiliate_GetPage = "App_VoucherAffiliate_GetPage";
		#endregion

		#region Attribute
		public const string App_Attributes_Get_Page = "App_Attributes_Get_Page";
		public const string App_Attributes_Get_ById = "App_Attributes_Get_ById";
		#endregion

		#region Warehouse
		public const string App_WarehouseList_Get_Page = "App_WarehouseList_Get_Page";
		public const string App_Warehouses_Get_ById = "App_Warehouses_Get_ById";
		public const string WAR_SlotOperators_StockIn = "WAR_SlotOperators_StockIn";
		public const string WAR_SlotOperators_Detail = "WAR_SlotOperators_Detail";
		public const string WAR_SlotOperators_GetPaging = "WAR_SlotOperators_GetPaging";
		public const string WAR_SlotOperators_Delete = "WAR_SlotOperators_Delete";
		#endregion

		#region Account
		public const string TFU_Users_Get_ById = "TFU_Users_Get_ById";
		public const string TFU_Users_Get_ByProductId = "TFU_Users_Get_ByProductId";
		public const string TFU_Users_Get_Page = "TFU_Users_Get_Page";
		public const string TFU_Users_Get_ByExternalIdAndEmail = "TFU_Users_Get_ByExternalIdAndEmail";
		public const string TFU_Users_Get_ByGoogleId = "TFU_Users_Get_ByGoogleId";
		public const string TFU_Users_Get_ByFacebookId = "TFU_Users_Get_ByFacebookId";
		#endregion

		#region System
		public const string SYS_Menu_Get_ByUserId = "SYS_Menu_Get_ByUserId";
		public const string Get_ExtendData_Options_StockOut = "Get_ExtendData_Options_StockOut";
		#endregion

		#region Tag Trending
		public const string App_TagTrending_Get_Page = "App_TagTrending_Get_Page";
		#endregion

		#region Age
		public const string AGE_AgencyOrderProduct_GetByIds = "AGE_AgencyOrderProduct_GetByIds";
		public const string AGE_AgencyOrderProducts_GetDetail = "AGE_AgencyOrderProducts_GetDetail";
		public const string AGE_AgencyProductWarehouse_Get_BySellerSKU = "AGE_AgencyProductWarehouse_Get_BySellerSKU";
		public const string AGE_AgencyProducts_GetProductVariants_ByIds = "AGE_AgencyProducts_GetProductVariants_ByIds";
		public const string AGE_AgencyProducts_GetProducts_ByIds = "AGE_AgencyProducts_GetProducts_ByIds";
		public const string AGE_AgencyProducts_Get_Page = "AGE_AgencyProducts_Get_Page";
		public const string AGE_AgencyProductVariants_Get_Page = "AGE_AgencyProductVariants_Get_Page";
		public const string AGE_AgencyProductVariants_Get_ByListId = "AGE_AgencyProductVariants_Get_ByListId";
		public const string AGE_AgencyProductVariants_GetAttribute_ByListId = "AGE_AgencyProductVariants_GetAttribute_ByListId";
		public const string AGE_AgencyProductVariants_GetAttribute_ByListSKU = "AGE_AgencyProductVariants_GetAttribute_ByListSKU";
		public const string AGE_Product_Get_ByProductId = "AGE_Product_Get_ByProductId";
		public const string AGE_AgencyProductVariants_Get_BySkus = "AGE_AgencyProductVariants_Get_BySkus";
		public const string AGE_CampaignList_Get_Page = "AGE_CampaignList_Get_Page";
		public const string AGE_Campaigns_Get_ById = "AGE_Campaigns_Get_ById";
		public const string AGE_Artwork_Set_Paging = "AGE_Artwork_Set_Paging";
		public const string AGE_Artwork_Set_Get_ById = "AGE_Artwork_Set_Get_ById";
		public const string AGE_ProductVariants_Get_Ids = "AGE_ProductVariants_Get_Ids";
		public const string AGE_Artwork_Update_Status = "AGE_Artwork_Update_Status";
		public const string AGE_Artwork_Update_Status_By_AppSetId = "AGE_Artwork_Update_Status_By_AppSetId";
		public const string AGE_Agency_Get_Id = "AGE_Agency_Get_Id";
		public const string AGE_AgencyProduct_Update = "AGE_AgencyProduct_Update";
		public const string AGE_DownloadResource_GetPage_History = "AGE_DownloadResource_GetPage_History";
		public const string App_ProductCode_By_AppSetId = "App_ProductCode_By_AppSetId";
		public const string AGE_Agency_Get_Hompage = "AGE_Agency_Get_Hompage";
		public const string AGE_Agency_Get_SetId = "AGE_Agency_Get_SetId";
		public const string AGE_AgencyProductVariants_Get_BySetId = "AGE_AgencyProductVariants_Get_BySetId";
		public const string AGE_AgencyProductVariants_Get_ByListId_Voucher = "AGE_AgencyProductVariants_Get_ByListId_Voucher";
		public const string AGE_Size_Get_Page = "AGE_Size_Get_Page";
		public const string AGE_Size_Get_Default = "AGE_Size_Get_Default";
		public const string AGE_Artwork_Get_ByAgeSetId = "AGE_Artwork_Get_ByAgeSetId";
		public const string AGE_Agency_GetByUserName = "AGE_Agency_GetByUserName";
		public const string AGE_AgencyProduct_GetVariant_BasicInfo = "AGE_AgencyProduct_GetVariant_BasicInfo";
		#endregion

		#region Landing Page
		public const string LandingPage_Banners_GetList = "LandingPage_Banners_GetList";
		public const string LandingPage_Products_GetPage = "LandingPage_Products_GetPage";
		public const string LandingPage_Product_GetBySetId = "LandingPage_Product_GetBySetId";
		public const string LandingPage_ProductMobile_GetBySetProductId = "LandingPage_ProductMobile_GetBySetProductId";
		public const string LandingPage_CreatorBrand_GetNewArrival_CreatorId = "LandingPage_CreatorBrand_GetNewArrival_CreatorId";
		public const string LandingPage_Product_GetBySetProductId = "LandingPage_Product_GetBySetProductId";
		public const string LandingPage_ProductReview_GetPage = "LandingPage_ProductReview_GetPage";
		public const string LandingPage_ProductReview_Get_ByProductId = "LandingPage_ProductReview_Get_ByProductId";
		public const string LandingPage_Products_GetBestSeller_Page = "LandingPage_Products_GetBestSeller_Page";
		public const string LandingPage_Products_GetNewArrival_Page = "LandingPage_Products_GetNewArrival_Page";
		public const string LandingPage_Products_GetBlank_Page = "LandingPage_Products_GetBlank_Page";
		public const string LandingPage_Products_GetSuggestInFeed = "LandingPage_Products_GetSuggestInFeed";
		public const string LandingPage_Categories_GetListParent = "LandingPage_Categories_GetListParent";
		public const string LandingPage_Categories_Get_ByParentId = "LandingPage_Categories_Get_ByParentId";
		public const string LandingPage_ShoppingCart_Get_ByUserID = "LandingPage_ShoppingCart_Get_ByUserID";
		public const string LandingPage_FavoriteList_Get_ByUserID = "LandingPage_FavoriteList_Get_ByUserID";
		public const string LandingPage_Orders_Get_ByUserName = "LandingPage_Orders_Get_ByUserName";
		public const string LandingPage_Questions_Get_ByProductId = "LandingPage_Questions_Get_ByProductId";
		public const string LandingPage_Users_GetFollowingCreatorBrands = "LandingPage_Users_GetFollowingCreatorBrands";
		public const string LandingPage_ProductReview_Get_BySetId = "LandingPage_ProductReview_Get_BySetId";
		public const string LandingPage_ProductReview_Get_ByCreatorId = "LandingPage_ProductReview_Get_ByCreatorId";
		public const string LandingPage_Products_Get_ByKeyword = "LandingPage_Products_Get_ByKeyword";
		public const string LandingPage_Products_GetSuggestInProfile = "LandingPage_Products_GetSuggestInProfile";
		public const string LandingPage_Products_GetSuggestRelevant_Page = "LandingPage_Products_GetSuggestRelevant_Page";
		public const string LandingPage_ProductReview_Get_ByOrderProductId = "LandingPage_ProductReview_Get_ByOrderProductId";
		public const string LandingPage_ProductNotYetReview_Get_UserId = "LandingPage_ProductNotYetReview_Get_UserId";
		public const string LandingPage_ProductReviewHistory_Get_UserId = "LandingPage_ProductReviewHistory_Get_UserId";
		public const string LandingPage_ProductReviewHistory_Get_ByUserId = "LandingPage_ProductReviewHistory_Get_ByUserId";
		public const string LandingPage_Artwork_GetNewArrival_Page = "LandingPage_Artwork_GetNewArrival_Page";
		public const string LandingPage_Topic_GetNewArrival_PageTopic = "LandingPage_Topic_GetNewArrival_PageTopic";
		public const string AGE_Artwork_Get_CreatorIdPage = "AGE_Artwork_Get_CreatorIdPage";
		public const string LandingPage_Creator_GetNewArrival_Page = "LandingPage_Creator_GetNewArrival_Page";
		public const string LandingPage_Topic_GetNewArrival_Page = "LandingPage_Topic_GetNewArrival_Page";
		public const string LandingPage_Collection_Get_Page = "LandingPage_Collection_Get_Page";
		public const string LandingPage_Collection_Get_PageCollection = "LandingPage_Collection_Get_PageCollection";
		public const string LandingPage_Products_Get_CollectionId = "LandingPage_Products_Get_CollectionId";
		public const string LandingPage_ProductNotReview_Get_ByUserId = "LandingPage_ProductNotReview_Get_ByUserId";
		public const string LandingPage_TagTrending_GetPage = "LandingPage_TagTrending_GetPage";
		public const string LandingPage_TagTrending_Get_Id = "LandingPage_TagTrending_Get_Id";
		public const string LandingPage_ShoppingCartCombo_Get_ByUserID = "LandingPage_ShoppingCartCombo_Get_ByUserID";
		#endregion

		#region Creator
		public const string App_Creators_GetPage = "App_Creators_GetPage";
		public const string Creator_Producs_GetPage = "Creator_Producs_GetPage";
		public const string AGE_Collections_Get_ByPage = "AGE_Collections_Get_ByPage";
		public const string AGE_Collections_Get_ByAgencyId = "AGE_Collections_Get_ByAgencyId";
		public const string AGE_Collections_Get_ByUserId = "AGE_Collections_Get_ByUserId";
		public const string AGE_Artworks_Get_ByCreator = "AGE_Artworks_Get_ByCreator";
		public const string App_Images_Get_MockupByArtworkId = "App_Images_Get_MockupByArtworkId";
		public const string App_Images_Get_ById = "App_Images_Get_ById";
		public const string App_ProductsInCampaign_Get_ByCreator = "App_ProductsInCampaign_Get_ByCreator";
		public const string App_Images_InsertUpdate_ImageOppositeModel = "App_Images_InsertUpdate_ImageOppositeModel";
		#endregion

		#region OPF
		public const string OPF_Tokens_Get_ByUser = "OPF_Tokens_Get_ByUser";
		public const string OPF_Tokens_Get_ByUserWithProduct = "OPF_Tokens_Get_ByUserWithProduct";
		public const string OPF_Warehouse_GetPage = "OPF_Warehouse_GetPage";
		public const string AGE_AgencyProducts_Get_Page_ProductDesign = "AGE_AgencyProducts_Get_Page_ProductDesign";
		public const string AGE_AgencyProducts_Get_Page_ProductPush = "AGE_AgencyProducts_Get_Page_ProductPush";
		public const string OPF_Attributes_GetByCategory = "OPF_Attributes_GetByCategory";
		public const string OPF_AttributeOptions_RemoveAddRange = "OPF_AttributeOptions_RemoveAddRange";
		public const string OPF_Attributes_GetByLotusCategory = "OPF_Attributes_GetByLotusCategory";
		#endregion

		#region MyRegion
		public const string App_Set_Get_ByPaging = "App_Set_Get_ByPaging";
		public const string App_Set_GetInfo_Complement = "App_Set_GetInfo_Complement";
		public const string AGE_Set_Delete = "AGE_Set_Delete";
		public const string App_Set_Title_ByKeyword = "App_Set_Title_ByKeyword";
		public const string App_SetSeo_GetById = "App_SetSeo_GetById";
		public const string App_CreatorSeo_GetById = "App_CreatorSeo_GetById";
		public const string App_Sets_Update_TotalSell = "App_Sets_Update_TotalSell";
		public const string AGE_Set_UpdateStatus = "AGE_Set_UpdateStatus";
		public const string AGE_Set_UpdatePrint = "AGE_Set_UpdatePrint";
		public const string App_CollectionSeo_GetById = "App_CollectionSeo_GetById";
		#endregion

		#region Artwork
		public const string AGE_Artwork_Get_Page = "AGE_Artwork_Get_Page";
		public const string AGE_Artwork_Insert_List = "AGE_Artwork_Insert_List";
		public const string App_SetProductVariants_InsertList = "App_SetProductVariants_InsertList";
		public const string AGE_ArtworkCost_Insert_List = "AGE_ArtworkCost_Insert_List";
		public const string AGE_Artwork_Paging = "AGE_Artwork_Paging";
		public const string AGE_Artwork_Report_Quota = "AGE_Artwork_Report_Quota";
		public const string AGE_Artwork_Delete = "AGE_Artwork_Delete";
		public const string AGE_Artwork_Censorship_Paging = "AGE_Artwork_Censorship_Paging";
		public const string AGE_Artwork_Get_ById = "AGE_Artwork_Get_ById";
		public const string AGE_Artwork_Censorship = "AGE_Artwork_Censorship";
		public const string App_Sets_Additional_Info = "App_Sets_Additional_Info";
		public const string AGE_Artwork_Get_Ids = "AGE_Artwork_Get_Ids";
		#endregion

		#region Print
		public const string PRINT_GTXConfigs_Get_Page = "PRINT_GTXConfigs_Get_Page";
		public const string PRINT_BrandStamp_Get_SetId = "PRINT_BrandStamp_Get_SetId";
		public const string PRINT_BrandStamp_InsertList = "PRINT_BrandStamp_InsertList";
		public const string PRINT_BrandStampConfig_Get_SetId = "PRINT_BrandStampConfig_Get_SetId";
		public const string PRINT_RenderMockupModel_Get_ById = "PRINT_RenderMockupModel_Get_ById";
		public const string PRINT_GetConfig_Get_BySetId = "PRINT_GetConfig_Get_BySetId";
		public const string MTO_GetConfig_Get_ByProductId = "MTO_GetConfig_Get_ByProductId";
		#endregion

		#region Packing
		public const string ORD_Package_Get_TagId = "ORD_Package_Get_TagId";
		public const string ORD_TagDetail_Get_TagId = "ORD_TagDetail_Get_TagId";
		public const string Ord_TagDetail_Get_TagIds = "Ord_TagDetail_Get_TagIds";
		public const string ORD_Orders_Update_PackageFullPack = "ORD_Orders_Update_PackageFullPack";
		#endregion

		#region MyRegion
		public const string ORD_File_Get_OrderNumber = "ORD_File_Get_OrderNumber";
		public const string ORD_File_Sync_Artwork_ByUser = "ORD_File_Sync_Artwork_ByUser";
		public const string ORD_OperatorFiles_CheckDuplicatePETBarcode = "ORD_OperatorFiles_CheckDuplicatePETBarcode";
		#endregion

		#region Order
		public const string ORD_Orders_GetPage = "ORD_Orders_GetPage";
		public const string ORD_Orders_GetCountPage = "ORD_Orders_GetCountPage";
		public const string ORD_Orders_GetDetail = "ORD_Orders_GetDetail";
		public const string ORD_Package_Get_Page = "ORD_Package_Get_Page";
		public const string ORD_Package_Save_PackageHandle = "ORD_Package_Save_PackageHandle";
		public const string ORD_Orders_GetDeliveryInfo = "ORD_Orders_GetDeliveryInfo";
		public const string ORD_Orders_Update_TotalPrintLabelShip = "ORD_Orders_Update_TotalPrintLabelShip";
		public const string ORD_Orders_Update_ShippingOrderNumber = "ORD_Orders_Update_ShippingOrderNumber";
		public const string Ord_Orders_GetPage_FinanceMomo = "Ord_Orders_GetPage_FinanceMomo";
		public const string Ord_Orders_FinanceMomo_Transcript = "Ord_Orders_FinanceMomo_Transcript";
		public const string ORD_OperatorFiles_Get_Paging = "ORD_OperatorFiles_Get_Paging";
		public const string ORD_OperatorFiles_SaveUpload = "ORD_OperatorFiles_SaveUpload";
		public const string AGE_Artworks_Save_ManualPetProcessBy = "AGE_Artworks_Save_ManualPetProcessBy";
		public const string ORD_CheckFileTotal_By_OrderProductIds = "ORD_CheckFileTotal_By_OrderProductIds";
		public const string ORD_Orders_GetAffiliateInfo = "ORD_Orders_GetAffiliateInfo";
		public const string ORD_Orders_ScanById = "ORD_Orders_ScanById";
		public const string ORD_Orders_Cancel = "ORD_Orders_Cancel";
		public const string ORD_OperatorOrderDetails_Insert = "ORD_OperatorOrderDetails_Insert";
		public const string ORD_OperatorCustomizeOrderDetails_Insert = "ORD_OperatorCustomizeOrderDetails_Insert";
		#endregion

		#region OrderShippingServicesDetails
		public const string ORD_OrderShippingServicesDetails_GetPage_COD = "ORD_OrderShippingServicesDetails_GetPage_COD";
		#endregion

		#region Operator Order
		public const string ORD_OperatorOrder_Get_Page = "ORD_OperatorOrder_Get_Page";
		public const string ORD_OperatorOrderTotal_Get_Page = "ORD_OperatorOrderTotal_Get_Page";
		public const string ORD_OperatorOrderAnalysis_Get = "ORD_OperatorOrderAnalysis_Get";
		public const string ORD_TagDTG_Get_TagId = "ORD_TagDTG_Get_TagId";
		public const string ORD_TagPET_Get_TagId = "ORD_TagPET_Get_TagId";
		public const string ORD_OperatorOrder_ServicesGet_Page = "ORD_OperatorOrder_ServicesGet_Page";
		public const string ORD_File_Get_OrderProductId = "ORD_File_Get_OrderProductId";
		public const string ORD_File_Get_OrderCustomizeProductId = "ORD_File_Get_OrderCustomizeProductId";
		public const string ORD_OperatorOrders_GetPage_FinancePrint = "ORD_OperatorOrders_GetPage_FinancePrint";
		public const string ORD_OperatorOrder_Create_PetBatchProduction = "ORD_OperatorOrder_Create_PetBatchProduction";
		public const string ORD_OperatorOrders_GetDetail = "ORD_OperatorOrders_GetDetail";
		public const string ORD_OperatorOrders_Get_Page = "ORD_OperatorOrders_Get_Page";
		public const string ORD_OperatorOrder_ServicesGet_Ids = "ORD_OperatorOrder_ServicesGet_Ids";
		public const string ORD_OperatorCustomizeOrder_ServicesGet_Ids = "ORD_OperatorCustomizeOrder_ServicesGet_Ids";
		#endregion

		#region AGE_AgencyProduc
		/// <summary>
		/// Lấy thông tin agency product theo id
		/// </summary>
		public const string AGE_AgencyProduct_GetById = "AGE_AgencyProduct_GetById";
		/// <summary>
		/// lấy danh sách dropdown creator
		/// </summary>
		public const string AGE_Agencies_GetDropdown = "AGE_Agencies_GetDropdown";
		/// <summary>
		/// lấy danh sách toàn bộ ảnh của agencyproduct
		/// </summary>
		public const string App_Images_GetAllOfAgencyProduct = "App_Images_GetAllOfAgencyProduct";
		/// <summary>
		/// lấy thông tin cấu hình theo agency level
		/// </summary>
		public const string SYS_Levels_Get_ByAgency = "SYS_Levels_Get_ByAgency";
		public const string AGE_FavoriteCreator_Get_ByUserId = "AGE_FavoriteCreator_Get_ByUserId";
		#endregion

		#region Services Clear Image 
		public const string App_Images_Get_Page_ForClear = "App_Images_Get_Page_ForClear";
		public const string Service_Clear_Images = "Service_Clear_Images";
		#endregion

		#region Ticket Return
		/// <summary>
		/// GetPageTicketReturnOrder
		/// </summary>
		public const string App_Ticket_Return_Orders_Get_Page = "App_Ticket_Return_Orders_Get_Page";
		/// <summary>
		/// GetPageTicketReturnOrder
		/// </summary>
		public const string App_Ticket_Return_Orders_Get_List_By_User = "App_Ticket_Return_Orders_Get_List_By_User";
		/// <summary>
		/// GetTicketDetail
		/// </summary>
		public const string App_Ticket_Get_Detail = "App_Ticket_Get_Detail";
		/// <summary>
		/// GetTicketComments
		/// </summary>
		public const string App_TicketComments_Get_By_TicketId = "App_TicketComments_Get_By_TicketId";
		public const string App_Ticket_OrderProducts_Get_ByOrderId = "App_Ticket_OrderProducts_Get_ByOrderId";
		/// <summary>
		/// GetReturnOrderProducts
		/// </summary>
		public const string App_TicketReturnOrderProducts_Get_By_TicketId = "App_TicketReturnOrderProducts_Get_By_TicketId";
		#endregion Ticket Return

		#region App_Sets
		/// <summary>
		/// tìm kiếm App_Products để thiết lập sản phẩm cho set product
		/// </summary>
		public const string App_Sets_SuggestSearch = "App_Sets_SuggestSearch";
		/// <summary>
		/// Tìm kiếm App_Set
		/// </summary>
		public const string App_Sets_SuggestSet = "App_Sets_SuggestSet";
		/// <summary>
		/// lấy danh sách app_variant cho vào set product
		/// </summary>
		public const string App_SetProductVariants_SuggestSearch = "App_SetProductVariants_SuggestSearch";
		/// <summary>
		/// lấy chi tiết set product
		/// </summary>
		public const string App_Set_GetById = "App_Set_GetById";
		public const string App_ProductDetail_GetById_CreateArtwork = "App_ProductDetail_GetById_CreateArtwork";
		/// <summary>
		/// lấy danh sách app set product theo paging
		/// </summary>
		public const string App_Set_Get_Page = "App_Set_Get_Page";
		public const string App_Set_Get_Page_CreateArtwork = "App_Set_Get_Page_CreateArtwork";
		/// <summary>
		/// xóa set product
		/// </summary>
		public const string App_Set_Delete = "App_Set_Delete";
		/// <summary>
		/// lấy danh sách direct sell theo paging
		/// </summary>
		public const string App_Set_DirectSell_GetPage = "App_Set_DirectSell_GetPage";
		/// <summary>
		/// lấy thông tin set product variant by set id
		/// </summary>
		public const string App_SetProductVariants_GetBySetId = "App_SetProductVariants_GetBySetId";
		public const string App_SetProductVariants_GetPage = "App_SetProductVariants_GetPage";

		#endregion

		#region Customer
		public const string ThirdParties_Customer_Paging = "ThirdParties_Customer_Paging";
		public const string ThirdParties_Customer_GetOrders = "ThirdParties_Customer_GetOrders";
		public const string ThirdParties_Customer_Detail = "ThirdParties_Customer_Detail";
		public const string ThirdParties_Customer_CheckBuyCOD = "ThirdParties_Customer_CheckBuyCOD";
		public const string ThirdParties_Customer_UpdateReputation = "ThirdParties_Customer_UpdateReputation";
		public const string ThirdPartyAddressHistories_GetPaging = "ThirdPartyAddressHistories_GetPaging";
		public const string ThirdParties_Affiliate_Get_Page_Pending = "ThirdParties_Affiliate_Get_Page_Pending";
		#endregion

		#region Finance
		/// <summary>
		/// lấy danh sách chưa thanh toán sản xuất cho Operator
		/// </summary>
		public const string FIN_OperatorTickets_Unpaid_GetPage = "FIN_OperatorTickets_Unpaid_GetPage";
		/// <summary>
		/// lấy danh sách đã thanh toán sản xuất cho Operator
		/// </summary>
		public const string FIN_OperatorTickets_Paid_GetPage = "FIN_OperatorTickets_Paid_GetPage";
		/// <summary>
		/// Lấy danh sach Operator đã và đang chờ thanh toán trong khoảng thời gian
		/// </summary>
		public const string FIN_Finance_Get_Operators = "FIN_Finance_Get_Operators";
		/// <summary>
		/// Lấy doanh thu của Các Operators trong khoảng thời gian
		/// </summary>
		public const string FIN_Finance_Get_Multiple_Operator_Revenues = "FIN_Finance_Get_Multiple_Operator_Revenues";
		/// <summary>
		/// quản lý tiền bản quyền creator admin
		/// </summary>
		public const string FIN_Finance_LoyaltyManagement = "FIN_Finance_LoyaltyManagement";
		/// <summary>
		/// thống kê doanh số theo tháng
		/// </summary>
		public const string FIN_Finance_Get_CreatorTicket = "FIN_Finance_Get_CreatorTicket";
		/// <summary>
		/// lấy chi tiết thống kê doanh số theo tháng
		/// </summary>
		public const string FIN_Finance_Get_CreatorTicketDetail = "FIN_Finance_Get_CreatorTicketDetail";
		/// <summary>
		/// thông tin phát triển thương hiệu
		/// </summary>
		public const string FIN_Finance_ProductAnalyst = "FIN_Finance_ProductAnalyst";
		/// <summary>
		/// Thống kê order của creator
		/// </summary>
		public const string FIN_Finance_Get_CreatorOrders = "FIN_Finance_Get_CreatorOrders";
		/// <summary>
		/// Lấy danh sách product theo order.
		/// </summary>
		public const string FIN_Finance_Get_CreatorOrderProducts = "FIN_Finance_Get_CreatorOrderProducts";
		/// <summary>
		/// Get product with loyalty
		/// </summary>
		public const string FIN_Finance_Get_CreatorProducts_ByOrderId = "FIN_Finance_Get_CreatorProducts_ByOrderId";
		/// <summary>
		/// Get order count
		/// </summary>
		public const string FIN_Finance_Get_OrderCount = "FIN_Finance_Get_OrderCount";
		/// <summary>
		/// Thống kê tiền bản quyền theo tháng
		/// </summary>
		public const string FIN_Finance_Get_TotalLoyalty = "FIN_Finance_Get_TotalLoyalty";
		/// <summary>
		/// Thống kê thông tin insight các skus của creator
		/// </summary>
		public const string FIN_Finance_Get_CreatorInsightSKUs = "FIN_Finance_Get_CreatorInsightSKUs";
		#endregion

		#region Feed
		public const string FEED_PostMainComment_Get_Paging = "FEED_PostMainComment_Get_Paging";
		public const string FEED_PostSubComment_Get_Paging = "FEED_PostSubComment_Get_Paging";
		#endregion

		#region FlexiCombo
		/// <summary>
		/// lấy danh sách sản phẩm suggest sẽ apply cho admin
		/// </summary>
		public const string FLEX_SuggestAppliedProduct = "FLEX_SuggestAppliedProduct";
		/// <summary>
		/// lấy danh sách sản phẩm gifted
		/// </summary>
		public const string FLEX_SuggestGiftProduct = "FLEX_SuggestGiftProduct";
		/// <summary>
		/// Lấy danh sách variant id được chọn
		/// </summary>
		public const string FLEX_GetAppliedProductVariantId = "FLEX_GetAppliedProductVariantId";
		/// <summary>
		/// Lấy danh sách theo page
		/// </summary>
		public const string FLEX_GetPage = "FLEX_GetPage";
		/// <summary>
		/// Lấy thông tin theo id
		/// </summary>
		public const string FLEX_GetPageById = "FLEX_GetPageById";
		/// <summary>
		/// lấy thông tin product gift theo id
		/// </summary>
		public const string FLEX_GetFlexiComboGiftById = "FLEX_GetFlexiComboGiftById";
		/// <summary>
		/// lấy danh sách product applied theo id
		/// </summary>
		public const string Flex_GetProductAppliedById = "Flex_GetProductAppliedById";
		/// <summary>
		/// lấy sản phẩm tặng theo list id
		/// </summary>
		public const string FLEX_GetFlexiComboGiftByListId = "FLEX_GetFlexiComboGiftByListId";
		#endregion

		#region Affiliate
		/// <summary>
		/// Lấy danh sách affiliate products
		/// </summary>
		public const string App_Affiliate_Get_Page_Products = "App_Affiliate_Get_Page_Products";
		/// <summary>
		/// lấy affiliate products dựa vào product variant & thirdparty
		/// </summary>
		public const string App_Affiliate_Get_Product_ByVariant = "App_Affiliate_Get_Product_ByVariant";
		/// <summary>
		/// lấy thông tin affiliate theo code
		/// </summary>
		public const string App_Affiliate_Get_By_Code = "App_Affiliate_Get_By_Code";
		/// <summary>
		/// lấy mã code theo tracing log uuid
		/// </summary>
		public const string App_AffiliateCode_Get_By_UUID = "App_AffiliateCode_Get_By_UUID";
		/// <summary>
		/// Lấy danh sách các chiến dịch đang hoạt động
		/// </summary>
		public const string App_Affiliate_Get_Campaigns = "App_Affiliate_Get_Campaigns";
		/// <summary>
		/// Lấy danh sách các sản phẩm trong 1 chiến dịch
		/// </summary>
		public const string App_Affiliate_Get_Product_ByCampaign = "App_Affiliate_Get_Product_ByCampaign";
		/// <summary>
		/// Dánh sách sản phẩm và hoa hồng nhận được trong tháng
		/// </summary>
		public const string App_Affiliate_Get_ProductAndCommission = "App_Affiliate_Get_ProductAndCommission";
		/// <summary>
		/// Dánh sách các cấu hình về % hoa hồng cho affiliate
		/// </summary>
		public const string App_Affiliate_Get_CommissionConfigs = "App_Affiliate_Get_CommissionConfigs";
		/// <summary>
		/// Thống kê hoa hồng nhận được của 3rd-party
		/// </summary>
		public const string App_Affiliate_Get_TotalCommissions = "App_Affiliate_Get_TotalCommissions";
		/// <summary>
		/// Filter danh sách set products
		/// </summary>
		public const string App_Set_Get_Page_Products = "App_Set_Get_Page_Products";
		/// <summary>
		/// Get boosting set products.
		/// </summary>
		public const string App_Set_Get_Page_ProductsBoosting = "App_Set_Get_Page_ProductsBoosting";
		/// <summary>
		/// Get commission configs by order id.
		/// </summary>
		public const string App_Affiliate_Get_CommissionConfigs_ByOrderId = "App_Affiliate_Get_CommissionConfigs_ByOrderId";
		/// <summary>
		/// Get order commission
		/// </summary>
		public const string App_Affiliate_Get_OrderCommissions = "App_Affiliate_Get_OrderCommissions";
		/// <summary>
		/// Get order counts
		/// </summary>
		public const string App_Affiliate_Get_OrderCount = "App_Affiliate_Get_OrderCount";
		/// <summary>
		/// lấy danh sách affiliate site theo page
		/// </summary>
		public const string App_AffiliateSite_GetPage = "App_AffiliateSite_GetPage";
		public const string App_Affiliate_Get_Traffic = "App_Affiliate_Get_Traffic";
		/// <summary>
		/// Lấy danh sách product cho VIP Affiliate
		/// </summary>
		public const string App_Affiliate_Get_MarketingProducts = "App_Affiliate_Get_MarketingProducts";
		public const string App_Affiliate_Get_MarketingProduct_BySetId = "App_Affiliate_Get_MarketingProduct_BySetId";
		/// <summary>
		/// Lay danh sach VIP affiliator
		/// </summary>
		public const string App_Affiliate_Get_VipAffiliators = "App_Affiliate_Get_VipAffiliators";
		/// <summary>
		/// Get  Vip affiliate theo Group
		/// </summary>
		public const string App_Affiliate_Get_VipAffiliators_ByGroup = "App_Affiliate_Get_VipAffiliators_ByGroup";
		/// <summary>
		/// Get Vip affiliator by ID
		/// </summary>
		public const string App_Affiliate_Get_VipAffiliator = "App_Affiliate_Get_VipAffiliator";
		/// <summary>
		/// Get product by campaign
		/// </summary>
		public const string App_Affiliate_Get_VIPCampaignProducts = "App_Affiliate_Get_VIPCampaignProducts";
		/// <summary>
		/// Lay danh sach chien dich
		/// </summary>
		public const string App_Affiliate_Get_VIPCampaigns = "App_Affiliate_Get_VIPCampaigns";
		/// <summary>
		/// Get list sharing
		/// </summary>
		public const string App_Affiliate_Get_ListSharings = "App_Affiliate_Get_ListSharings";
		/// <summary>
		/// check cash back
		/// </summary>
		public const string App_Affiliate_Check_Cashback = "App_Affiliate_Check_Cashback";
		/// <summary>
		/// Get list refunds
		/// </summary>
		public const string App_Affiliate_Get_ListRefunds = "App_Affiliate_Get_ListRefunds";
		/// <summary>
		/// Get product reviews
		/// </summary>
		public const string App_Affiliate_Get_ProductReviews = "App_Affiliate_Get_ProductReviews";
		#endregion

		#region TRA
		/// <summary>
		/// lấy tracing log theo user id
		/// </summary>
		public const string TRA_Tracking_Get_ByUserId = "TRA_Tracking_Get_ByUserId";
		#endregion

		#region Voucher Spinner Scheme
		public const string App_GetSpinnerScheme_ByCode = "App_GetSpinnerScheme_ByCode";
		#endregion

		#region MTO
		public const string MTO_Categories_Get_Page = "MTO_Categories_Get_Page";
		public const string MTO_Get_Design_By_Category_Id = "MTO_Get_Design_By_Category_Id";
		public const string MTO_Filter_Design_By_Keyword = "MTO_Filter_Design_By_Keyword";
		public const string MTO_Filter_Category_By_Keyword = "MTO_Filter_Category_By_Keyword";
		#endregion

		#region Blog
		public const string Blog_Categories_Get_Page = "Blog_Categories_Get_Page";
		public const string Blog_Active_Categories_Get_Page = "Blog_Active_Categories_Get_Page";
		public const string Blog_Get_Page = "Blog_Get_Page";
		public const string Blog_Active_Get_Page = "Blog_Active_Get_Page";
		public const string Get_Blog_By_CategoryId = "Get_Blog_By_CategoryId";
		public const string Blog_Get_Keywords = "Blog_Get_Keywords";
		public const string Blog_Active_Get_Page_By_Flag = "Blog_Active_Get_Page_By_Flag";
		public const string BlogGetPageByTag = "BlogGetPageByTag";
		public const string Blog_Get_Keyword_By_Id = "Blog_Get_Keyword_By_Id";
		public const string Blog_Get_Keyword_Parent = "Blog_Get_Keyword_Parent";
		#endregion

		#region Target Group 
		public const string App_TargetGroupWinner_Get_Page = "App_TargetGroupWinner_Get_Page";
		public const string App_TargetGroupWinner_Get_DropdownUserName = "App_TargetGroupWinner_Get_DropdownUserName";
		public const string App_TargetGroupWinner_Get_DropdownGroupId = "App_TargetGroupWinner_Get_DropdownGroupId";
		public const string App_TargetGroupWinner_Get_DropdownVoucherId = "App_TargetGroupWinner_Get_DropdownVoucherId";
		#endregion

		#region SEA
		/// <summary>
		/// Search Products
		/// </summary>
		public const string SEA_Suggest_Products = "SEA_Suggest_Products";
		/// <summary>
		/// New Products
		/// </summary>
		public const string SEA_Get_New_Products = "SEA_Get_New_Products";
		/// <summary>
		/// Products has good price
		/// </summary>
		public const string SEA_Get_GoodPrice_Products = "SEA_Get_GoodPrice_Products";
		/// <summary>
		/// Mark all input set ids be unClick
		/// </summary>
		public const string SEA_Mark_UnClick = "SEA_Mark_UnClick";
		/// <summary>
		/// Get suggest set by collectionId
		/// </summary>
		public const string SEA_GetSuggestSet_ByCollectionId = "SEA_GetSuggestSet_ByCollectionId";
		public const string TK_Ticket_Get_Page = "TK_Ticket_Get_Page";
		#endregion

		#region MTO
		public const string MTO_Product_Get_Page = "MTO_Product_Get_Page";
		#endregion

		#region Job
		public const string Job_GetPage = "Job_GetPage";
		public const string Job_GetPageServices = "Job_GetPageServices";
		public const string Job_CheckAndAddJobQueue = "Job_CheckAndAddJobQueue";
		public const string Job_ProductId_SetId = "Job_ProductId_SetId";
		public const string Job_ProductId_AppProductId = "Job_ProductId_AppProductId";
		public const string Job_RenderImage_GetPageServices = "Job_RenderImage_GetPageServices";
		public const string Job_RenderImageDTO_UpdateRange = "Job_RenderImageDTO_UpdateRange";
		public const string Job_RenderCollection_GetPageServices = "Job_RenderCollection_GetPageServices";
		public const string JOB_RenderCollection_GetById = "JOB_RenderCollection_GetById";
		public const string Job_RenderCollection_UpdateStatus = "Job_RenderCollection_UpdateStatus";
		public const string Job_ProcessArtwork_GetPageServices = "Job_ProcessArtwork_GetPageServices";
		public const string Job_ProcessArtwork_UpdateStatus = "Job_ProcessArtwork_UpdateStatus";
		#endregion

		#region Collection
		public const string COL_TemplateType_Get_Page = "COL_TemplateType_Get_Page";
		public const string COL_Poster_Get_Page = "COL_Poster_Get_Page";
		public const string COL_Poster_Get_GroupId = "COL_Poster_Get_GroupId";
		public const string COL_Poster_GetVariant_Page = "COL_Poster_GetVariant_Page";
		public const string COL_Poster_GetVariant_ByProductId = "COL_Poster_GetVariant_ByProductId";
		public const string COL_Font_Get_Page = "COL_Font_Get_Page";
		public const string COL_MainColor_Get_Page = "COL_MainColor_Get_Page";
		public const string COL_CreatorCollection_Get_Page = "COL_CreatorCollection_Get_Page";
		public const string COL_CreatorCollection_GetById = "COL_CreatorCollection_GetById";
		public const string COL_CollectionPosterArtwork_Insert = "COL_CollectionPosterArtwork_Insert";
		public const string COL_CreatorCollection_UpdateStatus = "COL_CreatorCollection_UpdateStatus";
		public const string COL_CreatorCollection_Get_ByAgencyId = "COL_CreatorCollection_Get_ByAgencyId";
		public const string COL_CreatorCollection_Get_Id = "COL_CreatorCollection_Get_Id";
		public const string COL_CollectionComment_Get_Page = "COL_CollectionComment_Get_Page";
		public const string COL_Topic_Get_Page = "COL_Topic_Get_Page";
		public const string COL_Brand_Get_Page = "COL_Brand_Get_Page";
		#endregion

		#region ShippingAddress
		public const string App_ShippingAddress_Get_UserName = "App_ShippingAddress_Get_UserName";
		#endregion

		#region Search
		/// <summary>
		/// Get bộ lọc cho phần search.
		/// </summary>
		public const string SEA_Get_Filters = "SEA_Get_Filters";
		public const string SEA_Get_Filters_Store = "SEA_Get_Filters_Store";
		#endregion

		#region SEO
		public const string SEO_Product_GetAll = "SEO_Product_GetAll";
		#endregion

		#region Help
		public const string Help_TypeQuestion_Get_Page = "Help_TypeQuestion_Get_Page";
		public const string Help_AnswerContent_ByPage = "Help_AnswerContent_ByPage";
		public const string Help_TypeQuestion_Get_By_Id = "Help_TypeQuestion_Get_By_Id";
		public const string Help_AnswerContent_ByTypeQuestionId = "Help_AnswerContent_ByTypeQuestionId";
		public const string Help_AnswerContent_ByFlag = "Help_AnswerContent_ByFlag";
		public const string Help_AnswerContent_ByKeyWordOrTypeID = "Help_AnswerContent_ByKeyWordOrTypeID";
		#endregion

		#region Artist
		public const string ART_User_Get_ByPage = "ART_User_Get_ByPage";
		public const string ART_Get_Folder_By_User = "ART_Get_Folder_By_User";
		public const string ART_Get_Artwork_By_FolderId = "ART_Get_Artwork_By_FolderId";
		public const string ART_Get_Artist_ById = "ART_Get_Artist_ById";
		#endregion

		#region Social
		public const string SOC_Account_Get_Page = "SOC_Account_Get_Page";
		#endregion

		public const string COL_CreatorCollectionShow_GetAll = "COL_CreatorCollectionShow_GetAll";
		public const string COL_CreatorCollection_ByKeyword = "COL_CreatorCollection_ByKeyword";
	}
}
