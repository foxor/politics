using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Influence : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.canPicket && !Stats.singleton.isElected;
		}
	}

	public Slider slider;

	public void Update() {
		slider.value = Stats.singleton.InfluencePct;
	}
}