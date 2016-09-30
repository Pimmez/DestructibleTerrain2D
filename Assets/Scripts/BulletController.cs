using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletController : MonoBehaviour {

	public static GroundController groundController;
	private bool updateAngle = true; 
	[SerializeField] private CircleCollider2D destructionCircle;
	[SerializeField] private Transform bulletSpriteTransform; 
	[SerializeField] private string findWeapon;
	[SerializeField] private string objectTag;
	[SerializeField] private float blastRadius;

	private Nuke nuke;
	private Rigidbody2D rb;
	private IWeapon currentWeapon;
	private Bomb bomb;
	private Acid acid;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		bomb = GetComponent<Bomb> ();
		acid = GetComponent<Acid> ();
		nuke = GetComponent<Nuke> ();
		currentWeapon = bomb;
	}
	
	// Update is called once per frame
	void Update () {

		//List of weapons that can be used
		List<IWeapon> myWeapons = new List<IWeapon> ();
		if (Input.GetKeyDown (KeyCode.Q)) {
			myWeapons.Add (currentWeapon = bomb);
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			myWeapons.Add (currentWeapon = acid);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			myWeapons.Add (currentWeapon = nuke);
		}

		if( updateAngle ){
			Vector2 dir = new Vector2(rb.velocity.x, rb.velocity.y);
            dir.Normalize();			
			float angle = Mathf.Asin (dir.y)*Mathf.Rad2Deg;
			if( dir.x < 0f ){
				angle = 180 - angle;
			}
			bulletSpriteTransform.localEulerAngles = new Vector3(0f, 0f, angle+45f);
		}
	}

	//When Collision activates: set radius & on ground hit, find weapon and activate methode shoot
	void OnCollisionEnter2D(Collision2D coll){

		destructionCircle.radius = blastRadius;

		if(coll.collider.tag == "Ground"){
			if (GameObject.Find(findWeapon)) 
			{
				//Debug.Log (destructionCircle.radius);
				Debug.Log ("The Collision Section welcomes you!");
				groundController.DestroyGround( destructionCircle);
				currentWeapon.Shoot ();

				Debug.Log ("Mission Complete");
			}
		}
	}
}
