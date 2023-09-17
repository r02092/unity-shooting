using System;
using System.Collections;
using UnityEngine;
using Random=UnityEngine.Random;

public class EnemyController:MonoBehaviour{
	public int type;
	public int id;
	public int r;
	public int hp;
	public bool eraseBullets;
	public int time;
	public int timeDamage;
	public GameObject explosionPrefab;
	public GameObject EnBulletPrefab;
	private GameObject gameobjectObj;
	private GameObject gameover;
	private GameObject jiki;
	public void damage(int pow){
		if(gameObject.name.Substring(0,3)=="ene"){
			gameobjectObj.GetComponent<UIController>().AddScore(10);
			hp-=pow;
			if(hp<1){
				Instantiate(explosionPrefab,transform.position,Quaternion.identity);
				if(type==7)GameObject.Find("Clear").GetComponent<UnityEngine.UI.Image>().enabled=true;
				Destroy(gameObject);
			}else{
				timeDamage=time;
				gameObject.GetComponent<SpriteRenderer>().color=new Color(0,0,1);
			}
		}
	}
	void Start(){
		gameobjectObj=GameObject.Find("GameObject");
		gameover=GameObject.Find("GameOver");
		jiki=GameObject.Find("jiki");
		time=0;
	}
	void Update(){
		if(!gameover.GetComponent<UnityEngine.UI.Image>().enabled){
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
						if(hp>700){
							if(time%5<1){
								GameObject bullet1=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
								bullet1.GetComponent<EnBulletController>().dx=2*(float)Math.Cos(time);
								bullet1.GetComponent<EnBulletController>().dy=2*(float)Math.Sin(time);
								GameObject bullet2=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
								bullet2.GetComponent<EnBulletController>().dx=2*(float)Math.Cos(-time);
								bullet2.GetComponent<EnBulletController>().dy=2*(float)Math.Sin(-time);
							}
						}else if(hp==700){
							if(!eraseBullets){
								eraseBullets=true;
							}else{
								eraseBullets=false;
								hp--;
							}
						}else if(hp>400){
							if(time%90<1){
								for(int i=-24;i<24;i++){
									GameObject bullet=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
									bullet.GetComponent<EnBulletController>().dx=4*(float)Math.Cos(Math.PI/24*(i+Convert.ToInt32(time%180<1)*.5f));
									bullet.GetComponent<EnBulletController>().dy=4*(float)Math.Sin(Math.PI/24*(i+Convert.ToInt32(time%180<1)*.5f));
								}
							}
						}else if(hp==400){
							if(!eraseBullets){
								eraseBullets=true;
							}else{
								eraseBullets=false;
								hp--;
							}
						}else{
							if(time%60<40){
								if(time%4<1){
									double angle=Math.Atan2(jiki.transform.position.y-transform.position.y,jiki.transform.position.x-transform.position.x);
									for(int i=-8;i<8;i++){
										GameObject bullet=Instantiate(EnBulletPrefab,transform.position,Quaternion.identity);
										int rnd=Random.Range(-2,2);
										bullet.GetComponent<EnBulletController>().dx=8*(float)Math.Cos(angle+Math.PI/8*(i+rnd*.1f));
										bullet.GetComponent<EnBulletController>().dy=8*(float)Math.Sin(angle+Math.PI/8*(i+rnd*.1f));
									}
								}
							}
						}
					}
					break;
			}
			time++;
			if(time-timeDamage>1)gameObject.GetComponent<SpriteRenderer>().color=new Color(1,1,1);
		}
	}
}
