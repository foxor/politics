using UnityEngine;
using System.Collections;

public class Fundraise : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.canRunForOffice;
		}
	}

	public static bool AcceptedMoney;

	public void OnFundRaise() {
		Stats.singleton.money += 1000f;
		MessageLog.PushMessage("Your supporters are happy to contribute.");
		if (Stats.singleton.money > 10000f && !Stats.singleton.canHire) {
			Stats.singleton.canHire = true;
			MessageLog.PushMessage("That should be enough money to start hiring people.");
		}
		if (!Stats.singleton.hasHeardOffer && Stats.singleton.TimePct < 0.7f) {
			Stats.singleton.hasHeardOffer = true;
			DecisionPopup.ShowPopup("Puppy industries offers you $10000000 if you promise to vote to support their puppy killing ways", OnAccept, OnDecline);
		}
		if (Stats.singleton.money < 10000f && Stats.singleton.canHire) {
			Stats.singleton.hasHeardOffer = true;
			DecisionPopup.ShowPopup("It looks like you're running out of money.  Puppy industries could ensure you win this election if you help us out with some anti-puppy legislation.", OnAccept, OnDecline);
		}
	}

	protected void OnAccept() {
		Stats.singleton.money += 1000000f;
		EventPopup.ShowPopup("You've sold out your core values for power");
		AcceptedMoney = true;
	}

	protected void OnDecline() {
	}
}