using System.Collections;
using UnityEngine;

public class PlBulletController:MonoBehaviour{
	public GameObject explosionPrefab;
	void Update(){
		transform.Translate(0,20,0);
		if(transform.position.y>960)Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D coll){
		if(coll.gameObject.name=="enemy(Clone)"){
			GameObject.Find("GameObject").GetComponent<UIController>().AddScore();
			if(coll.gameObject.GetComponent<EnemyController>().hp--!=0){
				coll.gameObject.GetComponent<EnemyController>().timeDamage=coll.gameObject.GetComponent<EnemyController>().time;
				coll.gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0,1);
			}else{
				if(coll.gameObject.GetComponent<EnemyController>().type==7)GameObject.Find("Clear").GetComponent<UnityEngine.UI.Image>().enabled=true;
				Instantiate(explosionPrefab,transform.position,Quaternion.identity);
				Destroy(coll.gameObject);
			}
			Destroy(gameObject);
		}
	}
}
