using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ElectionTimer : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.canRunForOffice;
		}
	}
	
	public Slider slider;
	
	public void Update() {
		slider.value = 1f - Stats.singleton.TimePct;
	}
}
