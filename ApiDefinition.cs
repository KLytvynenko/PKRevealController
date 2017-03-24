using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace PKRevealControllerBinding
{
    // @protocol PKAnimating <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IPKAnimating
    {
        // @required @property (readwrite, nonatomic, weak) CALayer * _Nullable layer;
        [Abstract]
        [NullAllowed, Export("layer", ArgumentSemantic.Weak)]
        CALayer Layer { get; set; }

        // @required @property (getter = isAnimating, assign, readwrite, nonatomic) BOOL animating;
        [Abstract]
        [Export("animating")]
        bool Animating { [Bind("isAnimating")] get; set; }

        // @required @property (readonly, copy, nonatomic) NSString * key;
        [Abstract]
        [Export("key")]
        string Key { get; }

        // @required @property (readwrite, copy, nonatomic) PKAnimationStartBlock startHandler;
        [Abstract]
        [Export("startHandler", ArgumentSemantic.Copy)]
        PKAnimationStartBlock StartHandler { get; set; }

        // @required @property (readwrite, copy, nonatomic) PKAnimationCompletionBlock completionHandler;
        [Abstract]
        [Export("completionHandler", ArgumentSemantic.Copy)]
        PKAnimationCompletionBlock CompletionHandler { get; set; }

        // @required -(void)startAnimationOnLayer:(CALayer *)layer;
        [Abstract]
        [Export("startAnimationOnLayer:")]
        void StartAnimationOnLayer(CALayer layer);

        // @required -(void)stopAnimation;
        [Abstract]
        [Export("stopAnimation")]
        void StopAnimation();
    }


    // @interface PKIdentifier (CAAnimation)
    [Category]
    [BaseType(typeof(CAAnimation))]
    interface CAAnimation_PKIdentifier
    {
        // @property (assign, readwrite, nonatomic) NSInteger pk_identifier;
        [Export("pk_identifier", ArgumentSemantic.Retain)]
        nint GetPk_identifier();

        [Export("setpk_identifier:", ArgumentSemantic.Retain)]
        void SetPk_identifier(nint revealController);
    }

    // @interface PKConvenienceAnimations (CALayer)
    [Category]
    [BaseType(typeof(CALayer))]
    interface CALayer_PKConvenienceAnimations
    {
        // +(CABasicAnimation *)animationFromAlpha:(CGFloat)fromValue toAlpha:(CGFloat)toValue timingFunction:(CAMediaTimingFunction *)timingFunction duration:(NSTimeInterval)duration;
        [Static]
        [Export("animationFromAlpha:toAlpha:timingFunction:duration:")]
        CABasicAnimation AnimationFromAlpha(nfloat fromValue, nfloat toValue, CAMediaTimingFunction timingFunction, double duration);

        // +(CABasicAnimation *)animationFromTransformation:(CATransform3D)fromTransformation toTransformation:(CATransform3D)toTransformation timingFunction:(CAMediaTimingFunction *)timingFunction duration:(NSTimeInterval)duration;
        [Static]
        [Export("animationFromTransformation:toTransformation:timingFunction:duration:")]
        CABasicAnimation AnimationFromTransformation(CATransform3D fromTransformation, CATransform3D toTransformation, CAMediaTimingFunction timingFunction, double duration);

        // +(CABasicAnimation *)animationFromPosition:(CGPoint)fromPosition toPosition:(CGPoint)toPosition timingFunction:(CAMediaTimingFunction *)timingFunction duration:(NSTimeInterval)duration;
        [Static]
        [Export("animationFromPosition:toPosition:timingFunction:duration:")]
        CABasicAnimation AnimationFromPosition(CGPoint fromPosition, CGPoint toPosition, CAMediaTimingFunction timingFunction, double duration);

        // -(void)animateToAlpha:(CGFloat)value timingFunction:(CAMediaTimingFunction *)timingFunction duration:(NSTimeInterval)duration alterModel:(BOOL)alterModel;
        [Export("animateToAlpha:timingFunction:duration:alterModel:")]
        void AnimateToAlpha(nfloat value, CAMediaTimingFunction timingFunction, double duration, bool alterModel);

        // -(void)animateToTransform:(CATransform3D)toTransform timingFunction:(CAMediaTimingFunction *)timingFunction duration:(NSTimeInterval)duration alterModel:(BOOL)alterModel;
        [Export("animateToTransform:timingFunction:duration:alterModel:")]
        void AnimateToTransform(CATransform3D toTransform, CAMediaTimingFunction timingFunction, double duration, bool alterModel);

        // -(void)animateToPoint:(CGPoint)toPoint timingFunction:(CAMediaTimingFunction *)timingFunction duration:(NSTimeInterval)duration alterModel:(BOOL)alterModel;
        [Export("animateToPoint:timingFunction:duration:alterModel:")]
        void AnimateToPoint(CGPoint toPoint, CAMediaTimingFunction timingFunction, double duration, bool alterModel);
    }

    // @interface PKBlocks (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_PKBlocks
    {
        // -(void)pk_performBlock:(void (^)(void))block onMainThread:(BOOL)mainThread;
        [Export("pk_performBlock:onMainThread:")]
        void Pk_performBlock(Action block, bool mainThread);
    }

    // typedef void (^PKAnimationStartBlock)();
    delegate void PKAnimationStartBlock();

    // typedef void (^PKAnimationCompletionBlock)(BOOL);
    delegate void PKAnimationCompletionBlock(bool arg0);

    // @protocol PKAnimating <NSObject>
    [Model]
    [BaseType(typeof(NSObject))]
    interface PKAnimating
    {
        // @required @property (readwrite, nonatomic, weak) CALayer * layer;
        [Abstract]
        [Export("layer", ArgumentSemantic.Weak)]
        CALayer Layer { get; set; }

        // @required @property (getter = isAnimating, assign, readwrite, nonatomic) BOOL animating;
        [Abstract]
        [Export("animating")]
        bool Animating { [Bind("isAnimating")] get; set; }

        // @required @property (readonly, copy, nonatomic) NSString * key;
        [Abstract]
        [Export("key")]
        string Key { get; }

        // @required @property (readwrite, copy, nonatomic) PKAnimationStartBlock startHandler;
        [Abstract]
        [Export("startHandler", ArgumentSemantic.Copy)]
        PKAnimationStartBlock StartHandler { get; set; }

        // @required @property (readwrite, copy, nonatomic) PKAnimationCompletionBlock completionHandler;
        [Abstract]
        [Export("completionHandler", ArgumentSemantic.Copy)]
        PKAnimationCompletionBlock CompletionHandler { get; set; }

        // @required -(void)startAnimationOnLayer:(CALayer *)layer;
        [Abstract]
        [Export("startAnimationOnLayer:")]
        void StartAnimationOnLayer(CALayer layer);

        // @required -(void)stopAnimation;
        [Abstract]
        [Export("stopAnimation")]
        void StopAnimation();
    }

    // @interface PKAnimation : CABasicAnimation <PKAnimating>
    [BaseType(typeof(CABasicAnimation))]
    interface PKAnimation : IPKAnimating
    {
        // @property (assign, readwrite, nonatomic) NSInteger identifier;
        [Export("identifier")]
        nint Identifier { get; set; }
    }

    // typedef void (^PKSequentialAnimationProgressBlock)(NSValue *, NSValue *, NSUInteger);
    delegate void PKSequentialAnimationProgressBlock(NSValue arg0, NSValue arg1, nuint arg2);

    // @interface PKSequentialAnimation : NSObject <PKAnimating>
    [BaseType(typeof(NSObject))]
    interface PKSequentialAnimation : IPKAnimating
    {
        // @property (readwrite, copy, nonatomic) PKSequentialAnimationProgressBlock progressHandler;
        [Export("progressHandler", ArgumentSemantic.Copy)]
        PKSequentialAnimationProgressBlock ProgressHandler { get; set; }

        // +(instancetype)animationForKeyPath:(NSString *)keyPath values:(NSArray *)values duration:(NSTimeInterval)duration;
        [Static]
        [Export("animationForKeyPath:values:duration:")]
        PKSequentialAnimation AnimationForKeyPath(string keyPath, NSObject[] values, double duration);

        // +(instancetype)animationForKeyPath:(NSString *)keyPath values:(NSArray *)values duration:(NSTimeInterval)duration progress:(PKSequentialAnimationProgressBlock)progress completion:(PKAnimationCompletionBlock)completion;
        [Static]
        [Export("animationForKeyPath:values:duration:progress:completion:")]
        PKSequentialAnimation AnimationForKeyPath(string keyPath, NSObject[] values, double duration, PKSequentialAnimationProgressBlock progress, PKAnimationCompletionBlock completion);
    }

    // @interface PKLayerAnimator : NSObject
    [BaseType(typeof(NSObject))]
    interface PKLayerAnimator
    {
        // @property (readonly, nonatomic, strong) CALayer * layer;
        [Export("layer", ArgumentSemantic.Strong)]
        CALayer Layer { get; }

        // +(instancetype)animatorForLayer:(CALayer *)layer;
        [Static]
        [Export("animatorForLayer:")]
        PKLayerAnimator AnimatorForLayer(CALayer layer);

        // -(void)addAnimation:(PKAnimation *)animation forKey:(NSString *)key;
        [Export("addAnimation:forKey:")]
        void AddAnimation(PKAnimation animation, string key);

        // -(void)addSequentialAnimation:(PKSequentialAnimation *)animation forKey:(NSString *)key;
        [Export("addSequentialAnimation:forKey:")]
        void AddSequentialAnimation(PKSequentialAnimation animation, string key);

        // -(void)startAnimationForKey:(NSString *)key;
        [Export("startAnimationForKey:")]
        void StartAnimationForKey(string key);

        // -(void)stopAnimationForKey:(NSString *)key;
        [Export("stopAnimationForKey:")]
        void StopAnimationForKey(string key);

        // -(void)stopAndRemoveAllAnimations;
        [Export("stopAndRemoveAllAnimations")]
        void StopAndRemoveAllAnimations();
    }

    // @interface PKRevealController (UIViewController)
    [Category]
    [BaseType(typeof(UIViewController))]
    interface UIViewController_PKRevealController
    {
        // @property (readwrite, nonatomic, strong) PKRevealController * revealController;
        [Export("revealController", ArgumentSemantic.Retain)]
        PKRevealController GetRevealController();

        [Export("setRevealController:", ArgumentSemantic.Retain)]
        void SetRevealController(PKRevealController revealController);
    }


    // typedef void (^PKDefaultCompletionHandler)(BOOL);
    delegate void PKDefaultCompletionHandler(bool arg0);

    [Static]
    partial interface Constants
    {
        // extern NSString *const PKRevealControllerAnimationDurationKey;
        [Field("PKRevealControllerAnimationDurationKey", "__Internal")]
        NSString PKRevealControllerAnimationDurationKey { get; }

        // extern NSString *const PKRevealControllerAnimationCurveKey;
        [Field("PKRevealControllerAnimationCurveKey", "__Internal")]
        NSString PKRevealControllerAnimationCurveKey { get; }

        // extern NSString *const PKRevealControllerAnimationTypeKey;
        [Field("PKRevealControllerAnimationTypeKey", "__Internal")]
        NSString PKRevealControllerAnimationTypeKey { get; }

        // extern NSString *const PKRevealControllerAllowsOverdrawKey;
        [Field("PKRevealControllerAllowsOverdrawKey", "__Internal")]
        NSString PKRevealControllerAllowsOverdrawKey { get; }

        // extern NSString *const PKRevealControllerQuickSwipeToggleVelocityKey;
        [Field("PKRevealControllerQuickSwipeToggleVelocityKey", "__Internal")]
        NSString PKRevealControllerQuickSwipeToggleVelocityKey { get; }

        // extern NSString *const PKRevealControllerDisablesFrontViewInteractionKey;
        [Field("PKRevealControllerDisablesFrontViewInteractionKey", "__Internal")]
        NSString PKRevealControllerDisablesFrontViewInteractionKey { get; }

        // extern NSString *const PKRevealControllerRecognizesPanningOnFrontViewKey;
        [Field("PKRevealControllerRecognizesPanningOnFrontViewKey", "__Internal")]
        NSString PKRevealControllerRecognizesPanningOnFrontViewKey { get; }

        // extern NSString *const PKRevealControllerRecognizesResetTapOnFrontViewKey;
        [Field("PKRevealControllerRecognizesResetTapOnFrontViewKey", "__Internal")]
        NSString PKRevealControllerRecognizesResetTapOnFrontViewKey { get; }
    }

    // @interface PKRevealController : UIViewController <UIGestureRecognizerDelegate>
    [BaseType(typeof(UIViewController))]
    interface PKRevealController : IUIGestureRecognizerDelegate
    {
        // @property (readwrite, nonatomic, weak) UIViewController * frontViewController;
        [Export("frontViewController", ArgumentSemantic.Weak)]
        UIViewController FrontViewController { get; set; }

        // @property (readwrite, nonatomic, weak) UIViewController * leftViewController;
        [Export("leftViewController", ArgumentSemantic.Weak)]
        UIViewController LeftViewController { get; set; }

        // @property (readwrite, nonatomic, weak) UIViewController * rightViewController;
        [Export("rightViewController", ArgumentSemantic.Weak)]
        UIViewController RightViewController { get; set; }

        // @property (readonly, nonatomic) UIPanGestureRecognizer * revealPanGestureRecognizer;
        [Export("revealPanGestureRecognizer")]
        UIPanGestureRecognizer RevealPanGestureRecognizer { get; }

        // @property (readonly, nonatomic) UITapGestureRecognizer * revealResetTapGestureRecognizer;
        [Export("revealResetTapGestureRecognizer")]
        UITapGestureRecognizer RevealResetTapGestureRecognizer { get; }

        // @property (readonly, nonatomic) PKRevealControllerState state;
        [Export("state")]
        PKRevealControllerState State { get; }

        // @property (readonly, nonatomic) PKRevealControllerType type __attribute__((deprecated("")));
        [Export("type")]
        PKRevealControllerType Type { get; }

        // @property (readonly, nonatomic) BOOL isPresentationModeActive;
        [Export("isPresentationModeActive")]
        bool IsPresentationModeActive { get; }

        // @property (readonly, nonatomic) NSDictionary * options __attribute__((deprecated("")));
        [Export("options")]
        NSDictionary Options { get; }

        // @property (assign, readwrite, nonatomic) CGFloat animationDuration;
        [Export("animationDuration")]
        nfloat AnimationDuration { get; set; }

        // @property (assign, readwrite, nonatomic) UIViewAnimationCurve animationCurve;
        [Export("animationCurve", ArgumentSemantic.Assign)]
        UIViewAnimationCurve AnimationCurve { get; set; }

        // @property (assign, readwrite, nonatomic) PKRevealControllerAnimationType animationType;
        [Export("animationType", ArgumentSemantic.Assign)]
        PKRevealControllerAnimationType AnimationType { get; set; }

        // @property (assign, readwrite, nonatomic) CGFloat quickSwipeVelocity;
        [Export("quickSwipeVelocity")]
        nfloat QuickSwipeVelocity { get; set; }

        // @property (assign, readwrite, nonatomic) BOOL allowsOverdraw;
        [Export("allowsOverdraw")]
        bool AllowsOverdraw { get; set; }

        // @property (assign, readwrite, nonatomic) BOOL disablesFrontViewInteraction;
        [Export("disablesFrontViewInteraction")]
        bool DisablesFrontViewInteraction { get; set; }

        // @property (assign, readwrite, nonatomic) BOOL recognizesPanningOnFrontView;
        [Export("recognizesPanningOnFrontView")]
        bool RecognizesPanningOnFrontView { get; set; }

        // @property (assign, readwrite, nonatomic) BOOL recognizesResetTapOnFrontView;
        [Export("recognizesResetTapOnFrontView")]
        bool RecognizesResetTapOnFrontView { get; set; }

        // @property (assign, readwrite, nonatomic) BOOL recognizesResetTapOnFrontViewInPresentationMode;
        [Export("recognizesResetTapOnFrontViewInPresentationMode")]
        bool RecognizesResetTapOnFrontViewInPresentationMode { get; set; }

        [Wrap("WeakDelegate")]
        PKRevealing Delegate { get; set; }

        // @property (readwrite, nonatomic, weak) id<PKRevealing> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // +(instancetype)revealControllerWithFrontViewController:(UIViewController *)frontViewController leftViewController:(UIViewController *)leftViewController rightViewController:(UIViewController *)rightViewController;
        [Static]
        [Export("revealControllerWithFrontViewController:leftViewController:rightViewController:")]
        PKRevealController RevealControllerWithFrontViewController(UIViewController frontViewController, UIViewController leftViewController, UIViewController rightViewController);

        // +(instancetype)revealControllerWithFrontViewController:(UIViewController *)frontViewController leftViewController:(UIViewController *)leftViewController;
        [Static]
        [Export("revealControllerWithFrontViewController:leftViewController:")]
        PKRevealController RevealControllerWithLeftViewController(UIViewController frontViewController, UIViewController leftViewController);

        // +(instancetype)revealControllerWithFrontViewController:(UIViewController *)frontViewController rightViewController:(UIViewController *)rightViewController;
        [Static]
        [Export("revealControllerWithFrontViewController:rightViewController:")]
        PKRevealController RevealControllerWithRightViewController(UIViewController frontViewController, UIViewController rightViewController);

        // -(instancetype)initWithFrontViewController:(UIViewController *)frontViewController leftViewController:(UIViewController *)leftViewController rightViewController:(UIViewController *)rightViewController options:(NSDictionary *)options;
        [Export("initWithFrontViewController:leftViewController:rightViewController:options:")]
        IntPtr Constructor(UIViewController frontViewController, UIViewController leftViewController, UIViewController rightViewController, NSDictionary options);

        // -(instancetype)initWithFrontViewController:(UIViewController *)frontViewController rightViewController:(UIViewController *)rightViewController options:(NSDictionary *)options;
        [Export("initWithFrontViewController:rightViewController:options:")]
        IntPtr Constructor(UIViewController frontViewController, UIViewController rightViewController, NSDictionary options);

        // -(void)showViewController:(UIViewController *)controller;
        [Export("showViewController:")]
        void ShowViewController(UIViewController controller);

        // -(void)showViewController:(UIViewController *)controller animated:(BOOL)animated completion:(PKDefaultCompletionHandler)completion;
        [Export("showViewController:animated:completion:")]
        void ShowViewController(UIViewController controller, bool animated, PKDefaultCompletionHandler completion);

        // -(void)enterPresentationModeAnimated:(BOOL)animated completion:(PKDefaultCompletionHandler)completion;
        [Export("enterPresentationModeAnimated:completion:")]
        void EnterPresentationModeAnimated(bool animated, PKDefaultCompletionHandler completion);

        // -(void)resignPresentationModeEntirely:(BOOL)entirely animated:(BOOL)animated completion:(PKDefaultCompletionHandler)completion;
        [Export("resignPresentationModeEntirely:animated:completion:")]
        void ResignPresentationModeEntirely(bool entirely, bool animated, PKDefaultCompletionHandler completion);

        // -(void)setFrontViewController:(UIViewController *)frontViewController focusAfterChange:(BOOL)focus completion:(PKDefaultCompletionHandler)completion __attribute__((deprecated("")));
        [Export("setFrontViewController:focusAfterChange:completion:")]
        void SetFrontViewController(UIViewController frontViewController, bool focus, PKDefaultCompletionHandler completion);

        // -(void)setMinimumWidth:(CGFloat)minWidth maximumWidth:(CGFloat)maxWidth forViewController:(UIViewController *)controller;
        [Export("setMinimumWidth:maximumWidth:forViewController:")]
        void SetMinimumWidth(nfloat minWidth, nfloat maxWidth, UIViewController controller);

        // -(UIViewController *)focusedController;
        [Export("focusedController")]
        UIViewController FocusedController { get; }

        // -(BOOL)hasRightViewController;
        [Export("hasRightViewController")]
        bool HasRightViewController { get; }

        // -(BOOL)hasLeftViewController;
        [Export("hasLeftViewController")]
        bool HasLeftViewController { get; }
    }

    // @protocol PKRevealing <NSObject>
    [Model]
    [BaseType(typeof(NSObject))]
    interface PKRevealing
    {
        // @optional -(void)revealController:(PKRevealController *)revealController willChangeToState:(PKRevealControllerState)state;
        [Export("revealController:willChangeToState:")]
        void WillChangeToState(PKRevealController revealController, PKRevealControllerState state);

        // @optional -(void)revealController:(PKRevealController *)revealController didChangeToState:(PKRevealControllerState)state;
        [Export("revealController:didChangeToState:")]
        void DidChangeToState(PKRevealController revealController, PKRevealControllerState state);
    }

    // @interface PKRevealControllerView : UIView
    [BaseType(typeof(UIView))]
    interface PKRevealControllerView
    {
        // @property (getter = hasShadow, assign, readwrite, nonatomic) BOOL shadow;
        [Export("shadow")]
        bool Shadow { [Bind("hasShadow")] get; set; }

        // @property (readwrite, nonatomic, weak) UIViewController * viewController;
        [Export("viewController", ArgumentSemantic.Weak)]
        UIViewController ViewController { get; set; }

        // -(void)updateShadowWithAnimationDuration:(NSTimeInterval)duration;
        [Export("updateShadowWithAnimationDuration:")]
        void UpdateShadowWithAnimationDuration(double duration);

        // -(void)setUserInteractionForContainedViewEnabled:(BOOL)userInteractionEnabled;
        [Export("setUserInteractionForContainedViewEnabled:")]
        void SetUserInteractionForContainedViewEnabled(bool userInteractionEnabled);
    }
}
