using UnityEngine;
using System.Collections;

public class Talk : Unfolder {
	protected override bool unfolded {
		get {
			return !Stats.singleton.isElected;
		}
	}

	public static string[] TutorialSequence = new string[] {
		"Your friend Molly told you about some crazy puppy rights abuses being committed by companies for profit.  You're super outraged!",
		"You talk to Molly again, and she's also angry about those poor puppies.  You two decide to do something about it!"
	};

	public static string[] ConversationTypes = new string[] {
		"quick chat",
		"awkward conversation",
		"involved lunch meeting",
		"enjoyable conversation",
		"extended debate",
		"facebook argument",
		"hearty banter",
		"verbal sparring match"
	};

	public static string[] Names = new string[] {
		"Kathy",
		"Mike",
		"Roy",
		"Joseph",
		"Molly",
		"Rob",
		"Dave",
		"Karen",
		"Chuck",
		"Berry",
		"Joe",
		"Kelly",
		"Rachell",
		"Liz",
		"Kim"
	};

	public static string[] Topics = new string[] {
		"the environment",
		"how wrong it is that companies can just kill puppies like that",
		"how cute puppies are",
		"the economy",
		"health care",
		"puppy welfare",
		"the protection puppy social movement",
		//"#puppylivesmatter",
		"foreign affairs",
		"puppies",
		"politics",
		"nutrition"
	};

	public static string[] Outcomes = new string[] {
		"didn't agree at first, but came around",
		"strongly agreed",
		"appreciated what you had to say",
		"stood their ground",
		"quietly disagreed",
		"were quickly persuaded",
		"left in a huff",
		"may never speak to you again"
	};

	public static string ChooseRandom(string[] args) {
		return args[Random.Range(0, args.Length)];
	}

	public string GenerateStartingMessage() {
		return "You had a " + ChooseRandom(ConversationTypes) + " with " + ChooseRandom(Names) + " about " + ChooseRandom(Topics) + ".  They " + ChooseRandom(Outcomes) + ".";
	}


	
	public int talkCount = 0;
	public void OnTalk() {
		if (talkCount < TutorialSequence.Length) {
			MessageLog.PushMessage(TutorialSequence[talkCount]);
		}
		else if (talkCount == 5) {
			MessageLog.PushMessage("You met Aaron for coffee, and ended up spending an hour talking about puppy rights issues.  He recommended you a book on the subject.");
			Stats.singleton.canRead = true;
		}
		else if (Stats.singleton.literacy > 10 && !Stats.singleton.canShare) {
			Stats.singleton.canShare = true;
			MessageLog.PushMessage("You attend a meeting of the Puppy-Minded-Alliance (PMA), and they ask everyone to share something they've read.");
		}
		else if (Stats.singleton.audience >= 500 && !Stats.singleton.canPicket) {
			Stats.singleton.canPicket = true;
			MessageLog.PushMessage("Some of the people at the PMA are ready to take action.  If you lead, they'll follow.");
		}
		else {
			MessageLog.PushMessage(GenerateStartingMessage());
		}
		
		if (Random.Range(0, 3) == 2) {
			Stats.singleton.literacy ++;
			Stats.singleton.literacy += Mathf.Round(Stats.singleton.literacy * 0.05f);
		}
		if (Random.Range(0, 2) == 0) {
			Stats.singleton.audience ++;
			Stats.singleton.audience += Mathf.Round(Stats.singleton.audience * 0.05f);
		}

		talkCount++;
	}
}