using UnityEngine;
using System.Collections;

public class SnakeController : MonoBehaviour {

	public GamePlay gp;
	void OnTriggerEnter(Collider coll){
		//x = kolom
		//z = baris
		if(coll.tag == "dotAdd"){
			gp.GetDot(1,this.transform.localPosition.z*-1f,this.transform.localPosition.x);
			Destroy(coll.gameObject);
		}else if(coll.tag == "dotMinus"){
			gp.GetDot(2,this.transform.localPosition.z*-1f,this.transform.localPosition.x);
			Destroy(coll.gameObject);
		}
	}
}
