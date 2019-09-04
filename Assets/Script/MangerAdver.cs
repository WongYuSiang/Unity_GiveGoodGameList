using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using LitJson;
public class MangerAdver : MonoBehaviour {
	public static MangerAdver Instance;//MangerAdver
	public GameObject AdverPanel;//廣告視窗
	public Adver mAdver=new Adver();
	public int itemIndex;
	public int adverLengh;
	public Image image;//哪個物件((要連結的
	public Sprite[] allLoadingPic;

	// Use this for initialization
	void Awake()
	{Instance = this;
	}
	void Start () {
		init ();

		allLoadingPic = Resources.LoadAll<Sprite> ("loading");

	}
	public void doOpen()
	{
		AdverPanel.SetActive (true);
		Debug.Log ("Open Ad");
		RefreshView ();


	}
	public void RefreshView()
	{
		adverLengh = mAdver.allAdverItem.Count;


		GetComponent<IntoAdverItem> ().Name.text = mAdver.allAdverItem [itemIndex].ItemName;
		GetComponent<IntoAdverItem> ().Description.text = mAdver.allAdverItem [itemIndex].ItemDes;

	}
	public void init()
	{
		string jsonstring = File.ReadAllText (Application.dataPath + "/Source/AdverData.json");
		//string jsonstring ;
		mAdver=JsonMapper.ToObject<Adver> (jsonstring.Trim());
		RefreshView();

	}
	public void doClose()
	{
		AdverPanel.SetActive (false);
		Debug.Log ("Close Ad");
	}
	public void doleft()
	{
		GetComponent<IntoAdverItem> ().Name.text = "Loading";
		GetComponent<IntoAdverItem> ().Description.text = "Loading";
		itemIndex++;
		if(itemIndex<0)
			itemIndex =adverLengh;
		else
			itemIndex = itemIndex % adverLengh;
		GetOnlineData.Instance.itemIndex = itemIndex;
		GetOnlineData.Instance.setDataBaseWork (DataBaseWorkType.Check, null);
	}
	public void doright()
	{
		GetComponent<IntoAdverItem> ().Name.text = "Loading";
		GetComponent<IntoAdverItem> ().Description.text = "Loading";
		itemIndex--;
		if(itemIndex<0)
			itemIndex =adverLengh-1;
		else
			itemIndex = itemIndex % adverLengh;
		GetOnlineData.Instance.itemIndex = itemIndex;
		GetOnlineData.Instance.setDataBaseWork (DataBaseWorkType.Check, null);

	}
	public Sprite setShopIcon(string IconName)
	{
		foreach (Sprite target in allLoadingPic) {
			if (target.name == IconName)
				return target;

		}
		return null;
	}
}
public class Adver
{
	public List <AdverItem> allAdverItem=new List<AdverItem>();
}
public class AdverItem
{
	public string ItemName;
	public string ItemIcon;
	public string ItemDes;
	public int Itemprice;

}
