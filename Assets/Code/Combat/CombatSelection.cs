using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CombatSelection : MonoBehaviour
{
	private Panel currentPanel;
	public GameObject ActionMenu;
	public GameObject IntroductoryMenu;
	public GameObject ExitPanel;
	public GameObject ExitStatus;
	public Text introductoryMessage;

	private bool inCombat = false;
	private bool combatActive = false;
	private string monsterName;
	public Text action1;
	public Text action2;
	public Text action3;
	public Text action4;
	private Text[] actions;
	private int numSelections = 4;
	private int actionSelection = 0;
	
    void Start()
    {
		actions = new Text[] {action1, action2, action3, action4};

		ExitPanel.gameObject.SetActive(false);
		ExitStatus.gameObject.SetActive(false);

		EventManager.StartListening("combatStart", new UnityAction(startCombat)); 
		EventManager.StartListening("combatConclusion", new UnityAction(concludeCombat));
    }


    void Update()
    {
		if (inCombat) {
			if (combatActive) {
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) {
					// Switch from introductory panel to combat panel
					if (currentPanel == Panel.IntroductoryPanel){
						changePanel(Panel.ActionsPanel);
					}
					else {
						// Perform the selected action
						switch (actionSelection) {
							case 0:
								CombatManager.nextMove = CombatManager.Move.Attack;
								break;
							case 1:
								CombatManager.nextMove = CombatManager.Move.Heal;
								break;
							case 2:
								CombatManager.nextMove = CombatManager.Move.Flee;
								break;
							case 3:
								// Show animal moves
								break;
						}

						// Trigger the turn logic
						EventManager.TriggerEvent("combatNextTurn");
					}
				}
				else if (Input.GetKeyDown("right")) {
					actionSelection = (actionSelection + 1) % numSelections;
					changeSelection();
				}
				else if (Input.GetKeyDown("left")) {
					actionSelection = Math.Max(0, (actionSelection - 1) % numSelections);
					changeSelection();
				}
			}
			else {
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
				{
					Debug.Log("Exiting combat view");
					ExitPanel.gameObject.SetActive(false);
					ExitStatus.gameObject.SetActive(false);
					changePanel(Panel.IntroductoryPanel);
					inCombat = false;
					EventManager.TriggerEvent("combatExit");
				}
			}
		}
    }
	
	private void startCombat() {
		monsterName = CombatManager.mob.GetComponent<CombatStats>().combatName;
		changePanel(Panel.IntroductoryPanel);
		changeSelection();
		combatActive = true;
		inCombat = true;
	}
	
	private void changeSelection() {
		resetSelection();
		actions[actionSelection].text = "> " + actions[actionSelection].text;
	}

	private void resetSelection() {
		foreach (var action in actions)
		{
			action.text = action.text.Replace("> ", "");
		}
	}
	
	private void changePanel(Panel p) { //Switch panels with buttons
		
		currentPanel = p;
		
		switch(p) {
			case Panel.IntroductoryPanel:
				IntroductoryMenu.gameObject.SetActive(true);
				ActionMenu.gameObject.SetActive(false);
				introductoryMessage.text = "A WILD " + monsterName.ToUpper() +" APPEARED!";
				break;
			
			case Panel.ActionsPanel:
				IntroductoryMenu.gameObject.SetActive(false);
				ActionMenu.gameObject.SetActive(true);
				break;
		}
		
	}
	
	private enum Panel {
		IntroductoryPanel,
		ActionsPanel
	}

	private void concludeCombat() {
		Text exitStatus = ExitStatus.GetComponent<Text>();
		Text exitPanelText = ExitPanel.GetComponentInChildren<Text>();

		// Set exit messages
		if (CombatManager.combatStatus == CombatManager.CombatStatus.Win) {
			exitStatus.text = "VICTORY!";
			exitPanelText.text = "THE WILD " + monsterName.ToUpper() +" HAS VANISHED!";
		}
		else {
			exitStatus.text = "YOU LOSE!";
			exitPanelText.text = "THE WILD " + monsterName.ToUpper() +" KNOCKED YOU OUT!";
		}

		ExitPanel.gameObject.SetActive(true);
		ExitStatus.gameObject.SetActive(true);

		combatActive = false;
	}
}
