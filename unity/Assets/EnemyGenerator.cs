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
		Instantiate(enemyPrefab,new Vector3(6*Random.value,6,0),Quaternion.identity);
	}
}
