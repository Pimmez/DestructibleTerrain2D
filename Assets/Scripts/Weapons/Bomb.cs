using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour, IWeapon {

	//Destroys bomb after being used
	public void Shoot()
	{
		Debug.Log ("Explosion");
		Destroy (this.gameObject);
	}
}
