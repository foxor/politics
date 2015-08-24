using UnityEngine;
using System.Collections;

public class Event : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.TimePct < 0.5f && Stats.singleton.canRunForOffice;
		}
	}

	public void OnRunEvent() {
		switch (Random.Range(0, 4)) {
		case 0:
			MessageLog.PushMessage("You appear on a local TV spot");
			Stats.singleton.audience += 1500f;
			break;
		case 1:
			MessageLog.PushMessage("You host a charity dinner at $100 per plate");
			Stats.singleton.money += 3000f;
			break;
		case 2:
			MessageLog.PushMessage("You represent yourself well in a debate");
			Stats.singleton.literacy += 1500f;
			break;
		case 3:
			MessageLog.PushMessage("You kiss some babies");
			Stats.singleton.audiencePerSecond += 2f;
			break;
		}
		Stats.singleton.influence += 1000f;
	}
}