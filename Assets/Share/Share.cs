using UnityEngine;
using System.Collections;

public class Share : Unfolder {
	public string[] Circumstances = new string[] {
		"at the Puppy-Welfare-Alliance (PWA) meeting",
		"on the street",
		"at the gym",
		"while shopping for shoes",
		"at the office",
		"on a run",
		"at the grocery story",
		"at a party",
		"at the bar",
		"in a record store",
		"at the firing range",
		"at the game"
	};

	public static string[] Outcomes = new string[] {
		"but they've already read it.",
		"and they told everyone they know.",
		"and they won't stop talking about it.",
		"and they read the whole thing.",
		"but they didn't like it.",
		"but you don't think they'll actually read it.",
		"and they were excited to pick up a copy."
	};

	protected override bool unfolded {
		get {
			return Stats.singleton.canShare && !Stats.singleton.isElected;
		}
	}

	public void OnShare() {
		Stats.singleton.audience += Mathf.Round(Stats.singleton.literacy / 2f);
		if (Stats.singleton.literacy > 40 && !Stats.singleton.canWrite) {
			Stats.singleton.canWrite = true;
			MessageLog.PushMessage("You've been looking for an article describing how the world would be different if puppies were safe from the giant coorperations, but nobody has written it yet!  You suppose it's time to write it yourself.");
		}
		else {
			MessageLog.PushMessage("You ran into " + Talk.ChooseRandom(Talk.Names) + " " + Talk.ChooseRandom(Circumstances) + " and you recommended them a book about " + Talk.ChooseRandom(Talk.Topics) + ", " + Talk.ChooseRandom(Outcomes));
		}
	}
}