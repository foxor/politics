using UnityEngine;
using System.Collections;

public class StatsUnfolder : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.canRead;
		}
	}
}