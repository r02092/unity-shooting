using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlBulletController : MonoBehaviour
{
	public GameObject explosionPrefab;
	void Update(){
		transform.Translate(0,20,0);
		if(transform.position.y>960)Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D coll){
		GameObject.Find("GameObject").GetComponent<UIController>().AddScore();
		Instantiate(explosionPrefab,transform.position,Quaternion.identity);
		Destroy(coll.gameObject);
		Destroy(gameObject);
	}
}
