using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchEvents : MonoBehaviour
{
	private List<GameObject> touches;

	void Start ()
	{
		touches = new List<GameObject>();
	}

	void Update () 
	{
		if(Application.platform == RuntimePlatform.Android || 
		   Application.platform == RuntimePlatform.IPhonePlayer)
		{
			RaycastHit hit = new RaycastHit();
			for (int i = 0; i < 1; i++) 
			{
				if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) 
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
					if (Physics.Raycast(ray, out hit)) 
					{
						hit.transform.gameObject.SendMessage("OnTouchDown", Input.GetTouch(i).position);
						touches[i] = hit.transform.gameObject;
					}
				}
				else if (Input.GetTouch(i).phase.Equals(TouchPhase.Moved)) 
				{
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
					if (Physics.Raycast(ray, out hit)) 
					{
						touches[i].SendMessage("OnTouchDrag", Input.GetTouch(i).position);
					}
				}
				else if (Input.GetTouch(i).phase.Equals(TouchPhase.Ended)) 
				{
					touches[i].SendMessage("OnTouchUp");
				}
			}
		}
	}
}