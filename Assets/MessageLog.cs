using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageLog : MonoBehaviour {
	public Text eventLog;
	public float pushCooldown = 2f;

	protected static MessageLog singleton;

	public void Awake() {
		singleton = this;
	}

	public static void PushMessage(string message) {
		singleton.eventLog.text = message + "\n\n\n" + singleton.eventLog.text;
		if (singleton.eventLog.text.Length > 5000) {
			singleton.eventLog.text = singleton.eventLog.text.Substring(0, 1000);
		}
	}
}