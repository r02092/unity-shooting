using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
	private float scale=1;
	void Update(){
		scale+=.02f;
		transform.localScale=new Vector3(scale,scale,1);
		gameObject.GetComponent<Renderer>().material.SetFloat("_Alpha",1-.3f*scale);
		if(scale>4)Destroy(gameObject);
	}
}
