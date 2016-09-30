using UnityEngine;
using System.Collections;

public class OnMouseClick : MonoBehaviour {

	[SerializeField] private GameObject spawnObject;

	//On mouse click: find mouse position and spawn a clone of the prefab at the mouse position
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) 
		{
			var mousePos = Input.mousePosition;
			mousePos.z = 10f;
			var objectPos = Camera.main.ScreenToWorldPoint (mousePos);
			Instantiate (spawnObject,objectPos, Quaternion.identity);
		}
	}
}
