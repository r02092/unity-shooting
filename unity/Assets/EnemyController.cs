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
				if(time<90){
					transform.Translate(0,-4,0);
				}else if(time<282){
					if(id!=4){
						int t0speed=8;
						int t0step=(128*new int[]{0,1,2,7,0,3,6,5,4}[id]/t0speed+time-90)%(1024/t0speed);
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
					transform.Translate(0,4,0);
					if(transform.position.y>960)Destroy(gameObject);
				}
				break;
			case 1:
				transform.Translate(4,0,0);
				if(transform.position.x>880)Destroy(gameObject);
				break;
			case 2:
				if(time<180){
					transform.Translate(0,-4,0);
				}else if(time>240){
					transform.Translate((id%2)*8-4,0,0);
				}
				if(time>316)Destroy(gameObject);
				break;
			case 3:
				transform.Translate(448+(float)Math.Sin((id+(float)time/64)*Math.PI/6)*128-transform.position.x,-4,0);
				if(transform.position.y<0)Destroy(gameObject);
				break;
			case 4:
				int dx=0;
				int dy=0;
				if(transform.position.y>704){
					if(transform.position.x>128){
						dx=-4;
					}else{
						dy=-4;
					}
				}else{
					dx=4;
					if(transform.position.x>880)Destroy(gameObject);
				}
				transform.Translate(dx,dy,0);
				if(time%30<1){
					for(int i=0;i<3;i++){
						GameObject obj=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
						obj.GetComponent<EnBulletController>().dx=dx+new int[]{-2, 0, 2}[i];
						obj.GetComponent<EnBulletController>().dy=dy+new int[]{-2,-2,-2}[i];
					}
				}
				break;
			case 5:
				if(transform.position.x<320||transform.position.x>576){
					transform.Translate((id%2)*-8+4,0,0);
				}else if(time>400){
					transform.Translate(0,4,0);
					if(transform.position.y>960)Destroy(gameObject);
				}
				break;
			case 6:
				transform.Translate((id%2)*-8+4,1,0);
				if(time%30<1){
					for(int i=0;i<3;i++){
						GameObject obj=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
						obj.GetComponent<EnBulletController>().dx=(id%2)*-8+4+new int[]{(id%2)*-8+4,(id%2)*-8+4,  0}[i];
						obj.GetComponent<EnBulletController>().dy=          4+new int[]{         -8,        -12,-12}[i];
					}
				}
				if(transform.position.y>960)Destroy(gameObject);
				break;
			case 7:
				if(time<90){
					transform.Translate(0,-4,0);
				}else{
					if(time%5<1){
						GameObject obj=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
						obj.GetComponent<EnBulletController>().dx=2*(float)Math.Cos(time);
						obj.GetComponent<EnBulletController>().dy=2*(float)Math.Sin(time);
					}
				}
				break;
		}
		time++;
		if(time-timeDamage>1)gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1);
	}
}
