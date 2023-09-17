using System.Collections;
using UnityEngine;

public class PlBulletController:MonoBehaviour{
	void Update(){
		transform.Translate(0,20,0);
		if(transform.position.y>960)Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.name.Substring(0,3)=="ene"){
			coll.gameObject.GetComponent<EnemyController>().damage(1);
			Destroy(gameObject);
		}
	}
}
