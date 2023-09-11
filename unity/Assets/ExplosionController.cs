using System.Collections;
using UnityEngine;

public class ExplosionController:MonoBehaviour{
	private float scale=100;
	void Update(){
		scale+=2;
		transform.localScale=new Vector3(scale,scale,1);
		gameObject.GetComponent<Renderer>().material.SetFloat("_Alpha",1-.003f*scale);
		if(scale>400)Destroy(gameObject);
	}
}
