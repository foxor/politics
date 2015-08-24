using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stats : MonoBehaviour {
	public const float INFLUENCE_DEGENERATION = 0.999f;
	public static float ELECTION_LENGTH = 5f * 60f;

	public static Stats singleton;

	public Text statsPanel;

	public bool canRead;
	public bool canShare;
	public bool canWrite;
	public bool canPicket;
	public bool canRunForOffice;
	public bool canHire;
	public bool canRunEvent;
	public bool isElected;
	public bool hasHeardOffer;

	public float literacy;
	public float audience;
	public float audiencePerSecond;
	public float influence;
	public float money;

	public float interns;
	public float researchers;
	public float organizers;
	public float volunteers;

	public float influenceCheckpoint = 3000f;

	public int influenceMilestone;
	
	public float electionEnd;

	protected float tick;
	
	public float InfluencePct {
		get {
			return influence / influenceCheckpoint;
		}
	}
	
	public float TimePct {
		get {
			return (electionEnd - Time.time) / ELECTION_LENGTH;
		}
	}

	public void Awake() {
		singleton = this;
	}

	protected static string FormatFloat(float input) {
		if (input >= 100000000f) {
			return Mathf.Round(input / 1000000f) + "M";
		}
		if (input >= 100000f) {
			return Mathf.Round(input / 1000f) + "K";
		}
		return Mathf.Round(input) + "";
	}

	protected string genStatsText() {
		string r = "";
		if (isElected) {
			return r;
		}
		if (canRead && literacy > 0f) {
			r += "Literacy: " + FormatFloat(literacy) + "\n";
		}
		if (canShare && audience > 0f) {
			r += "Audience: " + FormatFloat(audience) + "\n";
		}
		if (canRunForOffice && money > 0f) {
			r += "Money: " + FormatFloat(money) + "\n";
		}
		if (canRunForOffice && (researchers > 0f || organizers > 0f || interns > 0f || volunteers > 0f)) {
			r += "Money / Second: " + FormatFloat(
				-(researchers * 370f) +
				-(organizers * 430f) +
				-(interns * 200f) +
				(volunteers * 40f)
			) + "\n";
		}
		r += "\n\n";
		if (interns > 0f) {
			r += "Interns: " + FormatFloat(interns * 20) + "\n";
		}
		if (researchers > 0f) {
			r += "Researchers: " + FormatFloat(researchers) + "\n";
		}
		if (organizers > 0f) {
			r += "Organizers: " + FormatFloat(organizers) + "\n";
		}
		if (volunteers > 0f) {
			r += "Volunteers: " + FormatFloat(volunteers) + "\n";
		}
		return r;
	}

	public void Update() {
		Unfolder.Poke();

		tick += Time.deltaTime;
		while (tick > 1f) {
			tick -= 1f;
			audience += audiencePerSecond;

			money -= interns * Random.Range(0f, 2f) * 200f;
			audience += interns * 3000f;
			money -= researchers * Random.Range(0f, 2f) * 370f;
			literacy += Mathf.Round(researchers * 30f);
			money -= organizers * Random.Range(0f, 2f) * 430f;
			influence += organizers * influenceCheckpoint * 0.005f;
			money += volunteers * Random.Range(0f, 2f) * 40f;

			if (money < -1f) {
				EventPopup.ShowPopup("You ran out of money, and had to fire everyone who isn't a volunteer");
				interns = 0f;
				researchers = 0f;
				organizers = 0f;
				money = 0f;
			}

			if (canRunForOffice && TimePct < 0f) {
				Picket.LoseCampaign();
			}
		}

		statsPanel.text = genStatsText();
	}

	public void FixedUpdate() {
		if (InfluencePct >= 1f) {
			Picket.AchieveMilestone();
		}
		influence *= INFLUENCE_DEGENERATION;
	}
}