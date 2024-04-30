using ObjCRuntime;
using UIKit;
using System.Reflection;

namespace MAUI.LearningManagement;

public class Program
{
	// This is the main entry point of the application.
	static void Main(string[] args)
	{
		// if you want to use a different Application Delegate class from "AppDelegate"
		// you can specify it here.
		try
		{
			UIApplication.Main(args, null, typeof(AppDelegate));
		}
		catch (TargetInvocationException ex)
		{
			Console.WriteLine(ex.InnerException);
		}
	}
}
