using System;
using System.Collections;
using UnityEngine;

public class JikiController:MonoBehaviour{
	private int t=0;
	public GameObject PlBulletPrefab;
	void Update(){
		float c=8;
		int dy=0;
		if(!GameObject.Find("GameOver").GetComponent<UnityEngine.UI.Image>().enabled){
			if(Input.GetKey(KeyCode.UpArrow)){
				dy=1;
			}else if(Input.GetKey(KeyCode.DownArrow)){
				dy=-1;
			}
			if(Input.GetKey(KeyCode.LeftArrow)){
				if(transform.position.x>96)transform.Translate(-c,0,0);
			}else if(Input.GetKey(KeyCode.RightArrow)){
				if(transform.position.x<800)transform.Translate(c,0,0);
			}else if(dy>0&&Input.GetKey(KeyCode.DownArrow)){
				dy=-1;
			}
			if(dy<0&&transform.position.y>80||dy>0&&transform.position.y<880)transform.Translate(0,c*dy,0);
			if(Input.GetKey(KeyCode.Z)){
				if(t<1)Instantiate(PlBulletPrefab,transform.position,Quaternion.identity);
				t++;
				if(t==3)t=0;
			}
		}
	}
	void OnTriggerStay2D(Collider2D coll){
		if(coll.gameObject.name!="pl-bullet(Clone)"){
			int enemyR=coll.gameObject.name.Substring(0,3)!="ene"?coll.gameObject.GetComponent<EnBulletController>().r:coll.gameObject.GetComponent<EnemyController>().r;
			if(Math.Pow(enemyR,2)+36>Math.Pow(coll.gameObject.transform.position.x-transform.position.x,2)+Math.Pow(coll.gameObject.transform.position.y-transform.position.y,2)){
				GameObject.Find("GameOver").GetComponent<UnityEngine.UI.Image>().enabled=true;
				Destroy(coll.gameObject);
				Destroy(gameObject);
			}else{
				GameObject.Find("GameObject").GetComponent<UIController>().AddScore(1);
			}
		}
	}
}
