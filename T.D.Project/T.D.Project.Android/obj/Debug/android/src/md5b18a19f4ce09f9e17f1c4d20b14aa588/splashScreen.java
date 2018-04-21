package md5b18a19f4ce09f9e17f1c4d20b14aa588;


public class splashScreen
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("T.D.Project.Droid.splashScreen, T.D.Project.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", splashScreen.class, __md_methods);
	}


	public splashScreen ()
	{
		super ();
		if (getClass () == splashScreen.class)
			mono.android.TypeManager.Activate ("T.D.Project.Droid.splashScreen, T.D.Project.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
