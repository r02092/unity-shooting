using System;
using System.Collections;
using UnityEngine;

public class EnemyGenerator:MonoBehaviour{
	public GameObject enemyPrefab;
	private int time;
	void Start(){
		time=0;
	}
	void Update(){
		int type;
		switch(time){
			case 0:
				type=0;
				break;
			case 480:
				type=1;
				break;
			case 960:
				type=2;
				break;
			case 1440:
				type=3;
				break;
			case 2160:
				type=4;
				break;
			case 2880:
				type=0;
				break;
			case 3360:
				type=3;
				break;
			case 4080:
				type=5;
				break;
			case 4560:
				type=1;
				break;
			case 5040:
				type=6;
				break;
			case 5400:
				type=7;
				break;
			default:
				type=-1;
				break;
		}
		if(type!=-1){
			for(int i=0;i<new int[]{9,12,10,12,4,10,2,1}[type];i++){
				GameObject obj=Instantiate(enemyPrefab,new []{
					new Vector2(320+(i%3)*128,960+(i/3)*128),
					new Vector2(16-128*i,480+(float)Math.Sin(Math.PI/6*i)*128),
					new Vector2(320+(i%2)*256,960+(i/2)*128),
					new Vector2(448+(float)Math.Sin(Math.PI/6*i)*128,960+128*i),
					new Vector2(880+128*i,832),
					new Vector2(i%2<1?16-128*i:752+128*i,320+(i/2)*128),
					new Vector2(16+864*i,320),
					new Vector2(448,960)
				}[type],Quaternion.identity);
				obj.name="ene"+type.ToString()+"-"+i.ToString();
				obj.GetComponent<SpriteRenderer>().sprite=Resources.LoadAll<Sprite>("enemy")[new int[]{0,1,2,3,4,5,6,7}[type]];
				obj.GetComponent<EnemyController>().type=type;
				obj.GetComponent<EnemyController>().id=i;
				obj.GetComponent<EnemyController>().r=new int[]{32,32,32,32,32,32,32,32}[type];
				obj.GetComponent<EnemyController>().hp=new int[]{9,9,9,9,9,9,1,1000}[type];
			}
		}
		time++;
	}
}
