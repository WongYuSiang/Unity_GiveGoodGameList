using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpdateImage : MonoBehaviour {
	public Image image;//哪個物件((要連結的
	  Sprite s;
	Texture2D texture;
	string url = "https://drive.google.com/uc?export=download&id=0B5YTHT-7t5TId1ExamhKcmhVNWs";//下載連結網址
	// Use this for initialization
	IEnumerator Start () {
		yield return 0;
		WWW www_Image = new WWW (url);
		yield return www_Image;
		texture = www_Image.texture;
		if (texture == null) {
			Debug.Log ("error");
		} 
		else 
		{
			Debug.Log ("loading");
			s = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
			try{image.GetComponent<Image> ().sprite = s;}
			catch{}
		}

	}
	/*void OnGUI()
	{GUILayout.Label(texture);
	}*/
	// Update is called once per frame
	void Update () {
	
	}
}
