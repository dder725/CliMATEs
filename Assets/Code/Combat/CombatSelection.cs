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

	public GameObject AnimalMovesPanel;

	public GameObject AnimalMovesPrefabText;

	private bool selectingAnimalMove = false;

	private bool inCombat = false;
	private bool combatActive = false;
	private string monsterName;
	public Text action1;
	public Text action2;
	public Text action3;
	public Text action4;
	private List<Text> actions = new List<Text>();
	private int numSelections = 4;
	private int actionSelection = 0;
	
    void Start()
    {
		setDefaultActions();

		ExitPanel.gameObject.SetActive(false);
		ExitStatus.gameObject.SetActive(false);

		EventManager.StartListening("combatStart", new UnityAction(startCombat)); 
		EventManager.StartListening("combatConclusion", new UnityAction(concludeCombat));
    }

	private void setDefaultActions()
	{
		selectingAnimalMove = false;
		actionSelection = 0;
		numSelections = 4;

		actions = new List<Text>()
		{
			action1,
			action2,
			action3,
			action4
		};
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
						if (selectingAnimalMove)
						{
							CombatManager.nextMove = CombatManager.Move.AnimalMove;
							switch (actionSelection)
							{
								case 0:
									CombatManager.nextAnimalMove = CombatManager.AnimalMove.BeeMove;
									break;
								case 1:
									CombatManager.nextAnimalMove = CombatManager.AnimalMove.ButterflyMove;
									break;
								case 2:
									CombatManager.nextAnimalMove = CombatManager.AnimalMove.TurtleMove;
									break;
								case 3:
									CombatManager.nextAnimalMove = CombatManager.AnimalMove.PolarBearMove;
									break;
								default:
									break;
							}

							// Reset the action menus
							setDefaultActions();
							changeSelection();

							// Hide/remove animal moves
							AnimalMovesPanel.SetActive(false);
							foreach (Transform child in AnimalMovesPanel.transform)
							{
								Destroy(child.gameObject);
							}

							// Trigger the turn logic
							EventManager.TriggerEvent("combatNextTurn");
						}
						else
						{
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
									AnimalMovesPanel.SetActive(true);
									selectingAnimalMove = true;

									actions.Clear();
									numSelections = 0;
									actionSelection = 0;


									foreach (var move in CombatManager.availableAnimalMoves)
									{
										Debug.Log("Instantiating available move: " + move.ToString());
										GameObject moveText = Instantiate(AnimalMovesPrefabText, AnimalMovesPanel.transform);
										Text text = moveText.GetComponent<Text>();

										// Update the actions list
										actions.Add(text);
										numSelections++;
									
										switch (move)
										{
											case CombatManager.AnimalMove.BeeMove:
												text.text = "Sting";
												break;
											case CombatManager.AnimalMove.ButterflyMove:
												text.text = "Cocoon";
												break;
											default:
												break;
										}
									}
									changeSelection();

									break;
							}
							// Trigger the turn logic
							EventManager.TriggerEvent("combatNextTurn");
						}
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
