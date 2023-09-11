using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	float fallSpeed;
	void Start(){
		this.fallSpeed=.01f+.01f*Random.value;
	}
	void Update(){
		transform.Translate(0,-fallSpeed,0,Space.World);
		if(transform.position.y<-6)Destroy(gameObject);
	}
}
