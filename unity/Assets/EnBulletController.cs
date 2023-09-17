using System.Collections;
using UnityEngine;

public class EnBulletController:MonoBehaviour{
	public float dx;
	public float dy;
	public int r=16;
	private GameObject clear;
	void Start(){
		clear=GameObject.Find("Clear");
	}
	void Update(){
		transform.Translate(dx,dy,0);
		if(clear.GetComponent<UnityEngine.UI.Image>().enabled||GameObject.Find("ene7-0")!=null&&GameObject.Find("ene7-0").GetComponent<EnemyController>().eraseBullets||transform.position.x<48||transform.position.x>848||transform.position.y<16||transform.position.y>944)Destroy(gameObject);
	}
}
