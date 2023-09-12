using System;
using System.Collections;
using UnityEngine;

public class EnemyController:MonoBehaviour{
	public int type;
	public int id;
	private int time;
	void Start(){
		time=0;
	}
	void Update(){
		switch(type){
			case 0:
				if(time<360){
					transform.Translate(0,-1,0);
				}else if(time<1128){
					if(id!=4){
						int t0speed=2;
						int t0step=(128*new int[]{0,1,2,7,0,3,6,5,4}[id]/t0speed+time-360)%(1024/t0speed);
						if(t0step<256/t0speed){
							transform.Translate(t0speed,0,0);
						}else if(t0step<512/t0speed){
							transform.Translate(0,t0speed,0);
						}else if(t0step<768/t0speed){
							transform.Translate(-t0speed,0,0);
						}else{
							transform.Translate(0,-t0speed,0);
						}
					}
				}else{
					transform.Translate(0,1,0);
					if(transform.position.y>960)Destroy(gameObject);
				}
				break;
			case 1:
				transform.Translate(1,0,0);
				if(transform.position.x>880)Destroy(gameObject);
				break;
			case 2:
				if(time<720){
					transform.Translate(0,-1,0);
				}else if(time>1024){
					transform.Translate((id%2)*2-1,0,0);
				}
				if(time>1328)Destroy(gameObject);
				break;
			case 3:
				transform.Translate(448+(float)Math.Sin((id+(float)time/64)*Math.PI/6)*128-transform.position.x,-1,0);
				if(transform.position.y<0)Destroy(gameObject);
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
				break;
			case 7:
				break;
		}
		time++;
	}
}
