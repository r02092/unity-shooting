using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class UIController:MonoBehaviour{
	int score=0;
	GameObject scoreText;
	[SerializeField] TextMeshProUGUI textMeshProUI;
	public void AddScore(){
		this.score+=10;
	}
	void Start(){
		Application.targetFrameRate=60;
	}
	void Update(){
		textMeshProUI.text=String.Format("{0:#,0}",score);
	}
}
