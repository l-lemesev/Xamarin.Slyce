using System;

using AVFoundation;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.iOS.Slyce
{

    //[Static]
    partial interface Constants
    {
        // extern const NSUInteger SlyceDefaultLogLevel;
        [Field("SlyceDefaultLogLevel", "__Internal")]
        nuint SlyceDefaultLogLevel { get; }
    }

    // @protocol SlyceLogger <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SlyceLogger
    {
        // @required -(void)info:(NSString * _Nonnull)message;
        [Abstract]
        [Export("info:")]
        void Info(string message);

        // @required -(void)warning:(NSString * _Nonnull)message;
        [Abstract]
        [Export("warning:")]
        void Warning(string message);

        // @required -(void)error:(NSString * _Nonnull)message;
        [Abstract]
        [Export("error:")]
        void Error(string message);
    }

    // @interface SlyceLogging : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceLogging
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SlyceLogging Shared();

        // @property (assign, nonatomic) SlyceLogLevel logLevel;
        [Export("logLevel", ArgumentSemantic.Assign)]
        SlyceLogLevel LogLevel { get; set; }

        // @property (nonatomic, strong) id<SlyceLogger> _Nonnull logger;
        [Export("logger", ArgumentSemantic.Strong)]
        SlyceLogger Logger { get; set; }
    }

    //[Static]
    //partial interface Constants
    //{
    //    // extern const CGPoint SlyceAnchorPointNone;
    //    [Field("SlyceAnchorPointNone", "__Internal")]
    //    CGPoint SlyceAnchorPointNone { get; }
    //}

    // @protocol SlyceImageMatchingSyncDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SlyceImageMatchingSyncDelegate
    {
        // @required -(void)slyceImageMatchingSyncDidStart:(Slyce * _Nonnull)slyce;
        [Abstract]
        [Export("slyceImageMatchingSyncDidStart:")]
        void SlyceImageMatchingSyncDidStart(Slyce slyce);

        // @required -(void)slyceImageMatchingSyncDidFinish:(Slyce * _Nonnull)slyce;
        [Abstract]
        [Export("slyceImageMatchingSyncDidFinish:")]
        void SlyceImageMatchingSyncDidFinish(Slyce slyce);

        // @required -(void)slyce:(Slyce * _Nonnull)slyce imageMatchingSyncFailedWithMessage:(NSString * _Nonnull)failMessage;
        [Abstract]
        [Export("slyce:imageMatchingSyncFailedWithMessage:")]
        void Slyce(Slyce slyce, string failMessage);

        // @required -(void)slyce:(Slyce * _Nonnull)slyce imageMatchingSyncedCatalogCount:(NSInteger)count fromTotalCount:(NSInteger)total;
        [Abstract]
        [Export("slyce:imageMatchingSyncedCatalogCount:fromTotalCount:")]
        void Slyce(Slyce slyce, nint count, nint total);
    }

    //[Static]
    partial interface Constants
    {
        // extern NSNotificationName  _Nonnull const SlyceDidOpenNotification;
        [Field("SlyceDidOpenNotification", "__Internal")]
        NSString SlyceDidOpenNotification { get; }

        // extern NSNotificationName  _Nonnull const SlyceWillCloseNotification;
        [Field("SlyceWillCloseNotification", "__Internal")]
        NSString SlyceWillCloseNotification { get; }

        // extern NSNotificationName  _Nonnull const SlyceDidCloseNotification;
        [Field("SlyceDidCloseNotification", "__Internal")]
        NSString SlyceDidCloseNotification { get; }
    }

    // @interface Slyce : NSObject
    [BaseType(typeof(NSObject))]
    interface Slyce
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        Slyce Shared();

        // -(void)openWithAccountIdentifier:(NSString * _Nonnull)accountIdentifier apiKey:(NSString * _Nonnull)apiKey spaceIdentifier:(NSString * _Nonnull)spaceIdentifier completion:(void (^ _Nonnull)(NSError * _Nullable))completion;
        [Export("openWithAccountIdentifier:apiKey:spaceIdentifier:completion:")]
        void OpenWithAccountIdentifier(string accountIdentifier, string apiKey, string spaceIdentifier, Action<NSError> completion);

        // @property (readonly, nonatomic) SlyceCredentials * _Nullable credentials;
        [NullAllowed, Export("credentials")]
        SlyceCredentials Credentials { get; }

        // -(BOOL)isOpen;
        [Export("isOpen")]
        bool IsOpen { get; }

        // -(void)close;
        [Export("close")]
        void Close();

        // @property (readonly, nonatomic) SlyceSession * _Nullable defaultSession;
        [NullAllowed, Export("defaultSession")]
        SlyceSession DefaultSession { get; }

        [Wrap("WeakImageMatchingSyncDelegate")]
        [NullAllowed]
        SlyceImageMatchingSyncDelegate ImageMatchingSyncDelegate { get; set; }

        // @property (nonatomic, weak) id<SlyceImageMatchingSyncDelegate> _Nullable imageMatchingSyncDelegate;
        [NullAllowed, Export("imageMatchingSyncDelegate", ArgumentSemantic.Weak)]
        NSObject WeakImageMatchingSyncDelegate { get; set; }

        // @property (nonatomic) BOOL analyticsEnabled;
        [Export("analyticsEnabled")]
        bool AnalyticsEnabled { get; set; }

        // @property (nonatomic) BOOL analyticsShouldIncludeLocationInformation;
        [Export("analyticsShouldIncludeLocationInformation")]
        bool AnalyticsShouldIncludeLocationInformation { get; set; }

        // @property (readonly, nonatomic) id<SlyceEventTracker> _Nonnull eventTracker;
        [Export("eventTracker")]
        SlyceEventTracker EventTracker { get; }

        // @property (readonly, nonatomic) SlyceGDPRComplianceManager * _Nonnull complianceManager;
        [Export("complianceManager")]
        SlyceGDPRComplianceManager ComplianceManager { get; }
    }

    //[Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull SlyceErrorDomain;
        [Field("SlyceErrorDomain", "__Internal")]
        NSString SlyceErrorDomain { get; }
    }

    // @protocol SlyceSessionListener <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SlyceSessionListener
    {
        // @optional -(void)slyceSession:(SlyceSession * _Nonnull)session willStartSearchTask:(SlyceSearchTask * _Nonnull)searchTask;
        [Export("slyceSession:willStartSearchTask:")]
        void WillStartSearchTask(SlyceSession session, SlyceSearchTask searchTask);

        // @optional -(void)slyceSession:(SlyceSession * _Nonnull)session didFinishSearchTask:(SlyceSearchTask * _Nonnull)searchTask;
        [Export("slyceSession:didFinishSearchTask:")]
        void DidFinishSearchTask(SlyceSession session, SlyceSearchTask searchTask);
    }

    // @interface SlyceSession : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceSession
    {
        // +(instancetype _Nullable)sessionWithSlyce:(Slyce * _Nonnull)slyce error:(SlyceOutError)outError;
        [Static]
        [Export("sessionWithSlyce:error:")]
        [return: NullAllowed]
        SlyceSession SessionWithSlyce(Slyce slyce, [NullAllowed] out NSError outError);

        // -(void)addListener:(id<SlyceSessionListener> _Nonnull)listener;
        [Export("addListener:")]
        void AddListener(SlyceSessionListener listener);

        // -(void)removeListener:(id<SlyceSessionListener> _Nonnull)listener;
        [Export("removeListener:")]
        void RemoveListener(SlyceSessionListener listener);

        // -(void)invalidate;
        [Export("invalidate")]
        void Invalidate();

        // @property (readonly, nonatomic) BOOL isInvalidated;
        [Export("isInvalidated")]
        bool IsInvalidated { get; }

        // -(SlyceSearchTask * _Nullable)startSearchTaskWithRequest:(SlyceSearchRequest * _Nonnull)searchRequest workflowIdentifier:(NSString * _Nonnull)workflowIdentifier listener:(id<SlyceSearchTaskListener> _Nullable)listener;
        [Export("startSearchTaskWithRequest:workflowIdentifier:listener:")]
        [return: NullAllowed]
        SlyceSearchTask StartSearchTaskWithRequest(SlyceSearchRequest searchRequest, string workflowIdentifier, [NullAllowed] SlyceSearchTaskListener listener);

        // @property (readonly, copy, nonatomic) NSArray<SlyceSearchTask *> * _Nonnull searchTasks;
        [Export("searchTasks", ArgumentSemantic.Copy)]
        SlyceSearchTask[] SearchTasks { get; }

        // -(SlyceSearchTask * _Nullable)getSearchTaskByIdentifier:(NSString * _Nonnull)taskIdentifier;
        [Export("getSearchTaskByIdentifier:")]
        [return: NullAllowed]
        SlyceSearchTask GetSearchTaskByIdentifier(string taskIdentifier);

        // -(void)cancelAllTasks;
        [Export("cancelAllTasks")]
        void CancelAllTasks();

        // @property (nonatomic, strong) SlyceSearchParameters * _Nullable defaultSearchParameters;
        [NullAllowed, Export("defaultSearchParameters", ArgumentSemantic.Strong)]
        SlyceSearchParameters DefaultSearchParameters { get; set; }

        // @property (nonatomic, weak) id<SlyceSessionDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @interface SlyceCredentials : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface SlyceCredentials : INSCopying
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull accountIdentifier;
        [Export("accountIdentifier")]
        string AccountIdentifier { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull spaceIdentifier;
        [Export("spaceIdentifier")]
        string SpaceIdentifier { get; }

        // -(BOOL)isEqualToCredentials:(SlyceCredentials * _Nonnull)other;
        [Export("isEqualToCredentials:")]
        bool IsEqualToCredentials(SlyceCredentials other);
    }

    // typedef NSString * _Nullable (^SlyceLocalizationHandler)(NSString * _Nonnull);
    delegate string SlyceLocalizationHandler(string arg0);

    // @interface SlyceLocalization : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceLocalization
    {
        // +(void)setCustomLocalizationHandler:(SlyceLocalizationHandler _Nullable)handler;
        [Static]
        [Export("setCustomLocalizationHandler:")]
        void SetCustomLocalizationHandler([NullAllowed] SlyceLocalizationHandler handler);
    }

    // @interface SlyceBarcode : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface SlyceBarcode : INSCoding
    {
        // @property (readonly, nonatomic) SlyceBarcodeType type;
        [Export("type")]
        SlyceBarcodeType Type { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull typeString;
        [Export("typeString")]
        string TypeString { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull text;
        [Export("text")]
        string Text { get; }

        // @property (nonatomic, strong) AVMetadataMachineReadableCodeObject * _Nullable metadata;
        [NullAllowed, Export("metadata", ArgumentSemantic.Strong)]
        AVMetadataMachineReadableCodeObject Metadata { get; set; }

        // -(instancetype _Nonnull)initWithType:(SlyceBarcodeType)type andText:(NSString * _Nonnull)text __attribute__((objc_designated_initializer));
        [Export("initWithType:andText:")]
        [DesignatedInitializer]
        IntPtr Constructor(SlyceBarcodeType type, string text);

        // +(NSString * _Nullable)stringFromBarcodeType:(SlyceBarcodeType)barcodeType;
        [Static]
        [Export("stringFromBarcodeType:")]
        [return: NullAllowed]
        string StringFromBarcodeType(SlyceBarcodeType barcodeType);

        // +(SlyceBarcodeType)barcodeTypeFromString:(NSString * _Nonnull)typeString;
        [Static]
        [Export("barcodeTypeFromString:")]
        SlyceBarcodeType BarcodeTypeFromString(string typeString);
    }

    // @protocol SlyceCameraControls <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SlyceCameraControls
    {
        // @required -(BOOL)start:(SlyceOutError)error;
        [Abstract]
        [Export("start:")]
        bool Start([NullAllowed] out NSError error);

        // @required -(void)stop;
        [Abstract]
        [Export("stop")]
        void Stop();

        // @required -(void)pause;
        [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(BOOL)resume:(SlyceOutError)error;
        [Abstract]
        [Export("resume:")]
        bool Resume([NullAllowed] out NSError error);

        // @required @property (readonly, nonatomic) BOOL paused;
        [Abstract]
        [Export("paused")]
        bool Paused { get; }

        // @required @property (readonly, nonatomic) CALayer * _Nullable previewLayer;
        [Abstract]
        [NullAllowed, Export("previewLayer")]
        CALayer PreviewLayer { get; }

        // @required @property (readonly, nonatomic) CGFloat zoomFactor;
        [Abstract]
        [Export("zoomFactor")]
        nfloat ZoomFactor { get; }

        // @required @property (readonly, nonatomic) AVCaptureDevicePosition devicePosition;
        [Abstract]
        [Export("devicePosition")]
        AVCaptureDevicePosition DevicePosition { get; }

        // @required -(BOOL)setZoomFactor:(CGFloat)zoomFactor error:(SlyceOutError)error;
        [Abstract]
        [Export("setZoomFactor:error:")]
        bool SetZoomFactor(nfloat zoomFactor, [NullAllowed] out NSError error);

        // @required -(BOOL)toggleBackFront:(SlyceOutError)error;
        [Abstract]
        [Export("toggleBackFront:")]
        bool ToggleBackFront([NullAllowed] out NSError error);

        // @required -(BOOL)setFlashMode:(AVCaptureFlashMode)flashMode error:(SlyceOutError)error;
        [Abstract]
        [Export("setFlashMode:error:")]
        bool SetFlashMode(AVCaptureFlashMode flashMode, [NullAllowed] out NSError error);

        // @required -(BOOL)focusAtPoint:(CGPoint)point error:(SlyceOutError)error;
        [Abstract]
        [Export("focusAtPoint:error:")]
        bool FocusAtPoint(CGPoint point, [NullAllowed] out NSError error);
    }

    // @interface SlyceLensConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceLensConfiguration
    {
        // @property (assign, nonatomic) float detectionThreshold2D;
        [Export("detectionThreshold2D")]
        float DetectionThreshold2D { get; set; }

        // @property (assign, nonatomic) BOOL sound;
        [Export("sound")]
        bool Sound { get; set; }

        // @property (assign, nonatomic) BOOL vibrate;
        [Export("vibrate")]
        bool Vibrate { get; set; }
    }

    // @interface SlyceSearchParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceSearchParameters
    {
        // @property (copy, nonatomic) NSString * _Nullable languageCode;
        [NullAllowed, Export("languageCode")]
        string LanguageCode { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable countryCode;
        [NullAllowed, Export("countryCode")]
        string CountryCode { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable workflowOptions;
        [NullAllowed, Export("workflowOptions", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> WorkflowOptions { get; set; }

        // @property (assign, nonatomic) BOOL demoMode;
        [Export("demoMode")]
        bool DemoMode { get; set; }
    }

    // @interface SlyceSearchRequest : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface SlyceSearchRequest : INSCoding
    {
        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image anchor:(CGPoint)anchor searchParameters:(SlyceSearchParameters * _Nullable)searchParameters;
        [Export("initWithImage:anchor:searchParameters:")]
        IntPtr Constructor(UIImage image, CGPoint anchor, [NullAllowed] SlyceSearchParameters searchParameters);

        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image searchParameters:(SlyceSearchParameters * _Nullable)searchParameters;
        [Export("initWithImage:searchParameters:")]
        IntPtr Constructor(UIImage image, [NullAllowed] SlyceSearchParameters searchParameters);

        // -(instancetype _Nonnull)initWithImageURL:(NSString * _Nonnull)imageURL anchor:(CGPoint)anchor searchParameters:(SlyceSearchParameters * _Nullable)searchParameters;
        [Export("initWithImageURL:anchor:searchParameters:")]
        IntPtr Constructor(string imageURL, CGPoint anchor, [NullAllowed] SlyceSearchParameters searchParameters);

        // -(instancetype _Nonnull)initWithImageURL:(NSString * _Nonnull)imageURL searchParameters:(SlyceSearchParameters * _Nullable)searchParameters;
        [Export("initWithImageURL:searchParameters:")]
        IntPtr Constructor(string imageURL, [NullAllowed] SlyceSearchParameters searchParameters);

        // @property (readonly, nonatomic, strong) NSDate * _Nonnull timestamp;
        [Export("timestamp", ArgumentSemantic.Strong)]
        NSDate Timestamp { get; }

        // @property (readonly, nonatomic) NSString * _Nullable languageCode;
        [NullAllowed, Export("languageCode")]
        string LanguageCode { get; }

        // @property (readonly, nonatomic) NSString * _Nullable countryCode;
        [NullAllowed, Export("countryCode")]
        string CountryCode { get; }

        // @property (readonly, nonatomic) BOOL demoMode;
        [Export("demoMode")]
        bool DemoMode { get; }

        // @property (readonly, nonatomic) UIImage * _Nullable image;
        [NullAllowed, Export("image")]
        UIImage Image { get; }

        // @property (readonly, nonatomic) NSString * _Nullable imageURL;
        [NullAllowed, Export("imageURL")]
        string ImageURL { get; }

        // @property (readonly, nonatomic) CGPoint anchor;
        [Export("anchor")]
        CGPoint Anchor { get; }
    }

    // @protocol SlyceSearchTaskListener <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SlyceSearchTaskListener
    {
        // @optional -(void)slyceSearchTask:(SlyceSearchTask * _Nonnull)searchTask didFinishWithResponse:(SlyceSearchResponse * _Nonnull)response;
        [Export("slyceSearchTask:didFinishWithResponse:")]
        void DidFinishWithResponse(SlyceSearchTask searchTask, SlyceSearchResponse response);

        // @optional -(void)slyceSearchTask:(SlyceSearchTask * _Nonnull)searchTask didFailWithErrors:(NSArray<NSError *> * _Nonnull)errors;
        [Export("slyceSearchTask:didFailWithErrors:")]
        void DidFailWithErrors(SlyceSearchTask searchTask, NSError[] errors);

        // @optional -(void)slyceSearchTask:(SlyceSearchTask * _Nonnull)searchTask didReceiveSearchResponseUpdate:(SlyceSearchResponseUpdate * _Nonnull)searchResponseUpdate;
        [Export("slyceSearchTask:didReceiveSearchResponseUpdate:")]
        void DidReceiveSearchResponseUpdate(SlyceSearchTask searchTask, SlyceSearchResponseUpdate searchResponseUpdate);
    }

    // @interface SlyceSearchTask : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceSearchTask
    {
        // @property (readonly, nonatomic) SlyceSession * _Nonnull session;
        [Export("session")]
        SlyceSession Session { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")]
        string Identifier { get; }

        // @property (readonly, nonatomic, strong) SlyceSearchRequest * _Nonnull request;
        [Export("request", ArgumentSemantic.Strong)]
        SlyceSearchRequest Request { get; }

        // @property (readonly, nonatomic, strong) SlyceSearchResponse * _Nullable response;
        [NullAllowed, Export("response", ArgumentSemantic.Strong)]
        SlyceSearchResponse Response { get; }

        // @property (readonly, nonatomic) NSArray<NSError *> * _Nonnull errors;
        [Export("errors")]
        NSError[] Errors { get; }

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();

        // -(void)addListener:(id<SlyceSearchTaskListener> _Nonnull)listener;
        [Export("addListener:")]
        void AddListener(SlyceSearchTaskListener listener);

        // -(void)removeListener:(id<SlyceSearchTaskListener> _Nonnull)listener;
        [Export("removeListener:")]
        void RemoveListener(SlyceSearchTaskListener listener);
    }

    // @interface SlyceSearchResponse : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface SlyceSearchResponse : INSCoding
    {
        // @property (readonly, nonatomic) NSString * _Nullable jobIdentifier;
        [NullAllowed, Export("jobIdentifier")]
        string JobIdentifier { get; }

        // @property (readonly, nonatomic) NSOrderedSet<NSString *> * _Nullable tags;
        [NullAllowed, Export("tags")]
        NSOrderedSet<NSString> Tags { get; }

        // @property (readonly, nonatomic) NSArray<SlyceSearchResult *> * _Nullable results;
        [NullAllowed, Export("results")]
        SlyceSearchResult[] Results { get; }
    }

    // @interface SlyceSearchResponseUpdate : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceSearchResponseUpdate
    {
        // @property (readonly, nonatomic) SlyceSearchResponse * _Nonnull response;
        [Export("response")]
        SlyceSearchResponse Response { get; }

        // @property (readonly, nonatomic) SlyceSearchResponseUpdateType type;
        [Export("type")]
        SlyceSearchResponseUpdateType Type { get; }

        // @property (readonly, nonatomic) id _Nullable value;
        [NullAllowed, Export("value")]
        NSObject Value { get; }
    }

    // @interface SlyceSearchResult : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface SlyceSearchResult : INSCoding
    {
        // @property (readonly, nonatomic) NSString * _Nonnull type;
        [Export("type")]
        string Type { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull datasetIdentifier;
        [Export("datasetIdentifier")]
        string DatasetIdentifier { get; }

        // @property (readonly, nonatomic) NSArray<NSDictionary *> * _Nonnull items;
        [Export("items")]
        NSDictionary[] Items { get; }
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull SlyceLensIdentifierBarcode;
        [Field("SlyceLensIdentifierBarcode", "__Internal")]
        NSString SlyceLensIdentifierBarcode { get; }

        // extern NSString *const _Nonnull SlyceLensIdentifierImageMatching;
        [Field("SlyceLensIdentifierImageMatching", "__Internal")]
        NSString SlyceLensIdentifierImageMatching { get; }

        // extern NSString *const _Nonnull SlyceLensIdentifierVisualSearch;
        [Field("SlyceLensIdentifierVisualSearch", "__Internal")]
        NSString SlyceLensIdentifierVisualSearch { get; }

        // extern NSString *const _Nonnull SlyceLensIdentifierUniversal;
        [Field("SlyceLensIdentifierUniversal", "__Internal")]
        NSString SlyceLensIdentifierUniversal { get; }
    }

    // @interface SlyceScanner : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceScanner
    {
        // +(instancetype _Nullable)scannerWithSession:(SlyceSession * _Nonnull)session lensIdentifier:(NSString * _Nonnull)lensIdentifier lensConfiguration:(SlyceLensConfiguration * _Nullable)lensConfiguration error:(SlyceOutError)outError;
        [Static]
        [Export("scannerWithSession:lensIdentifier:lensConfiguration:error:")]
        [return: NullAllowed]
        SlyceScanner ScannerWithSession(SlyceSession session, string lensIdentifier, [NullAllowed] SlyceLensConfiguration lensConfiguration, [NullAllowed] out NSError outError);

        // @property (readonly, nonatomic) NSString * _Nonnull lensIdentifier;
        [Export("lensIdentifier")]
        string LensIdentifier { get; } 

        // @property (readonly, nonatomic, strong) AVCaptureSession * _Nullable captureSession;
        [NullAllowed, Export("captureSession", ArgumentSemantic.Strong)]
        AVCaptureSession CaptureSession { get; }

        // @property (readonly, getter = isDetectionSuspended) BOOL detectionSuspended;
        [Export("detectionSuspended")]
        bool DetectionSuspended { [Bind("isDetectionSuspended")] get; }

        // -(BOOL)attachToCaptureSession:(AVCaptureSession * _Nonnull)captureSession error:(NSError * _Nullable * _Nullable)error;
        [Export("attachToCaptureSession:error:")]
        bool AttachToCaptureSession(AVCaptureSession captureSession, [NullAllowed] out NSError error);

        // -(void)detachFromCaptureSession;
        [Export("detachFromCaptureSession")]
        void DetachFromCaptureSession();

        // -(void)suspendDetection;
        [Export("suspendDetection")]
        void SuspendDetection();

        // -(void)resumeDetection;
        [Export("resumeDetection")]
        void ResumeDetection();
    }

    // @interface SlyceLensView : UIView
    [BaseType(typeof(UIView))]
    interface SlyceLensView
    {
        // +(instancetype _Nullable)lensViewWithSession:(SlyceSession * _Nonnull)session lensIdentifier:(NSString * _Nonnull)lensIdentifier lensConfiguration:(SlyceLensConfiguration * _Nullable)lensConfiguration error:(SlyceOutError)outError;
        [Static]
        [Export("lensViewWithSession:lensIdentifier:lensConfiguration:error:")]
        [return: NullAllowed]
        SlyceLensView LensViewWithSession(SlyceSession session, string lensIdentifier, [NullAllowed] SlyceLensConfiguration lensConfiguration, [NullAllowed] out NSError outError);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull lensIdentifier;
        [Export("lensIdentifier")]
        string LensIdentifier { get; }

        // @property (readonly, nonatomic, strong) SlyceLensConfiguration * _Nonnull lensConfiguration;
        [Export("lensConfiguration", ArgumentSemantic.Strong)]
        SlyceLensConfiguration LensConfiguration { get; }

        // @property (readonly, nonatomic) id<SlyceCameraControls> _Nonnull camera;
        [Export("camera")]
        SlyceCameraControls Camera { get; }

        // -(void)suspendDetection;
        [Export("suspendDetection")]
        void SuspendDetection();

        // -(void)resumeDetection;
        [Export("resumeDetection")]
        void ResumeDetection();

        // -(BOOL)isDetectionSuspended;
        [Export("isDetectionSuspended")]
 
        bool IsDetectionSuspended { get; }

        // -(void)resetAnimations;
        [Export("resetAnimations")]
        void ResetAnimations();
    }

    // @protocol SlyceEventTracker <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SlyceEventTracker
    {
        // @required -(void)trackZoomIn;
        [Abstract]
        [Export("trackZoomIn")]
        void TrackZoomIn();

        // @required -(void)trackZoomOut;
        [Abstract]
        [Export("trackZoomOut")]
        void TrackZoomOut();

        // @required -(void)trackTurnOnFlash;
        [Abstract]
        [Export("trackTurnOnFlash")]
        void TrackTurnOnFlash();

        // @required -(void)trackTurnOffFlash;
        [Abstract]
        [Export("trackTurnOffFlash")]
        void TrackTurnOffFlash();

        // @required -(void)trackTapToFocus;
        [Abstract]
        [Export("trackTapToFocus")]
        void TrackTapToFocus();

        // @required -(void)trackCaptureImage;
        [Abstract]
        [Export("trackCaptureImage")]
        void TrackCaptureImage();

        // @required -(void)trackShareFeedbackTap;
        [Abstract]
        [Export("trackShareFeedbackTap")]
        void TrackShareFeedbackTap();

        // @required -(void)trackViewProductInformationTapForItemIdentifier:(NSString * _Nullable)itemIdentifier itemURL:(NSString * _Nullable)itemURL;
        [Abstract]
        [Export("trackViewProductInformationTapForItemIdentifier:itemURL:")]
        void TrackViewProductInformationTapForItemIdentifier([NullAllowed] string itemIdentifier, [NullAllowed] string itemURL);

        // @required -(void)trackViewProductReviewsTapForItemIdentifier:(NSString * _Nullable)itemIdentifier itemURL:(NSString * _Nullable)itemURL;
        [Abstract]
        [Export("trackViewProductReviewsTapForItemIdentifier:itemURL:")]
        void TrackViewProductReviewsTapForItemIdentifier([NullAllowed] string itemIdentifier, [NullAllowed] string itemURL);

        // @required -(void)trackAddToListTapForItemIdentifier:(NSString * _Nullable)itemIdentifier itemURL:(NSString * _Nullable)itemURL;
        [Abstract]
        [Export("trackAddToListTapForItemIdentifier:itemURL:")]
        void TrackAddToListTapForItemIdentifier([NullAllowed] string itemIdentifier, [NullAllowed] string itemURL);

        // @required -(void)trackItemQuantityTapForItemIdentifier:(NSString * _Nullable)itemIdentifier itemURL:(NSString * _Nullable)itemURL itemQuantity:(NSInteger)itemQuantity;
        [Abstract]
        [Export("trackItemQuantityTapForItemIdentifier:itemURL:itemQuantity:")]
        void TrackItemQuantityTapForItemIdentifier([NullAllowed] string itemIdentifier, [NullAllowed] string itemURL, nint itemQuantity);

        // @required -(void)trackAddToCartTapForItemIdentifier:(NSString * _Nullable)itemIdentifier itemRevenue:(NSString * _Nullable)itemRevenue itemURL:(NSString * _Nullable)itemURL itemQuantity:(NSInteger)itemQuantity;
        [Abstract]
        [Export("trackAddToCartTapForItemIdentifier:itemRevenue:itemURL:itemQuantity:")]
        void TrackAddToCartTapForItemIdentifier([NullAllowed] string itemIdentifier, [NullAllowed] string itemRevenue, [NullAllowed] string itemURL, nint itemQuantity);

        // @required -(void)trackCheckoutTapForItemIdentifier:(NSString * _Nullable)itemIdentifier itemRevenue:(NSString * _Nullable)itemRevenue itemURL:(NSString * _Nullable)itemURL itemQuantity:(NSInteger)itemQuantity;
        [Abstract]
        [Export("trackCheckoutTapForItemIdentifier:itemRevenue:itemURL:itemQuantity:")]
        void TrackCheckoutTapForItemIdentifier([NullAllowed] string itemIdentifier, [NullAllowed] string itemRevenue, [NullAllowed] string itemURL, nint itemQuantity);

        // @required -(void)trackOrderSuccessfullyCompletedForItemRevenue:(NSString * _Nullable)itemRevenue transactionCurrency:(NSString * _Nullable)transactionCurrency transactionId:(NSString * _Nullable)transactionId transactionRevenue:(NSString * _Nullable)transactionRevenue transactionShipping:(NSString * _Nullable)transactionShipping transactionTax:(NSString * _Nullable)transactionTax itemQuantity:(NSInteger)itemQuantity;
        [Abstract]
        [Export("trackOrderSuccessfullyCompletedForItemRevenue:transactionCurrency:transactionId:transactionRevenue:transactionShipping:transactionTax:itemQuantity:")]
        void TrackOrderSuccessfullyCompletedForItemRevenue([NullAllowed] string itemRevenue, [NullAllowed] string transactionCurrency, [NullAllowed] string transactionId, [NullAllowed] string transactionRevenue, [NullAllowed] string transactionShipping, [NullAllowed] string transactionTax, nint itemQuantity);
    }

    // @interface SlycePrivacyPolicyConsent : NSObject
    [BaseType(typeof(NSObject))]
    interface SlycePrivacyPolicyConsent
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull body;
        [Export("body")]
        string Body { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull title;
        [Export("title")]
        string Title { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull callToAction;
        [Export("callToAction")]
        string CallToAction { get; }
    }

    // @interface SlycePrivacyPolicyLink : NSObject
    [BaseType(typeof(NSObject))]
    interface SlycePrivacyPolicyLink
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull callToAction;
        [Export("callToAction")]
        string CallToAction { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull urlString;
        [Export("urlString")]
        string UrlString { get; }
    }

    // @interface SlycePrivacyPolicy : NSObject
    [BaseType(typeof(NSObject))]
    interface SlycePrivacyPolicy
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull policyDescription;
        [Export("policyDescription")]
        string PolicyDescription { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull title;
        [Export("title")]
        string Title { get; }

        // @property (readonly, nonatomic, strong) NSArray<SlycePrivacyPolicyConsent *> * _Nonnull consents;
        [Export("consents", ArgumentSemantic.Strong)]
        SlycePrivacyPolicyConsent[] Consents { get; }

        // @property (readonly, nonatomic, strong) NSArray<SlycePrivacyPolicyLink *> * _Nonnull links;
        [Export("links", ArgumentSemantic.Strong)]
        SlycePrivacyPolicyLink[] Links { get; }
    }

    // @interface SlyceGDPRComplianceManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceGDPRComplianceManager
    {
        // @property (assign, nonatomic) BOOL userRequiresGDPRCompliance;
        [Export("userRequiresGDPRCompliance")]
        bool UserRequiresGDPRCompliance { get; set; }

        // @property (readonly, nonatomic, strong) SlycePrivacyPolicy * _Nullable privacyPolicy;
        [NullAllowed, Export("privacyPolicy", ArgumentSemantic.Strong)]
        SlycePrivacyPolicy PrivacyPolicy { get; }

        // -(void)setUserIdentifier:(NSString * _Nonnull)userIdentifier;
        [Export("setUserIdentifier:")]
        void SetUserIdentifier(string userIdentifier);

        // -(void)setUserConsentedToPrivacyPolicy:(SlycePrivacyPolicy * _Nonnull)privacyPolicy;
        [Export("setUserConsentedToPrivacyPolicy:")]
        void SetUserConsentedToPrivacyPolicy(SlycePrivacyPolicy privacyPolicy);

        // -(void)optOutAndForgetUser:(void (^ _Nonnull)(NSError * _Nullable))completion;
        [Export("optOutAndForgetUser:")]
        void OptOutAndForgetUser(Action<NSError> completion);
    }


    // @interface SlyceViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface SlyceViewController
    {
        // -(instancetype _Nonnull)initWithSlyce:(Slyce * _Nonnull)slyce mode:(SlyceViewControllerMode)mode options:(NSDictionary<NSString *,id> * _Nullable)options delegate:(id<SlyceViewControllerDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
        [Export("initWithSlyce:mode:options:delegate:")]
        [DesignatedInitializer]
        IntPtr Constructor(Slyce slyce, SlyceViewControllerMode mode, [NullAllowed] NSDictionary<NSString, NSObject> options, [NullAllowed] SlyceViewControllerDelegate @delegate);

        // -(instancetype _Nonnull)initWithSlyce:(Slyce * _Nonnull)slyce mode:(SlyceViewControllerMode)mode;
        [Export("initWithSlyce:mode:")]
        IntPtr Constructor(Slyce slyce, SlyceViewControllerMode mode);

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SlyceViewControllerDelegate Delegate { get; set; }

        // @property (readwrite, nonatomic, weak) id<SlyceViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) id<SlyceCameraControls> _Nonnull camera;
        [Export("camera")]
        SlyceCameraControls Camera { get; }

        // @property (readonly, nonatomic) SlyceSession * _Nullable session;
        [NullAllowed, Export("session")]
        SlyceSession Session { get; }
    }

    // @protocol SlyceViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SlyceViewControllerDelegate
    {
        // @optional -(void)slyceViewController:(SlyceViewController * _Nonnull)viewController didOpenSession:(SlyceSession * _Nonnull)session;
        [Export("slyceViewController:didOpenSession:")]
        void SlyceViewController(SlyceViewController viewController, SlyceSession session);

        // @optional -(BOOL)slyceViewController:(SlyceViewController * _Nonnull)viewController shouldDisplayDefaultDetailForItemDescriptor:(SlyceItemDescriptor * _Nonnull)itemDescriptor;
        [Export("slyceViewController:shouldDisplayDefaultDetailForItemDescriptor:")]
        bool SlyceViewController(SlyceViewController viewController, SlyceItemDescriptor itemDescriptor);

        // @optional -(BOOL)slyceViewController:(SlyceViewController * _Nonnull)viewController shouldDisplayDefaultListForItemDescriptors:(NSArray<SlyceItemDescriptor *> * _Nonnull)itemDescriptors;
        [Export("slyceViewController:shouldDisplayDefaultListForItemDescriptors:")]
        bool SlyceViewController(SlyceViewController viewController, SlyceItemDescriptor[] itemDescriptors);
    }



    // @interface SlyceItemDescriptor : NSObject
    [BaseType(typeof(NSObject))]
    interface SlyceItemDescriptor
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")]
        string Identifier { get; }

        // @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull item;
        [Export("item", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Item { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull jobIdentifier;
        [Export("jobIdentifier")]
        string JobIdentifier { get; }
    }
}
