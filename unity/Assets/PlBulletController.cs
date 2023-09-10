using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlBulletController : MonoBehaviour
{
	void Update(){
		transform.Translate(0,.2f,0);
		if(transform.position.y>6)Destroy(gameObject);
	}
}
