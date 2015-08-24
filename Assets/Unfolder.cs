using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public abstract class Unfolder : MonoBehaviour {
	public static List<Unfolder> unfolders = new List<Unfolder>();

	protected abstract bool unfolded {
		get;
	}

	public static void Poke() {
		foreach (Unfolder ufldr in unfolders) {
			ufldr.gameObject.SetActive(ufldr.unfolded);
		}
	}

	public void Awake() {
		unfolders.Add(this);
	}
}