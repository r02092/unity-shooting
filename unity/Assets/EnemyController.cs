using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	float fallSpeed;
	void Start(){
		this.fallSpeed=4+4*Random.value;
	}
	void Update(){
		transform.Translate(0,-fallSpeed,0,Space.World);
		if(transform.position.y<0){
			GameObject.Find("GameOver").GetComponent<UnityEngine.UI.Image>().enabled=true;
			Destroy(gameObject);
		}
	}
}
