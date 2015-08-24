using UnityEngine;
using System.Collections;

public class Hire : Unfolder {
	protected override bool unfolded {
		get {
			return Stats.singleton.canHire && Stats.singleton.canRunForOffice;
		}
	}

	public GameObject HireButtonsPanel;

	public void OnClickHire() {
		HireButtonsPanel.SetActive(true);
	}
	
	public void OnHireIntern() {
		HireButtonsPanel.SetActive(false);
		Stats.singleton.interns += 1f;
		MessageLog.PushMessage("You hired an intern.  They'll support your following.");
	}
	
	public void OnHireResearcher() {
		HireButtonsPanel.SetActive(false);
		Stats.singleton.researchers += 1f;
		MessageLog.PushMessage("You hired a researcher.  They'll keep you up to date on current topics.");
	}
	
	public void OnHireOrganizer() {
		HireButtonsPanel.SetActive(false);
		Stats.singleton.organizers += 1f;
		MessageLog.PushMessage("You hired an organizer.  They'll keep your influence growing.");
	}
	
	public void OnHireVolunteer() {
		HireButtonsPanel.SetActive(false);
		Stats.singleton.volunteers += 1f;
		MessageLog.PushMessage("You hired a volunteer.  They'll collect money from your supporters.");
	}
}