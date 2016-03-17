/*
using UnityEngine;
using System.Collections;

public class ExitTimer : MonoBehaviour
{
	public string message = "There is no end...";
	private bool pressedOk = false;
	private bool showGui = false;
	
	private IEnumerator Start ( )
	{
		// Wait one minute.
		yield return new WaitForSeconds( 5.0f );
		
		// Wait for button press.
		yield return StartCoroutine( WaitForOkButton( ) );
		
		// Quit application (doesn't work in Editor I think).
		Application.LoadLevel(2 );
	}
	
	private IEnumerator WaitForOkButton ( )
	{
		// Show gui
		showGui = true;
		
		// Wait for Gui
		pressedOk = false;
		while ( !pressedOk )
			yield return null;
		
		// Hide gui
		showGui = false;
	}
	
	private void OnGUI ( )
	{
		if ( showGui )
		{
			Rect fullScreen = new Rect( 0, 0, Screen.width, Screen.height );
			if ( GUI.Button( fullScreen, message ) )
			{
				pressedOk = true;
			}
		}
	}
}

*/

