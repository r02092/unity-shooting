using System.Collections;
using UnityEngine;

public class EnBulletController:MonoBehaviour{
	public float dx;
	public float dy;
	public int r=16;
	void Update(){
		transform.Translate(dx,dy,0);
		if(GameObject.Find("Clear").GetComponent<UnityEngine.UI.Image>().enabled||transform.position.x<48||transform.position.x>848||transform.position.y<16||transform.position.y>944)Destroy(gameObject);
	}
}
