using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JikiController : MonoBehaviour
{
	void Update(){
		float c=.01f;
		if(Input.GetKey(KeyCode.DownArrow ))transform.Translate( 0,-c,0);
		if(Input.GetKey(KeyCode.LeftArrow ))transform.Translate(-c, 0,0);
		if(Input.GetKey(KeyCode.RightArrow))transform.Translate( c, 0,0);
		if(Input.GetKey(KeyCode.UpArrow   ))transform.Translate( 0, c,0);
	}
}
