using UnityEngine;
using System.Collections;

public class Picket : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.canPicket && !Stats.singleton.isElected;
		}
	}

	public static string[] CorpNames = new string[] {
		"Puppy Parts Co",
		"Puppy industries",
		"Waldonalds",
		"Superco",
		"some poor schmuck's house",
		"a government building",
		"a law office",
		"your rival's campaign headquarters"
	};

	public static string[] Outcomes = new string[] {
		"They certainly heard you",
		"You're not sure if anyone was there",
		"They closed their windows",
		"They came out and talked to you about the issues",
		"All their employees were talking about you",
		"You're certain you raised some awareness",
		"They banned you from the premesis",
		"You were jailed for the night",
		"The police broke up your protest"
	};
	
	public static void BeginCampaign() {
		EventPopup.ShowPopup("You've been nominated for office!  Lots of people heard about it!");
		Stats.singleton.audience = 100000f;
		Stats.singleton.literacy = 5000f;
		Stats.singleton.influence = 0;
		Stats.singleton.influenceCheckpoint = 4e7f;
		Stats.singleton.audiencePerSecond = 5f;
		Stats.singleton.canRunForOffice = true;
		Stats.singleton.electionEnd = Time.time + Stats.ELECTION_LENGTH;
	}
	
	public static void LoseCampaign() {
		EventPopup.ShowPopup("You lost the election.  Your followers lost faith in you.  You can still qualify for the next election.");
		Stats.singleton.audience = 15000f;
		Stats.singleton.literacy = 500f;
		Stats.singleton.influenceCheckpoint = 50000f;
		Stats.singleton.influence = 0;
		Stats.singleton.audiencePerSecond = 0f;
		Stats.singleton.canRunForOffice = false;
		Stats.singleton.influenceMilestone = 1;
		Stats.singleton.hasHeardOffer = false;
		Stats.singleton.interns = 0f;
		Stats.singleton.researchers = 0f;
		Stats.singleton.organizers = 0f;
		Stats.singleton.volunteers = 0f;
		Stats.singleton.money = 0f;
		Stats.singleton.canHire = false;
	}

	public static void WinCampaign() {
		if (Fundraise.AcceptedMoney) {
			EventPopup.ShowPopup("You won the election, but lost the battle for puppy rights.");
		}
		else {
			EventPopup.ShowPopup("The point of the game is that this is impossible...  I guess you're just a really good politician and not a monster.");
		}
		Stats.singleton.audience = 15000f;
		Stats.singleton.literacy = 500f;
		Stats.singleton.influenceCheckpoint = 50000f;
		Stats.singleton.influence = 0;
		Stats.singleton.audiencePerSecond = 0f;
		Stats.singleton.canRunForOffice = false;
		Stats.singleton.influenceMilestone = 1;
		Stats.singleton.hasHeardOffer = false;
		Stats.singleton.interns = 0f;
		Stats.singleton.researchers = 0f;
		Stats.singleton.organizers = 0f;
		Stats.singleton.volunteers = 0f;
		Stats.singleton.money = 0f;
		Stats.singleton.isElected = true;
	}

	public static string AchieveMilestone() {
		Stats.singleton.influence = 0;
		Stats.singleton.influenceMilestone++;
		Stats.singleton.influenceCheckpoint *= 3f;
		Stats.singleton.audience += Mathf.Round(Stats.singleton.audience * 1.1f);

		string outcome = null;
		outcome = "They agree to change what they're doing";
		
		if (Stats.singleton.influenceMilestone == 1) {
			EventPopup.ShowPopup("You've achieved a political milestone!  Whenever your influence hits 100%, you achieve your goals!");
		}
		
		if (Stats.singleton.influenceMilestone == 2) {
			EventPopup.ShowPopup("The puppy rights movement is really gaining traction now!");
		}
		
		if (Stats.singleton.influenceMilestone > 2 && !Stats.singleton.canRunForOffice) {
			outcome += ".  Your followers beg you to run for office.";
			BeginCampaign();
		}
		else if (Stats.singleton.canRunForOffice) {
			WinCampaign();
		}
		return outcome;
	}

	public void OnPicket() {
		Stats.singleton.influence += Stats.singleton.audience;
		string outcome = null;
		if (Stats.singleton.InfluencePct < 1f) {
			outcome = Talk.ChooseRandom(Outcomes);
		}
		else {
			outcome = AchieveMilestone();
		}
		MessageLog.PushMessage("You gather a bunch of people and head to " + Talk.ChooseRandom(CorpNames) + ".  " + outcome + ".");
	}
}