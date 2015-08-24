using UnityEngine;
using System.Collections;

public class Write : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.canWrite && !Stats.singleton.isElected;
		}
	}

	public static string[] Descriptions = new string[] {
		"You pour a little bit of your soul into this post.",
		"You write a clickbait article.",
		"You hope this will get some people thinking.",
		"You publish an article you've had in mind for a long time.",
		"You write about the topic De Jour.",
		"You write the piece people have been clamoring for.",
		"You respond to an article by your friend."
	};

	public static string[] Outcomes = new string[] {
		"People love it!",
		"It gets a bunch of hits on social media.",
		"People are talking about it for a few days.",
		"As far as you can tell, nobody read it.",
		"It gets shared around.",
		"Everyone is talking about it.",
		"You enjoy a bump in popularity."
	};

	public void OnWrite() {
		Stats.singleton.audiencePerSecond += 1f;
		Stats.singleton.literacy = Mathf.Round(Stats.singleton.literacy * 1.4f);
		MessageLog.PushMessage(Talk.ChooseRandom(Descriptions) + "  " + Talk.ChooseRandom(Outcomes));
	}
}