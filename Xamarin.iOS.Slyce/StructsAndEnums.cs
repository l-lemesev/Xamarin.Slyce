using System;
using ObjCRuntime;

namespace Xamarin.iOS.Slyce
{
	[Native]
	public enum SlyceLogLevel : ulong
	{
        Verbose = 2,
        Debug = 3,
        Info = 4,
        Warning = 5,
        Error = 6,
		None = UInt64.MaxValue
    }

    [Native]
    public enum SlyceError : long
    {
        Unknown = -1,
        OperationCouldNotBeCompleted = -101,
        BadCredentials = -102,
        MissingCredentials = -103,
        NotAuthenticated = -104,
        NotOpen = -105,
        OperationCancelled = -106,
        CredentialMismatch = -107,
        UnexpectedStatusCode = -201,
        InvalidConfig = -202,
        WorkflowOperationMessage = -203,
        NetworkTimeout = -204,
        UnexpectedConnectionType = -205,
        UnexpectedResponseType = -206,
        WebSocketConnection = -207,
        ConfigurationService = -208,
        JSONParsing = -301,
        SearchRequestEncoding = -302,
        InvalidLens = -401,
        CaptureDeviceUnavailable = -501,
        CaptureSessionUnavailable = -502,
        CameraNotStarted = -503,
        CaptureStillImage = -504,
        ImageProcessing = -505,
        CouldNotAddOutput = -506,
        WorkflowOperationFailed = -601,
        WorkflowOperationNoResults = -602,
        SearchHistoryManager = -701,
        CoreData = -702,
        FeatureMatchCatalog = -801,
        UserNotGDPRCompliant = -901,
        UserIdentifierNotSet = -902
    }

    [Native]
    public enum SlyceBarcodeType : ulong
       {
        None,
        Aztec,
        Codabar,
        Code39,
        Code93,
        Code128,
        DataMatrix,
        Ean8,
        Ean13,
        Itf,
        MaxiCode,
        Pdf417,
        QRCode,
        Rss14,
        RSSExpanded,
        Upca,
        Upce,
        UPCEANExtension
    }

    [Native]
    public enum SlyceSearchResponseUpdateType : ulong
    {
        JobCreated,
        TagFound,
        ResultsReceived
    }


    [Native]
    public enum SlyceViewControllerMode : ulong
    {
        Universal,
        Picker
    }

    [Native]
    public enum SlyceActiveSearchesStyle : ulong
    {
        Hidden,
        Visible
    }

    [Native]
    public enum SlyceHeaderStyleLeft : ulong
    {
        Hidden,
        BackButton
    }

    [Native]
    public enum SlyceHeaderStyleCenter : ulong
    {
        Hidden,
        Title,
        Image
    }

    [Native]
    public enum SlyceHeaderStyleRight : ulong
    {
        Hidden,
        Settings,
        Help
    }

    [Native]
    public enum SlyceEnvironment : ulong
    {
        Staging,
        Production
    }
}
