using UnityEngine;
using System.Collections;

public class BlastCollider : MonoBehaviour {

	public static GroundController groundController;
	[SerializeField] private CircleCollider2D destructiveCollider;
	[SerializeField] private float blastRadius;

	public void Blast() 
	{
		destructiveCollider.radius = blastRadius;
		Debug.Log ("Entered The Blast");
		Debug.Log (blastRadius);
		Debug.Log (groundController);
		groundController.DestroyGround( destructiveCollider);

	}
}
