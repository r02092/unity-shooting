using System.Collections;
using UnityEngine;

public class PlBulletController:MonoBehaviour{
	public GameObject explosionPrefab;
	private int combo;
	void Start(){
		combo=1;
	}
	void Update(){
		transform.Translate(0,20,0);
		if(transform.position.y>960)Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.name=="enemy(Clone)"){
			GameObject.Find("GameObject").GetComponent<UIController>().AddScore(combo);
			Instantiate(explosionPrefab,transform.position,Quaternion.identity);
			if(coll.gameObject.GetComponent<EnemyController>().type==7)GameObject.Find("Clear").GetComponent<UnityEngine.UI.Image>().enabled=true;
			Destroy(coll.gameObject);
			combo++;
		}
	}
}
