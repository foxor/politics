using UnityEngine;
using System.Collections;

public class Vote : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.isElected;
		}
	}

	protected static string[] outcomes = new string[] {
		"You feel empty inside.",
		"You vote on some meaningless parlamentary procedeure.",
		"You betray the puppies.",
		"You worry about what people think of you.",
		"Your approval rating is low.",
		"You vote for someone else's pet project.",
		"You vote randomly.",
		"You try to make a difference.  It doesn't work.",
		"You vote for the giant coorporations that got you here.",
	};

	public void OnVote() {
		MessageLog.PushMessage(Talk.ChooseRandom(outcomes));
	}
}