using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine.UI;
public class IntoAdverItem : MonoBehaviour {
	public Text Name;
	public Text Description;
	public Image Icon;
	// Use this for initialization
	void Start () {
	
	}
	void init()
	{
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void doOpen()
	{
		init ();
		MangerAdver.Instance.doOpen ();
	}
	public void doClose()
	{
		MangerAdver.Instance.doClose();
	}
	public void doLeft()
	{
		MangerAdver.Instance.doleft();

	}
	public void doRight()
	{
		MangerAdver.Instance.doright();
	}

}
