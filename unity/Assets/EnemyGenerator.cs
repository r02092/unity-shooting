using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
	public GameObject enemyPrefab;
	void Start(){
		InvokeRepeating("GenEnemy",1,4);
	}
	void GenEnemy(){
		Instantiate(enemyPrefab,new Vector3(64+768*Random.value,960,0),Quaternion.identity);
	}
}
