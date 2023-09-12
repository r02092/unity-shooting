using System;
using System.Collections;
using UnityEngine;
using Random=UnityEngine.Random;

public class EnemyGenerator:MonoBehaviour{
	public GameObject enemyPrefab;
	void Start(){
		InvokeRepeating("GenEnemy",1,9);
	}
	void GenEnemy(){
		int type=Random.Range(0,4);
		for(int i=0;i<new int[]{9,12,10,12,0,0,0,0}[type];i++){
			GameObject obj=Instantiate(enemyPrefab,new []{
				new Vector2(320+(i%3)*128,960+(i/3)*128),
				new Vector2(-128*i,480+(float)Math.Sin(Math.PI/6*i)*128),
				new Vector2(320+(i%2)*256,960+(i/2)*128),
				new Vector2(448+(float)Math.Sin(Math.PI/6*i)*128,960+128*i),
				new Vector2(0,0),
				new Vector2(0,0),
				new Vector2(0,0),
				new Vector2(0,0)
			}[type],Quaternion.identity);
			obj.GetComponent<SpriteRenderer>().sprite=Resources.LoadAll<Sprite>("enemy")[type];
			obj.GetComponent<EnemyController>().type=type;
			obj.GetComponent<EnemyController>().id=i;
		}
	}
}
