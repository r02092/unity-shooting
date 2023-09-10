using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JikiController : MonoBehaviour
{
	private int t=0;
	public GameObject PlBulletPrefab;
	void Update(){
		float c=.01f;
		if(Input.GetKey(KeyCode.DownArrow ))transform.Translate( 0,-c,0);
		if(Input.GetKey(KeyCode.LeftArrow ))transform.Translate(-c, 0,0);
		if(Input.GetKey(KeyCode.RightArrow))transform.Translate( c, 0,0);
		if(Input.GetKey(KeyCode.UpArrow   ))transform.Translate( 0, c,0);
		if(Input.GetKey(KeyCode.Z)){
			if(t==0)Instantiate(PlBulletPrefab,transform.position,Quaternion.identity);
			t++;
			if(t==3)t=0;
		}
	}
}
