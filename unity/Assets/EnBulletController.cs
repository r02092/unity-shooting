using System.Collections;
using UnityEngine;

public class EnBulletController:MonoBehaviour{
	public int dx;
	public int dy;
	void Update(){
		transform.Translate(dx,dy,0);
		if(transform.position.x<48||transform.position.x>848||transform.position.y<16||transform.position.y>944)Destroy(gameObject);
	}
}
