using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class UIController:MonoBehaviour{
	int score=0;
	GameObject scoreText;
	[SerializeField] TextMeshProUGUI textMeshProUI;
	public void AddScore(int combo){
		this.score+=10*combo;
	}
	void Update(){
		textMeshProUI.text=String.Format("{0:#,0}",score);
	}
}
