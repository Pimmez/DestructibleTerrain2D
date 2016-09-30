using UnityEngine;
using System.Collections;

public class Acid : MonoBehaviour, IWeapon {

	[SerializeField]  private float lifeTime;

	//Destroys item after few sec
	public void Shoot ()
	{
		Debug.Log ("eh b0ss");
		Destroy (this.gameObject, lifeTime);
	}
}
