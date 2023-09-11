using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class UIController : MonoBehaviour
{
	int score=0;
	GameObject scoreText;
	[SerializeField] TextMeshProUGUI textMeshProUI;
	public void AddScore(){
		this.score+=10;
	}
	void Update(){
		textMeshProUI.text=String.Format("{0:#,0}",score);
	}
}
