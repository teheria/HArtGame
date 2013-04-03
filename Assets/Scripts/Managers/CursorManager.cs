using UnityEngine;
using System.Collections;

public class CursorManager : Singleton<CursorManager>
{
	void Awake()
	{
		Screen.lockCursor = true;
	}
	
	void Update()
	{
		// for debug
		if(Input.GetKeyDown(KeyCode.R))
		{
			Screen.lockCursor = !Screen.lockCursor;
		}
	}
	
	public void LockCursor()
	{
		Screen.lockCursor = true;
	}
	
	public void UnLockCursor()
	{
		Screen.lockCursor = false;
	}
}
