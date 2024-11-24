using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	// reference as serializable objects into it
	R.resources[] resources

	// naming rule
	resource.name = // a capital letter word with 3 - 5 chars

	// initialize
	R.RESOURCES = this.resources
*/

public static class R
{
	[System.Serializable]
	public class resource
	{
		[Tooltip(" name of the object ")]
		public string name = "";
		[Tooltip(" Can be GameObject , AudioClip ")]
		public Object obj = null;
	}


	public static resource[] RESOURCES;

	//
	public static AudioClip clip(string name)
	{
		for (int i0 = 0; i0 < RESOURCES.Length; i0 += 1)
		{
			if (RESOURCES[i0].name.Length == 0) continue;

			if (compare_str(RESOURCES[i0].name, name))
			{
				return RESOURCES[i0].obj as AudioClip;
			}
		}


		//
		Debug.Log(name + " audio clip not found. ");
		return null;
	}

	public static GameObject obj(string name)
	{
		//
		for (int i0 = 0; i0 < RESOURCES.Length; i0 += 1)
		{
			if (RESOURCES[i0].name.Length == 0) continue;

			if (compare_str(RESOURCES[i0].name, name))
			{
				return RESOURCES[i0].obj as GameObject;
			}
		}

		Debug.Log(name + " game object not found");
		return null;
	}

	public static Material mat(string name)
	{
		//
		for (int i0 = 0; i0 < RESOURCES.Length; i0 += 1)
		{
			if (RESOURCES[i0].name.Length == 0) continue;

			if (compare_str(RESOURCES[i0].name, name))
			{
				return RESOURCES[i0].obj as Material;
			}
		}

		Debug.Log(name + " mat not found");
		return null;
	}

	#region ad
	public static bool compare_str(string a, string b)
	{
		if (a.Length != b.Length) { return false; }


		for (int i = 0; i < a.Length; i += 1)
		{
			if (a[i] != b[i]) { return false; }
		}

		return true;
	}
	#endregion

}