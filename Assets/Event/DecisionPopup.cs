using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class DecisionPopup : MonoBehaviour {
	public static DecisionPopup singleton;
	
	public GameObject popup;
	public Text eventText;

	protected Action onYes;
	protected Action onNo;

	void Start () {
		singleton = this;
		popup.SetActive(false);
	}
	
	public static void ShowPopup(string text, Action onYes, Action onNo) {
		singleton.eventText.text = text;
		singleton.popup.SetActive(true);
		singleton.onYes = onYes;
		singleton.onNo = onNo;
	}
	
	public void OnYes() {
		popup.SetActive(false);
		onYes();
	}
	
	public void OnNo() {
		popup.SetActive(false);
		onNo();
	}
}