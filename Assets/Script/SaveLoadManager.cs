using UnityEngine;
using System.Collections;

public class SaveLoadManager : MonoBehaviour {
	
	public string name;
	public void saveData(){
		PlayerPrefs.SetString("name",name);
	}
	public void loadData(){
		if(!PlayerPrefs.HasKey("name")){
			saveData();
		}else{
			name = PlayerPrefs.GetString("name");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
}
