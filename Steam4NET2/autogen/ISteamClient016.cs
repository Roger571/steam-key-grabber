// This file is automatically generated.
using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Steam4NET
{

	[StructLayout(LayoutKind.Sequential,Pack=4)]
	public class ISteamClient016VTable
	{
		public IntPtr CreateSteamPipe0;
		public IntPtr BReleaseSteamPipe1;
		public IntPtr ConnectToGlobalUser2;
		public IntPtr CreateLocalUser3;
		public IntPtr ReleaseUser4;
		public IntPtr GetISteamUser5;
		public IntPtr GetISteamGameServer6;
		public IntPtr SetLocalIPBinding7;
		public IntPtr GetISteamFriends8;
		public IntPtr GetISteamUtils9;
		public IntPtr GetISteamMatchmaking10;
		public IntPtr GetISteamMatchmakingServers11;
		public IntPtr GetISteamGenericInterface12;
		public IntPtr GetISteamUserStats13;
		public IntPtr GetISteamGameServerStats14;
		public IntPtr GetISteamApps15;
		public IntPtr GetISteamNetworking16;
		public IntPtr GetISteamRemoteStorage17;
		public IntPtr GetISteamScreenshots18;
		public IntPtr RunFrame19;
		public IntPtr GetIPCCallCount20;
		public IntPtr SetWarningMessageHook21;
		public IntPtr BShutdownIfAllPipesClosed22;
		public IntPtr GetISteamHTTP23;
		public IntPtr GetISteamUnifiedMessages24;
		public IntPtr GetISteamController25;
		public IntPtr GetISteamUGC26;
		public IntPtr GetISteamInventory27;
		public IntPtr GetISteamVideo28;
		public IntPtr GetISteamAppList29;
		public IntPtr GetISteamMusic30;
		public IntPtr GetISteamMusicRemote31;
		public IntPtr GetISteamHTMLSurface32;
		public IntPtr Set_SteamAPI_CPostAPIResultInProcess33;
		public IntPtr Remove_SteamAPI_CPostAPIResultInProcess34;
		public IntPtr Set_SteamAPI_CCheckCallbackRegisteredInProcess35;
		private IntPtr DTorISteamClient01636;
	};
	
	public class ISteamClient016 : InteropHelp.NativeWrapper<ISteamClient016VTable>
	{
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 NativeCreateSteamPipe( IntPtr thisptr );
		public Int32 CreateSteamPipe(  ) 
		{
			return this.GetFunction<NativeCreateSteamPipe>( this.Functions.CreateSteamPipe0 )( this.ObjectAddress ); 
		}
		
		[return: MarshalAs(UnmanagedType.I1)]
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate bool NativeBReleaseSteamPipeI( IntPtr thisptr, Int32 hSteamPipe );
		public bool BReleaseSteamPipe( Int32 hSteamPipe ) 
		{
			return this.GetFunction<NativeBReleaseSteamPipeI>( this.Functions.BReleaseSteamPipe1 )( this.ObjectAddress, hSteamPipe ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 NativeConnectToGlobalUserI( IntPtr thisptr, Int32 hSteamPipe );
		public Int32 ConnectToGlobalUser( Int32 hSteamPipe ) 
		{
			return this.GetFunction<NativeConnectToGlobalUserI>( this.Functions.ConnectToGlobalUser2 )( this.ObjectAddress, hSteamPipe ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate Int32 NativeCreateLocalUserIE( IntPtr thisptr, ref Int32 phSteamPipe, EAccountType eAccountType );
		public Int32 CreateLocalUser( ref Int32 phSteamPipe, EAccountType eAccountType ) 
		{
			return this.GetFunction<NativeCreateLocalUserIE>( this.Functions.CreateLocalUser3 )( this.ObjectAddress, ref phSteamPipe, eAccountType ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void NativeReleaseUserII( IntPtr thisptr, Int32 hSteamPipe, Int32 hUser );
		public void ReleaseUser( Int32 hSteamPipe, Int32 hUser ) 
		{
			this.GetFunction<NativeReleaseUserII>( this.Functions.ReleaseUser4 )( this.ObjectAddress, hSteamPipe, hUser ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamUserIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamUser<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamUserIIS>( this.Functions.GetISteamUser5 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamGameServerIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamGameServer<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamGameServerIIS>( this.Functions.GetISteamGameServer6 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void NativeSetLocalIPBindingUU( IntPtr thisptr, UInt32 unIP, UInt16 usPort );
		public void SetLocalIPBinding( UInt32 unIP, UInt16 usPort ) 
		{
			this.GetFunction<NativeSetLocalIPBindingUU>( this.Functions.SetLocalIPBinding7 )( this.ObjectAddress, unIP, usPort ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamFriendsIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamFriends<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamFriendsIIS>( this.Functions.GetISteamFriends8 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamUtilsIS( IntPtr thisptr, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamUtils<TClass>( Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamUtilsIS>( this.Functions.GetISteamUtils9 )( this.ObjectAddress, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamMatchmakingIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamMatchmaking<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamMatchmakingIIS>( this.Functions.GetISteamMatchmaking10 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamMatchmakingServersIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamMatchmakingServers<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamMatchmakingServersIIS>( this.Functions.GetISteamMatchmakingServers11 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamGenericInterfaceIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamGenericInterface<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamGenericInterfaceIIS>( this.Functions.GetISteamGenericInterface12 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamUserStatsIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamUserStats<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamUserStatsIIS>( this.Functions.GetISteamUserStats13 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamGameServerStatsIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamGameServerStats<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamGameServerStatsIIS>( this.Functions.GetISteamGameServerStats14 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamAppsIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamApps<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamAppsIIS>( this.Functions.GetISteamApps15 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamNetworkingIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamNetworking<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamNetworkingIIS>( this.Functions.GetISteamNetworking16 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamRemoteStorageIIS( IntPtr thisptr, Int32 hSteamuser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamRemoteStorage<TClass>( Int32 hSteamuser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamRemoteStorageIIS>( this.Functions.GetISteamRemoteStorage17 )( this.ObjectAddress, hSteamuser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamScreenshotsIIS( IntPtr thisptr, Int32 hSteamuser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamScreenshots<TClass>( Int32 hSteamuser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamScreenshotsIIS>( this.Functions.GetISteamScreenshots18 )( this.ObjectAddress, hSteamuser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void NativeRunFrame( IntPtr thisptr );
		public void RunFrame(  ) 
		{
			this.GetFunction<NativeRunFrame>( this.Functions.RunFrame19 )( this.ObjectAddress ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate UInt32 NativeGetIPCCallCount( IntPtr thisptr );
		public UInt32 GetIPCCallCount(  ) 
		{
			return this.GetFunction<NativeGetIPCCallCount>( this.Functions.GetIPCCallCount20 )( this.ObjectAddress ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void NativeSetWarningMessageHookI( IntPtr thisptr, ref IntPtr pFunction );
		public void SetWarningMessageHook( ref IntPtr pFunction ) 
		{
			this.GetFunction<NativeSetWarningMessageHookI>( this.Functions.SetWarningMessageHook21 )( this.ObjectAddress, ref pFunction ); 
		}
		
		[return: MarshalAs(UnmanagedType.I1)]
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate bool NativeBShutdownIfAllPipesClosed( IntPtr thisptr );
		public bool BShutdownIfAllPipesClosed(  ) 
		{
			return this.GetFunction<NativeBShutdownIfAllPipesClosed>( this.Functions.BShutdownIfAllPipesClosed22 )( this.ObjectAddress ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamHTTPIIS( IntPtr thisptr, Int32 hSteamuser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamHTTP<TClass>( Int32 hSteamuser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamHTTPIIS>( this.Functions.GetISteamHTTP23 )( this.ObjectAddress, hSteamuser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamUnifiedMessagesIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamUnifiedMessages<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamUnifiedMessagesIIS>( this.Functions.GetISteamUnifiedMessages24 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamControllerIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamController<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamControllerIIS>( this.Functions.GetISteamController25 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamUGCIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamUGC<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamUGCIIS>( this.Functions.GetISteamUGC26 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamInventoryIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamInventory<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamInventoryIIS>( this.Functions.GetISteamInventory27 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamVideoIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamVideo<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamVideoIIS>( this.Functions.GetISteamVideo28 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamAppListIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamAppList<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamAppListIIS>( this.Functions.GetISteamAppList29 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamMusicIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamMusic<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamMusicIIS>( this.Functions.GetISteamMusic30 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamMusicRemoteIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamMusicRemote<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamMusicRemoteIIS>( this.Functions.GetISteamMusicRemote31 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate IntPtr NativeGetISteamHTMLSurfaceIIS( IntPtr thisptr, Int32 hSteamUser, Int32 hSteamPipe, string pchVersion );
		public TClass GetISteamHTMLSurface<TClass>( Int32 hSteamUser, Int32 hSteamPipe ) where TClass : InteropHelp.INativeWrapper, new()
		{
			return InteropHelp.CastInterface<TClass>( this.GetFunction<NativeGetISteamHTMLSurfaceIIS>( this.Functions.GetISteamHTMLSurface32 )( this.ObjectAddress, hSteamUser, hSteamPipe, InterfaceVersions.GetInterfaceIdentifier( typeof( TClass ) ) ) ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void NativeSet_SteamAPI_CPostAPIResultInProcessI( IntPtr thisptr, ref IntPtr arg0 );
		public void Set_SteamAPI_CPostAPIResultInProcess( ref IntPtr arg0 ) 
		{
			this.GetFunction<NativeSet_SteamAPI_CPostAPIResultInProcessI>( this.Functions.Set_SteamAPI_CPostAPIResultInProcess33 )( this.ObjectAddress, ref arg0 ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void NativeRemove_SteamAPI_CPostAPIResultInProcessI( IntPtr thisptr, ref IntPtr arg0 );
		public void Remove_SteamAPI_CPostAPIResultInProcess( ref IntPtr arg0 ) 
		{
			this.GetFunction<NativeRemove_SteamAPI_CPostAPIResultInProcessI>( this.Functions.Remove_SteamAPI_CPostAPIResultInProcess34 )( this.ObjectAddress, ref arg0 ); 
		}
		
		[UnmanagedFunctionPointer(CallingConvention.ThisCall)] private delegate void NativeSet_SteamAPI_CCheckCallbackRegisteredInProcessI( IntPtr thisptr, ref IntPtr arg0 );
		public void Set_SteamAPI_CCheckCallbackRegisteredInProcess( ref IntPtr arg0 ) 
		{
			this.GetFunction<NativeSet_SteamAPI_CCheckCallbackRegisteredInProcessI>( this.Functions.Set_SteamAPI_CCheckCallbackRegisteredInProcess35 )( this.ObjectAddress, ref arg0 ); 
		}
		
	};
}
