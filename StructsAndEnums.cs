using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace PKRevealControllerBinding
{
static class CFunctions
{
	// extern void PKLog (NSString *format, ...);
	[DllImport ("__Internal")]
	static extern void PKLog (NSString format, IntPtr varArgs);
}

[Native]
public enum PKRevealControllerState : ulong
{
	LeftViewControllerInPresentationMode = 1,
	LeftViewController = 2,
	FrontViewController = 3,
	RightViewController = 4,
	RightViewControllerInPresentationMode = 5
}

[Native]
public enum PKRevealControllerAnimationType : ulong
{
	PKRevealControllerAnimationTypeStatic
}

[Native]
public enum PKRevealControllerType : ulong
{
	None = 0, 
	Left = 1,
	Right = 2,
	Both = (Left | Right)
}
}