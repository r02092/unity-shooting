using System.Collections;
using UnityEngine;

public class EnemyController:MonoBehaviour{
	float fallSpeed;
	void Start(){
		this.fallSpeed=4+4*Random.value;
		this.gameObject.GetComponent<SpriteRenderer>().sprite=Resources.LoadAll<Sprite>("enemy")[Random.Range(0,8)];
	}
	void Update(){
		transform.Translate(0,-fallSpeed,0,Space.World);
		if(transform.position.y<0)Destroy(gameObject);
	}
}
