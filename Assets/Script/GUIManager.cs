using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour {

	public Text scoreText;
	public Text lifeText;
	public Text timeText;
	public Text spaceBarText;
	public GameObject gamePaused;
	public Text textReady;
	public Text nameTextPause;
	public Text scoreTextPause;
	public Text timeTextPause;
	public Text lifeTextPause;
	public GameObject gameOverPanel;
	public Text nameTextGameOver;
	public Text scoreTextGameOver;
	public SaveLoadManager slm;
	
	// Use this for initialization
	void Start () {
		slm.loadData();
		Camera.main.aspect = 1980f / 1080f;
	}
	
	public void setScore(int score){
		scoreText.text = "Score: "+score;
	}
	public void setTime(int time){
		timeText.text = "Time:\n"+time;
	}
	public void setLife(int life){
		lifeText.text = "Life: "+life;
	}
	public void PauseGame(int life, int time, int score){
		nameTextPause.text = "Name: "+slm.name;
		scoreTextPause.text = "Score: "+score;
		timeTextPause.text = "Time: "+time;
		lifeTextPause.text = "Life: "+life;
		gamePaused.SetActive(true);
	}
	public void respawnReady(int timeReady){
		textReady.text = "READY\n"+timeReady;
	}
	public void unrespawnReady(){
		textReady.text = "";
	}
	public void UnpauseGame(){
		gamePaused.SetActive(false);
	}
	public void respawnGameOver(int score){
		gameOverPanel.SetActive(true);
		nameTextGameOver.text = "Name: "+slm.name;
		scoreTextGameOver.text = "Score: "+score;
	}
	public void backToMainMenu(){
		Application.LoadLevel("mainMenu");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			
		}
	}
}
