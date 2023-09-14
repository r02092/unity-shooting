using System;
using System.Collections;
using UnityEngine;

public class EnemyController:MonoBehaviour{
	public int type;
	public int id;
	public int r;
	public int hp;
	public int time;
	public int timeDamage;
	public GameObject EnBulletPrefab;
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
				int dx=0;
				int dy=0;
				if(transform.position.y>704){
					if(transform.position.x>128){
						dx=-1;
					}else{
						dy=-1;
					}
				}else{
					dx=1;
					if(transform.position.x>880)Destroy(gameObject);
				}
				transform.Translate(dx,dy,0);
				if(time%128==0){
					for(int i=0;i<3;i++){
						GameObject obj=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
						obj.GetComponent<EnBulletController>().dx=dx+new int[]{-1, 0, 1}[i];
						obj.GetComponent<EnBulletController>().dy=dy+new int[]{-1,-1,-1}[i];
					}
				}
				break;
			case 5:
				if(transform.position.x<320||transform.position.x>576){
					transform.Translate((id%2)*-2+1,0,0);
				}else if(time>1600){
					transform.Translate(0,1,0);
					if(transform.position.y>960)Destroy(gameObject);
				}
				break;
			case 6:
				transform.Translate((id%2)*-2+1,1,0);
				if(time%128==0){
					for(int i=0;i<3;i++){
						GameObject obj=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
						obj.GetComponent<EnBulletController>().dx=(id%2)*-2+1+new int[]{(id%2)*-2+1,(id%2)*-2+1, 0}[i];
						obj.GetComponent<EnBulletController>().dy=          1+new int[]{          -2,        -3,-3}[i];
					}
				}
				if(transform.position.y>960)Destroy(gameObject);
				break;
			case 7:
				if(time<360){
					transform.Translate(0,-1,0);
				}else{
					if(time%10==0){
						GameObject obj=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
						obj.GetComponent<EnBulletController>().dx=(float)Math.Cos(time);
						obj.GetComponent<EnBulletController>().dy=(float)Math.Sin(time);
					}
				}
				break;
		}
		time++;
		if(time-timeDamage>5)gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1);
	}
}
