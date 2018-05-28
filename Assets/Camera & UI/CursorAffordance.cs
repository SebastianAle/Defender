using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CameraRaycaster))]
public class CursorAffordance : MonoBehaviour 
{	
	[SerializeField]
	Texture2D walkCursor = null;
	[SerializeField]
	Texture2D targetCursor = null;
	[SerializeField]
	Texture2D unknownCursor = null;

	[SerializeField]
	Vector2 cursorHotspot = new Vector2 (0, 0);

	CameraRaycaster cameraRaycaster;

	// Use this for initialization
	void Start () 
	{
		cameraRaycaster = GetComponent<CameraRaycaster> ();
		cameraRaycaster.onLayerChange += OnLayerChange; // registering 
	}
	
	// Update is called once per frame
	void OnLayerChange (Layer newLayer) 
	{
		print ("Cursor over new layer");
		switch (newLayer) 
		{
		case Layer.Enemy:
			Cursor.SetCursor (targetCursor, cursorHotspot, CursorMode.ForceSoftware);
			break;

		case Layer.Walkable:
			Cursor.SetCursor (walkCursor, cursorHotspot, CursorMode.ForceSoftware);
			break;

		case Layer.RaycastEndStop:
			Cursor.SetCursor (unknownCursor, cursorHotspot, CursorMode.ForceSoftware);
			break;

		default:
			Debug.LogWarning("We don't know what cursor to show!");
			return;
		}
	}
}
