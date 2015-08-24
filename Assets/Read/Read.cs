using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Read : Unfolder {
	protected Dictionary<string, float> outcomes = new Dictionary<string, float>() {
		{"Your mind overflows with new puppy rights tips and tricks for more effective advocacy.", 6f},
		{"You learned a thing or two from that book.", 4f},
		{"An alternate history of a world where kitties are persecuted, instead of puppies.  Insightful!", 7f},
		{"A real page turner, but not a lot of new information.", 3f},
		{"Nothing like a re-read of the classic \"The Poky Little Puppy\" to remind you why you're here.", 5f}
	};

	protected override bool unfolded {
		get {
			return Stats.singleton.canRead && !Stats.singleton.isElected;
		}
	}

	public void OnRead() {
		string key = Talk.ChooseRandom(outcomes.Keys.ToArray());
		Stats.singleton.literacy += outcomes[key] + Mathf.Round(Stats.singleton.literacy * 0.1f);
		MessageLog.PushMessage(key);
	}
}