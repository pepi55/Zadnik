using UnityEngine;
using System.Collections;

public class PhotoObtain : MonoBehaviour {

	string path = "file://" + System.IO.Path.Combine(Application.persistentDataPath, "Images/image.png");
	private Texture texture;
	
	IEnumerator WaitForRequest(WWW www) {
		yield return www;
		
		if (www.error == null) {
			texture = www.texture;
		}    
	}
	
	void Start() {
		if(System.IO.File.Exists("/var/mobile/Applications/173DE26D-4C0E-4DF7-9DC6-9CBB7D4FC954/Documents/Images/image.png")){
			Debug.Log("YAY");
			Debug.Log(texture);
		}
		WWW www = new WWW(path);
		StartCoroutine(WaitForRequest(www));
	}
}
