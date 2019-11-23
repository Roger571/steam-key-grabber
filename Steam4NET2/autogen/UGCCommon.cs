// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Steam4NET
{

	public enum EUGCQuery : int
	{
		k_EUGCQuery_RankedByVote = 0,
		k_EUGCQuery_RankedByPublicationDate = 1,
		k_EUGCQuery_AcceptedForGameRankedByAcceptanceDate = 2,
		k_EUGCQuery_RankedByTrend = 3,
		k_EUGCQuery_FavoritedByFriendsRankedByPublicationDate = 4,
		k_EUGCQuery_CreatedByFriendsRankedByPublicationDate = 5,
		k_EUGCQuery_RankedByNumTimesReported = 6,
		k_EUGCQuery_CreatedByFollowedUsersRankedByPublicationDate = 7,
		k_EUGCQuery_NotYetRated = 8,
		k_EUGCQuery_RankedByTotalVotesAsc = 9,
		k_EUGCQuery_RankedByVotesUp = 10,
		k_EUGCQuery_RankedByTextSearch = 11,
		k_EUGCQuery_RankedByTotalUniqueSubscriptions = 12,
	};
	
	public enum EUserUGCList : int
	{
		k_EUserUGCList_Published = 0,
		k_EUserUGCList_VotedOn = 1,
		k_EUserUGCList_VotedUp = 2,
		k_EUserUGCList_VotedDown = 3,
		k_EUserUGCList_WillVoteLater = 4,
		k_EUserUGCList_Favorited = 5,
		k_EUserUGCList_Subscribed = 6,
		k_EUserUGCList_UsedOrPlayed = 7,
		k_EUserUGCList_Followed = 8,
	};
	
	public enum EUGCMatchingUGCType : int
	{
		k_EUGCMatchingUGCType_Items = 0,
		k_EUGCMatchingUGCType_Items_Mtx = 1,
		k_EUGCMatchingUGCType_Items_ReadyToUse = 2,
		k_EUGCMatchingUGCType_Collections = 3,
		k_EUGCMatchingUGCType_Artwork = 4,
		k_EUGCMatchingUGCType_Videos = 5,
		k_EUGCMatchingUGCType_Screenshots = 6,
		k_EUGCMatchingUGCType_AllGuides = 7,
		k_EUGCMatchingUGCType_WebGuides = 8,
		k_EUGCMatchingUGCType_IntegratedGuides = 9,
		k_EUGCMatchingUGCType_UsableInGame = 10,
		k_EUGCMatchingUGCType_ControllerBindings = 11,
	};
	
	public enum EUserUGCListSortOrder : int
	{
		k_EUserUGCListSortOrder_CreationOrderDesc = 0,
		k_EUserUGCListSortOrder_CreationOrderAsc = 1,
		k_EUserUGCListSortOrder_TitleAsc = 2,
		k_EUserUGCListSortOrder_LastUpdatedDesc = 3,
		k_EUserUGCListSortOrder_SubscriptionDateDesc = 4,
		k_EUserUGCListSortOrder_VoteScoreDesc = 5,
		k_EUserUGCListSortOrder_ForModeration = 6,
	};
	
	[StructLayout(LayoutKind.Sequential,Pack=8)]
	public struct SteamUGCDetails_t
	{
		public UInt64 m_nPublishedFileId;
		public EResult m_eResult;
		public EWorkshopFileType m_eFileType;
		public UInt32 m_nCreatorAppID;
		public UInt32 m_nConsumerAppID;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
		public string m_rgchTitle;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8000)]
		public string m_rgchDescription;
		public UInt64 m_ulSteamIDOwner;
		public UInt32 m_rtimeCreated;
		public UInt32 m_rtimeUpdated;
		public UInt32 m_rtimeAddedToUserList;
		public ERemoteStoragePublishedFileVisibility m_eVisibility;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bBanned;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bAcceptedForUse;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bTagsTruncated;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1025)]
		public string m_rgchTags;
		public UInt64 m_hFile;
		public UInt64 m_hPreviewFile;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string m_pchFileName;
		public Int32 m_nFileSize;
		public Int32 m_nPreviewFileSize;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string m_rgchURL;
		public UInt32 m_unVotesUp;
		public UInt32 m_unVotesDown;
		public float m_flScore;
		public UInt32 m_unNumChildren;
	};
	
	public enum EItemUpdateStatus : int
	{
		k_EItemUpdateStatusInvalid = 0,
		k_EItemUpdateStatusPreparingConfig = 1,
		k_EItemUpdateStatusPreparingContent = 2,
		k_EItemUpdateStatusUploadingContent = 3,
		k_EItemUpdateStatusUploadingPreviewFile = 4,
		k_EItemUpdateStatusCommittingChanges = 5,
	};
	
	[StructLayout(LayoutKind.Sequential,Pack=8)]
	[InteropHelp.CallbackIdentity(3401)]
	public struct SteamUGCQueryCompleted_t
	{
		public const int k_iCallback = 3401;
		public UInt64 m_handle;
		public EResult m_eResult;
		public UInt32 m_unNumResultsReturned;
		public UInt32 m_unTotalMatchingResults;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;
	};
	
	[StructLayout(LayoutKind.Sequential,Pack=8)]
	[InteropHelp.CallbackIdentity(3402)]
	public struct SteamUGCRequestUGCDetailsResult_t
	{
		public const int k_iCallback = 3402;
		public SteamUGCDetails_t m_details;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bCachedData;
	};
	
	[StructLayout(LayoutKind.Sequential,Pack=8)]
	[InteropHelp.CallbackIdentity(3403)]
	public struct CreateItemResult_t
	{
		public const int k_iCallback = 3403;
		public EResult m_eResult;
		public UInt64 m_nPublishedFileId;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	};
	
	[StructLayout(LayoutKind.Sequential,Pack=8)]
	[InteropHelp.CallbackIdentity(3404)]
	public struct SubmitItemUpdateResult_t
	{
		public const int k_iCallback = 3404;
		public EResult m_eResult;
		[MarshalAs(UnmanagedType.I1)]
		public bool m_bUserNeedsToAcceptWorkshopLegalAgreement;
	};
	
	[StructLayout(LayoutKind.Sequential,Pack=8)]
	[InteropHelp.CallbackIdentity(3405)]
	public struct ItemInstalled_t
	{
		public const int k_iCallback = 3405;
		public UInt32 m_unAppID;
		public UInt64 m_nPublishedFileId;
	};
	
}
