using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public InputField inputName;
	public GameObject textNotif;
	string name;
	private bool nameCheck;
	public SaveLoadManager slm;
	
	void Start(){
		Camera.main.aspect = 1980f / 1080f;
	}
	public void exitGame(){
		Application.Quit();
	}
	public void checkName(){
		nameCheck = false;
		name = ""+inputName.text;
		if(name.Length != 0){
			for(int i=0; i<name.Length; i++){
				if(name[i] != ' '){
					nameCheck = true;
					break;
				}
			}
			if(nameCheck == true){
				slm.name = ""+name;
				slm.saveData();
				Application.LoadLevel("Snake");
			}else{
				textNotif.SetActive(true);
			}
		}else{
			textNotif.SetActive(true);
		}
	}
	void OnGUI(){
		if(Event.current.keyCode == KeyCode.Return){
			checkName();
		}
	}
}
