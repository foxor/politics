using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Panel : Unfolder {
	public GameObject myPanel;
	public GameObject[] otherPanels;

	protected override bool unfolded {
		get {
			return Stats.singleton.canRunForOffice || Stats.singleton.isElected;
		}
	}

	public void Start() {
		OnClick();
	}

	public void OnClick() {
		myPanel.SetActive(true);
		if (!unfolded || !Cooldown.AUTOPLAY) {
			foreach (GameObject g in otherPanels) {
				g.SetActive(false);
			}
		}
	}
}