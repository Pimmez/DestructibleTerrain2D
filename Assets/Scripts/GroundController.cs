using UnityEngine;
using System.Collections;

public class GroundController : MonoBehaviour {

	private SpriteRenderer spriteRender;
	private float widthWorld, heightWorld;
	private int widthPixel, heightPixel;
	private Color transp; 
	[SerializeField] private string textureName;

	void Start(){
		spriteRender = GetComponent<SpriteRenderer>(); 
		// spriteRender: global variable of GroundController ref to SpriteRenderer Ground
		Texture2D tex = (Texture2D) Resources.Load(textureName);
		// Resources.Load ( "filename") loads a file located
		// In Assets / Resources
		Texture2D tex_clone = (Texture2D) Instantiate(tex);
		// We created a Texture2D tex clone to not alter the original image
		spriteRender.sprite = Sprite.Create(tex_clone, 
		                          new Rect(0f, 0f, tex_clone.width, tex_clone.height),
		                          new Vector2(0.5f, 0.5f), 100f);
		transp = new Color(0f, 0f, 0f, 0f);
		InitSpriteDimensions();
		BulletController.groundController = this;
	}

	private void InitSpriteDimensions() {
		widthWorld = spriteRender.bounds.size.x;
		heightWorld = spriteRender.bounds.size.y;
		widthPixel = spriteRender.sprite.texture.width;
		heightPixel = spriteRender.sprite.texture.height;
	}

	public void DestroyGround( CircleCollider2D circleColl ){

		V2int c = World2Pixel(circleColl.bounds.center.x, circleColl.bounds.center.y);
		// C => center of the destruction of circle in pixels
		int r = Mathf.RoundToInt(circleColl.bounds.size.x*widthPixel/widthWorld);
		// r => Destroy the circle Radius;

		int x, y, px, nx, py, ny, d;
		Debug.Log ("DestroyGround");

		for (x = 0; x <= r; x++)
		{
			d = (int)Mathf.RoundToInt(Mathf.Sqrt(r * r - x * x));
			
			for (y = 0; y <= d; y++)
			{
				px = c.x + x;
				nx = c.x - x;
				py = c.y + y;
				ny = c.y - y;

				spriteRender.sprite.texture.SetPixel(px, py, transp);
				spriteRender.sprite.texture.SetPixel(nx, py, transp);
				spriteRender.sprite.texture.SetPixel(px, ny, transp);
				spriteRender.sprite.texture.SetPixel(nx, ny, transp);
			}
		}
		spriteRender.sprite.texture.Apply();
		Destroy(GetComponent<PolygonCollider2D>());
		gameObject.AddComponent<PolygonCollider2D>();
	}

	private V2int World2Pixel(float x, float y) {
		V2int v = new V2int();
		
		float dx = x-transform.position.x;
		v.x = Mathf.RoundToInt(0.5f*widthPixel+ dx*widthPixel/widthWorld);
		
		float dy = y - transform.position.y;
		v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / heightWorld);
		
		return v;
	}
}
