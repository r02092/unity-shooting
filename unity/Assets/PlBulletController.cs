using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlBulletController : MonoBehaviour
{
	public GameObject explosionPrefab;
	void Update(){
		transform.Translate(0,.2f,0);
		if(transform.position.y>6)Destroy(gameObject);
	}
	void OnTriggerEnter2D(Collider2D coll){
		Instantiate(explosionPrefab,transform.position,Quaternion.identity);
		Destroy(coll.gameObject);
		Destroy(gameObject);
	}
}
