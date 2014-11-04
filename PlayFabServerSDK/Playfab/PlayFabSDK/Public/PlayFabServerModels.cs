using System;
using System.Collections.Generic;
using PlayFab.Internal;

namespace PlayFab.ServerModels
{
	
	
	
	public class AddUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be incremented
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// name of the virtual currency which is to be incremented
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be added to the user balance of the specified virtual currency
		/// </summary>
		
		public int Amount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Amount = (int)JsonUtil.Get<double?>(json, "Amount");
		}
	}
	
	
	
	public class AwardSteamAchievementItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user who is to be granted the specified Steam achievement
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique Steam achievement name
		/// </summary>
		
		public string AchievementName { get; set;}
		
		/// <summary>
		/// result of the award attempt (only valid on response, not on request)
		/// </summary>
		
		public bool Result { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			AchievementName = (string)JsonUtil.Get<string>(json, "AchievementName");
			Result = (bool)JsonUtil.Get<bool?>(json, "Result");
		}
	}
	
	
	
	public class AwardSteamAchievementRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of achievements to grant and the users to whom they are to be granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> Achievements { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Achievements = JsonUtil.GetObjectList<AwardSteamAchievementItem>(json, "Achievements");
		}
	}
	
	
	
	public class AwardSteamAchievementResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of achievements granted
		/// </summary>
		
		public List<AwardSteamAchievementItem> AchievementResults { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AchievementResults = JsonUtil.GetObjectList<AwardSteamAchievementItem>(json, "AchievementResults");
		}
	}
	
	
	
	/// <summary>
	/// A purchasable item from the item catalog
	/// </summary>
	public class CatalogItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for this item
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// class to which the item belongs
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// catalog item for this item
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// text name for the item, to show in-game
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// text description of item, to show in-game
		/// </summary>
		
		public string Description { get; set;}
		
		/// <summary>
		/// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// override prices for this item for specific currencies
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// the date this item becomes available for purchase
		/// </summary>
		
		public DateTime? ReleaseDate { get; set;}
		
		/// <summary>
		/// the date this item will no longer be available for purchase
		/// </summary>
		
		public DateTime? ExpirationDate { get; set;}
		
		/// <summary>
		/// (deprecated)
		/// </summary>
		
		public bool? IsFree { get; set;}
		
		/// <summary>
		/// can this item be purchased (if not, it can still be granted by a server-based operation, such as a loot drop from a monster)
		/// </summary>
		
		public bool? NotForSale { get; set;}
		
		/// <summary>
		/// can an instance of this item be exchanged between players?
		/// </summary>
		
		public bool? NotForTrade { get; set;}
		
		/// <summary>
		/// list of item tags
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// game specific custom data
		/// </summary>
		
		public string CustomData { get; set;}
		
		/// <summary>
		/// array of ItemId values which are evaluated when any item is added to the player inventory - if all items in this array are present, the this item will also be added to the player inventory
		/// </summary>
		
		public List<string> GrantedIfPlayerHas { get; set;}
		
		/// <summary>
		/// defines the consumable properties (number of uses, timeout) for the item
		/// </summary>
		
		public CatalogItemConsumableInfo Consumable { get; set;}
		
		/// <summary>
		/// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
		/// </summary>
		
		public CatalogItemContainerInfo Container { get; set;}
		
		/// <summary>
		/// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
		/// </summary>
		
		public CatalogItemBundleInfo Bundle { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Description = (string)JsonUtil.Get<string>(json, "Description");
			VirtualCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyPrices");
			RealCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "RealCurrencyPrices");
			ReleaseDate = (DateTime?)JsonUtil.GetDateTime(json, "ReleaseDate");
			ExpirationDate = (DateTime?)JsonUtil.GetDateTime(json, "ExpirationDate");
			IsFree = (bool?)JsonUtil.Get<bool?>(json, "IsFree");
			NotForSale = (bool?)JsonUtil.Get<bool?>(json, "NotForSale");
			NotForTrade = (bool?)JsonUtil.Get<bool?>(json, "NotForTrade");
			Tags = JsonUtil.GetList<string>(json, "Tags");
			CustomData = (string)JsonUtil.Get<string>(json, "CustomData");
			GrantedIfPlayerHas = JsonUtil.GetList<string>(json, "GrantedIfPlayerHas");
			Consumable = JsonUtil.GetObject<CatalogItemConsumableInfo>(json, "Consumable");
			Container = JsonUtil.GetObject<CatalogItemContainerInfo>(json, "Container");
			Bundle = JsonUtil.GetObject<CatalogItemBundleInfo>(json, "Bundle");
		}
	}
	
	
	
	public class CatalogItemBundleInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory when the bundle is added
		/// </summary>
		
		public List<string> BundledItems { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
		/// </summary>
		
		public List<string> BundledResultTables { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the bundle is added
		/// </summary>
		
		public Dictionary<string,uint> BundledVirtualCurrencies { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BundledItems = JsonUtil.GetList<string>(json, "BundledItems");
			BundledResultTables = JsonUtil.GetList<string>(json, "BundledResultTables");
			BundledVirtualCurrencies = JsonUtil.GetDictionaryUInt32(json, "BundledVirtualCurrencies");
		}
	}
	
	
	
	public class CatalogItemConsumableInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// number of times this object can be used, after which it will be removed from the player inventory
		/// </summary>
		
		public uint? UsageCount { get; set;}
		
		/// <summary>
		/// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
		/// </summary>
		
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
		/// </summary>
		
		public string UsagePeriodGroup { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UsageCount = (uint?)JsonUtil.Get<double?>(json, "UsageCount");
			UsagePeriod = (uint?)JsonUtil.Get<double?>(json, "UsagePeriod");
			UsagePeriodGroup = (string)JsonUtil.Get<string>(json, "UsagePeriodGroup");
		}
	}
	
	
	
	/// <summary>
	/// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
	/// </summary>
	public class CatalogItemContainerInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will open the container, adding the contents to the player inventory and currency balances)
		/// </summary>
		
		public string KeyItemId { get; set;}
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
		/// </summary>
		
		public List<string> ItemContents { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
		/// </summary>
		
		public List<string> ResultTableContents { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the container is unlocked
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyContents { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			KeyItemId = (string)JsonUtil.Get<string>(json, "KeyItemId");
			ItemContents = JsonUtil.GetList<string>(json, "ItemContents");
			ResultTableContents = JsonUtil.GetList<string>(json, "ResultTableContents");
			VirtualCurrencyContents = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyContents");
		}
	}
	
	
	
	public enum Currency
	{
		USD,
		GBP,
		EUR,
		RUB,
		BRL,
		CIS,
		CAD
	}
	
	
	
	public class GetCatalogItemsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// which catalog is being requested
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class GetCatalogItemsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of items which can be purchased
		/// </summary>
		
		public List<CatalogItem> Catalog { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Catalog = JsonUtil.GetObjectList<CatalogItem>(json, "Catalog");
		}
	}
	
	
	
	public class GetLeaderboardAroundUserRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title-specific statistic for the leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the user to be centered in the list of entries
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetLeaderboardAroundUserResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ordered list of leaderboard entries
		/// </summary>
		
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Leaderboard = JsonUtil.GetObjectList<PlayerLeaderboardEntry>(json, "Leaderboard");
		}
	}
	
	
	
	public class GetLeaderboardRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the title-specific statistic for the leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// first entry in the leaderboard to be retrieved
		/// </summary>
		
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			StartPosition = (int)JsonUtil.Get<double?>(json, "StartPosition");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetLeaderboardResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ordered list of leaderboard entries
		/// </summary>
		
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Leaderboard = JsonUtil.GetObjectList<PlayerLeaderboardEntry>(json, "Leaderboard");
		}
	}
	
	
	
	public class GetTitleDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		///  array of keys to get back data from the TitleData data blob, set by the admin tools
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Keys = JsonUtil.GetList<string>(json, "Keys");
		}
	}
	
	
	
	public class GetTitleDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetDictionary<string>(json, "Data");
		}
	}
	
	
	
	public class GetUserAccountInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class GetUserAccountInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose information was requested
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserInfo = JsonUtil.GetObject<UserAccountInfo>(json, "UserInfo");
		}
	}
	
	
	
	public class GetUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// specific keys to search for in the custom user data
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Keys = JsonUtil.GetList<string>(json, "Keys");
		}
	}
	
	
	
	public class GetUserDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being returned
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Data = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "Data");
		}
	}
	
	
	
	public class GetUserInventoryRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose inventory is being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// used to limit results to only those from a specific catalog version
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class GetUserInventoryResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of inventory items belonging to the user
		/// </summary>
		
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Inventory = JsonUtil.GetObjectList<ItemInstance>(json, "Inventory");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
		}
	}
	
	
	
	public class GetUserStatisticsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user for whom statistics are being requested
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class GetUserStatisticsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user statistics for the requested user
		/// </summary>
		
		public Dictionary<string,int> UserStatistics { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserStatistics = JsonUtil.GetDictionaryInt32(json, "UserStatistics");
		}
	}
	
	
	
	public class GrantItemsToUsersRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// catalog version from which items are to be granted
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// array of items to grant and the users to whom the items are to be granted
		/// </summary>
		
		public List<ItemGrant> ItemGrants { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			ItemGrants = JsonUtil.GetObjectList<ItemGrant>(json, "ItemGrants");
		}
	}
	
	
	
	public class GrantItemsToUsersResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of items granted to users
		/// </summary>
		
		public List<ItemGrantResult> ItemGrantResults { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemGrantResults = JsonUtil.GetObjectList<ItemGrantResult>(json, "ItemGrantResults");
		}
	}
	
	
	
	public class ItemGrant : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		
		public string Annotation { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
		}
	}
	
	
	
	/// <summary>
	/// Result of granting an item to a user
	/// </summary>
	public class ItemGrantResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user to whom the catalog item is to be granted
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// unique identifier of the catalog item to be granted to the user
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique instance Id of the granted item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// string detailing any additional information concerning this operation
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// result of this operation
		/// </summary>
		
		public bool Result { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			Result = (bool)JsonUtil.Get<bool?>(json, "Result");
		}
	}
	
	
	
	/// <summary>
	/// A unique instance of an item in a user's inventory
	/// </summary>
	public class ItemInstance : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the inventory item, as defined in the catalog
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item identifier for this specific instance of the item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name for the inventory item, as defined in the catalog
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// timestamp for when this instance was purchased
		/// </summary>
		
		public DateTime? PurchaseDate { get; set;}
		
		/// <summary>
		/// timestamp for when this instance will expire
		/// </summary>
		
		public DateTime? Expiration { get; set;}
		
		/// <summary>
		/// total number of remaining uses, if this is a consumable item
		/// </summary>
		
		public int? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment associated with this instance when it was added to the user inventory
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version for the inventory item, when this instance was created
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container
		/// </summary>
		
		public string BundleParent { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			PurchaseDate = (DateTime?)JsonUtil.GetDateTime(json, "PurchaseDate");
			Expiration = (DateTime?)JsonUtil.GetDateTime(json, "Expiration");
			RemainingUses = (int?)JsonUtil.Get<double?>(json, "RemainingUses");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			BundleParent = (string)JsonUtil.Get<string>(json, "BundleParent");
		}
	}
	
	
	
	public class ModifyUserVirtualCurrencyResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the virtual currency which was modified
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// balance of the virtual currency after modification
		/// </summary>
		
		public int Balance { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Balance = (int)JsonUtil.Get<double?>(json, "Balance");
		}
	}
	
	
	
	public class NotifyMatchmakerPlayerLeftRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the Game Server Instance the user is leaving
		/// </summary>
		
		public string ServerId { get; set;}
		
		/// <summary>
		/// PlayFab unique identifier of the user that is leaving the Game Server Instance
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ServerId = (string)JsonUtil.Get<string>(json, "ServerId");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class NotifyMatchmakerPlayerLeftResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// state of user leaving the Game Server Instance
		/// </summary>
		
		public PlayerConnectionState? PlayerState { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayerState = (PlayerConnectionState?)JsonUtil.GetEnum<PlayerConnectionState>(json, "PlayerState");
		}
	}
	
	
	
	public enum PlayerConnectionState
	{
		Unassigned,
		Connecting,
		Participating,
		Participated,
		Reconnecting
	}
	
	
	
	public class PlayerLeaderboardEntry : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user for this leaderboard entry
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// title-specific display name of the user for this leaderboard entry
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// specific value of the user's statistic
		/// </summary>
		
		public int StatValue { get; set;}
		
		/// <summary>
		/// user's overall position in the leaderboard
		/// </summary>
		
		public int Position { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			StatValue = (int)JsonUtil.Get<double?>(json, "StatValue");
			Position = (int)JsonUtil.Get<double?>(json, "Position");
		}
	}
	
	
	
	public class RedeemMatchmakerTicketRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// server authorization ticket passed back from a call to Matchmake or StartGame
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// IP Address of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string IP { get; set;}
		
		/// <summary>
		/// unique identifier of the Game Server Instance that is asking for validation of the authorization ticket
		/// </summary>
		
		public string ServerId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			IP = (string)JsonUtil.Get<string>(json, "IP");
			ServerId = (string)JsonUtil.Get<string>(json, "ServerId");
		}
	}
	
	
	
	public class RedeemMatchmakerTicketResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// boolean indicating whether the ticket was validated by the PlayFab service
		/// </summary>
		
		public bool TicketIsValid { get; set;}
		
		/// <summary>
		/// error value if the ticket was not validated
		/// </summary>
		
		public string Error { get; set;}
		
		/// <summary>
		/// user account information for the user validated
		/// </summary>
		
		public UserAccountInfo UserInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TicketIsValid = (bool)JsonUtil.Get<bool?>(json, "TicketIsValid");
			Error = (string)JsonUtil.Get<string>(json, "Error");
			UserInfo = JsonUtil.GetObject<UserAccountInfo>(json, "UserInfo");
		}
	}
	
	
	
	public class SendPushNotificationRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the recipient of the push notification
		/// </summary>
		
		public string Recipient { get; set;}
		
		/// <summary>
		/// text of message to send
		/// </summary>
		
		public string Message { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Recipient = (string)JsonUtil.Get<string>(json, "Recipient");
			Message = (string)JsonUtil.Get<string>(json, "Message");
		}
	}
	
	
	
	public class SendPushNotificationResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SetTitleDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
		/// </summary>
		
		public string Key { get; set;}
		
		/// <summary>
		/// new value to set
		/// </summary>
		
		public string Value { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Key = (string)JsonUtil.Get<string>(json, "Key");
			Value = (string)JsonUtil.Get<string>(json, "Value");
		}
	}
	
	
	
	public class SetTitleDataResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SubtractUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose virtual currency balance is to be decremented
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// name of the virtual currency which is to be decremented
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be subtracted from the user balance of the specified virtual currency
		/// </summary>
		
		public int Amount { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Amount = (int)JsonUtil.Get<double?>(json, "Amount");
		}
	}
	
	
	
	public enum TitleActivationStatus
	{
		None,
		ActivatedTitleKey,
		PendingSteam,
		ActivatedSteam,
		RevokedSteam
	}
	
	
	
	public class UpdateUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being updated
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// data to be written to the user's custom data. Keys are trimmed of whitespace. Keys may not begin with a '!' character.
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Data = JsonUtil.GetDictionary<string>(json, "Data");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UpdateUserDataResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserInternalDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user whose custom data is being updated
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// data to be written to the user's custom data
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Data = JsonUtil.GetDictionary<string>(json, "Data");
		}
	}
	
	
	
	public class UpdateUserStatisticsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user whose statistics are to be updated
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// statistics to be updated with the provided values
		/// </summary>
		
		public Dictionary<string,int> UserStatistics { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			UserStatistics = JsonUtil.GetDictionaryInt32(json, "UserStatistics");
		}
	}
	
	
	
	public class UpdateUserStatisticsResult : PlayFabModelBase
	{
		
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UserAccountInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the user account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user account was created
		/// </summary>
		
		public DateTime Created { get; set;}
		
		/// <summary>
		/// user account name in the PlayFab service
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific information for the user account
		/// </summary>
		
		public UserTitleInfo TitleInfo { get; set;}
		
		/// <summary>
		/// personal information for the user which is considered more sensitive
		/// </summary>
		
		public UserPrivateAccountInfo PrivateInfo { get; set;}
		
		/// <summary>
		/// user Facebook information, if a Facebook account has been linked
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// user Steam information, if a Steam account has been linked
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// user Gamecenter information, if a Gamecenter account has been linked
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Created = (DateTime)JsonUtil.GetDateTime(json, "Created");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleInfo = JsonUtil.GetObject<UserTitleInfo>(json, "TitleInfo");
			PrivateInfo = JsonUtil.GetObject<UserPrivateAccountInfo>(json, "PrivateInfo");
			FacebookInfo = JsonUtil.GetObject<UserFacebookInfo>(json, "FacebookInfo");
			SteamInfo = JsonUtil.GetObject<UserSteamInfo>(json, "SteamInfo");
			GameCenterInfo = JsonUtil.GetObject<UserGameCenterInfo>(json, "GameCenterInfo");
		}
	}
	
	
	
	public enum UserDataPermission
	{
		Private,
		Public
	}
	
	
	
	public class UserDataRecord : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user-supplied data for this user data key
		/// </summary>
		
		public string Value { get; set;}
		
		/// <summary>
		/// timestamp indicating when this data was last updated
		/// </summary>
		
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// Permissions on this data key
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Value = (string)JsonUtil.Get<string>(json, "Value");
			LastUpdated = (DateTime)JsonUtil.GetDateTime(json, "LastUpdated");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UserFacebookInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Facebook identifier
		/// </summary>
		
		public string FacebookId { get; set;}
		
		/// <summary>
		/// Facebook username
		/// </summary>
		
		public string FacebookUsername { get; set;}
		
		/// <summary>
		/// Facebook display name
		/// </summary>
		
		public string FacebookDisplayname { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FacebookId = (string)JsonUtil.Get<string>(json, "FacebookId");
			FacebookUsername = (string)JsonUtil.Get<string>(json, "FacebookUsername");
			FacebookDisplayname = (string)JsonUtil.Get<string>(json, "FacebookDisplayname");
		}
	}
	
	
	
	public class UserGameCenterInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Gamecenter identifier
		/// </summary>
		
		public string GameCenterId { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameCenterId = (string)JsonUtil.Get<string>(json, "GameCenterId");
		}
	}
	
	
	
	public enum UserOrigination
	{
		Organic,
		Steam,
		Google,
		Amazon,
		Facebook,
		Kongregate,
		GamersFirst,
		Unknown,
		IOS,
		LoadTest,
		Android,
		PSN,
		GameCenter
	}
	
	
	
	public class UserPrivateAccountInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user email address
		/// </summary>
		
		public string Email { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
		}
	}
	
	
	
	public class UserSteamInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Steam identifier
		/// </summary>
		
		public string SteamId { get; set;}
		
		/// <summary>
		/// the country in which the player resides, from Steam data
		/// </summary>
		
		public string SteamCountry { get; set;}
		
		/// <summary>
		/// currency type set in the user Steam account
		/// </summary>
		
		public Currency? SteamCurrency { get; set;}
		
		/// <summary>
		/// what stage of game ownership the user is listed as being in, from Steam
		/// </summary>
		
		public TitleActivationStatus? SteamActivationStatus { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SteamId = (string)JsonUtil.Get<string>(json, "SteamId");
			SteamCountry = (string)JsonUtil.Get<string>(json, "SteamCountry");
			SteamCurrency = (Currency?)JsonUtil.GetEnum<Currency>(json, "SteamCurrency");
			SteamActivationStatus = (TitleActivationStatus?)JsonUtil.GetEnum<TitleActivationStatus>(json, "SteamActivationStatus");
		}
	}
	
	
	
	public class UserTitleInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the user, as it is displayed in-game
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// source by which the user first joined the game, if known
		/// </summary>
		
		public UserOrigination? Origination { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
		/// </summary>
		
		public DateTime Created { get; set;}
		
		/// <summary>
		/// timestamp for the last user login for this title
		/// </summary>
		
		public DateTime? LastLogin { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
		/// </summary>
		
		public DateTime? FirstLogin { get; set;}
		
		/// <summary>
		/// boolean indicating whether or not the user is currently banned for a title
		/// </summary>
		
		public bool? isBanned { get; set;}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Origination = (UserOrigination?)JsonUtil.GetEnum<UserOrigination>(json, "Origination");
			Created = (DateTime)JsonUtil.GetDateTime(json, "Created");
			LastLogin = (DateTime?)JsonUtil.GetDateTime(json, "LastLogin");
			FirstLogin = (DateTime?)JsonUtil.GetDateTime(json, "FirstLogin");
			isBanned = (bool?)JsonUtil.Get<bool?>(json, "isBanned");
		}
	}
	
}
