using UnityEngine;
using System.Collections;

public class Folded : Unfolder {
	protected override bool unfolded {
		get {
			return false;
		}
	}
}