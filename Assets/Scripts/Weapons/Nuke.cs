using UnityEngine;
using System.Collections;

public class Nuke : MonoBehaviour, IWeapon {

	//destroys item after being used
	public void Shoot()
	{
		Debug.Log ("Duke Nukem");
		Destroy (this.gameObject);
	}
}
