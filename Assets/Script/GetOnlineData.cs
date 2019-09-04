using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LitJson;
using System.IO;
public enum DataBaseWorkType
{
	GetData,Check,GetImage,Finshed

}
public class GetOnlineData : MonoBehaviour {
	public static GetOnlineData Instance;
	public string DataLink;
	public string adverString;
	public bool isDataOK;
	public DataBaseWorkType curWork;
	public JsonData Data;
	private Adver tempAdver=new Adver();
	public AdverItem curAdver = new AdverItem ();
	public int ItemLengh;
	public int itemIndex;
	public Text adver;
	Sprite s;
	public Image image;//哪個物件((要連結的
	//Start
	void Start () 
	{
		itemIndex = 0;
		setDataBaseWork (DataBaseWorkType.Check, null);
	}
	//Awake
	void Awake()
	{
		Instance = this;
	}

	// Update is called once per frame
	void Update () {
		
	}
	public void setDataBaseWork(DataBaseWorkType workType,string JsonstringData)
	{
		curWork = workType;
		switch (workType) 
		{
			case DataBaseWorkType.Check:
				StartCoroutine ("CheckData");
				break;
			case DataBaseWorkType.GetData:
				StartCoroutine ("GatData");
				break;
			case DataBaseWorkType.GetImage:
				StartCoroutine ("LoadingImage");
				break;
			case DataBaseWorkType.Finshed:
				break;
			default:
				Debug.Log ("ERROR");
				break;

		}

	}
	IEnumerator CheckData()
	{
		WWW www = new WWW (DataLink+curWork.ToString()+".php");
		yield return www;
		print (www.text);
		JsonData data = JsonMapper.ToObject (www.text.Trim());
		if (int.Parse (data ["Check"].ToString ()) > 0) 
		{
			
			setDataBaseWork (DataBaseWorkType.GetData, null);
		}
	}

	IEnumerator GatData()
	{
		WWW www = new WWW (DataLink+curWork.ToString()+".php");
		yield return www;
		print (DataLink+curWork.ToString()+".php");
		tempAdver = JsonMapper.ToObject<Adver> (www.text.Trim ());
		print (www.text);
		print (tempAdver.allAdverItem.Count);
		print (tempAdver.allAdverItem [itemIndex].ItemName);
		MangerAdver.Instance.mAdver = tempAdver;
		if(tempAdver.allAdverItem.Count >0)
		{
			setDataBaseWork (DataBaseWorkType.GetImage, null);		
		}
	}
	IEnumerator LoadingImage()
	{
		yield return 0;
		WWW www_Image = new WWW (tempAdver.allAdverItem [itemIndex].ItemIcon);
		yield return www_Image;
		Texture2D texture = www_Image.texture;
		if (texture == null) {
			Debug.Log ("error");
		} 
		else 
		{
			Debug.Log ("loading");
			s = Sprite.Create (texture, new Rect (0, 0, texture.width, texture.height), Vector2.zero);
			try{image.GetComponent<Image> ().sprite = s;}
			catch{}
			isDataOK = true;
		}
		MangerAdver.Instance.RefreshView ();

	}
}
