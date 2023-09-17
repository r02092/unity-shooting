using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class UIController:MonoBehaviour{
	int score=0;
	float timeMn;
	float timeCnt;
	int frames;
	GameObject scoreText;
	[SerializeField] TextMeshProUGUI textScore;
	[SerializeField] TextMeshProUGUI textFps;
	public void AddScore(int ds){
		this.score+=ds;
	}
	void Start(){
		Application.targetFrameRate=60;
	}
	void Update(){
		textScore.text=String.Format("{0:#,0}",score);
		timeMn-=Time.deltaTime;
		timeCnt+=Time.timeScale/Time.deltaTime;
		frames++;
		if(timeMn<0){
			timeMn=1;
			float fps=timeCnt/frames;
			textFps.text=fps.ToString("f1")+"fps";
			if(fps<30){
				textFps.color=new Color32(80,80,254,255);
			}else if(fps<40){
				textFps.color=new Color32(159,159,254,255);
			}else{
				textFps.color=new Color32(254,254,254,255);
			}
			timeCnt=0;
			frames=0;
		}
	}
}
