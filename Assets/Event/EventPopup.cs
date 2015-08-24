using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventPopup : MonoBehaviour {
	public static EventPopup singleton;

	public GameObject popup;
	public Text eventText;

	void Start () {
		singleton = this;
		popup.SetActive(false);
	}

	public static void ShowPopup(string text) {
		singleton.eventText.text = text;
		singleton.popup.SetActive(true);
	}

	public void OnClose() {
		popup.SetActive(false);
	}
}