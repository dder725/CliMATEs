using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{


    [SerializeField]
    public Canvas dialogueCanvas;

    public Dialogue dialogue;

    public Queue<string> sentences;

    public Text dialogueText;

    private bool canStartConvo = false;
    private bool convoStarted = false;

    void Start()
    {
        dialogueCanvas.enabled = false;
        sentences = new Queue<string>();
    }

    void Update()
    {
        if(canStartConvo && Input.GetKeyDown(KeyCode.T)){
            Debug.Log("Start conversation");
            convoStarted = true;
            StartDialogue(dialogue);
        }

        if(canStartConvo && convoStarted && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }




    void OnTriggerStay2D(Collider2D other)
    {
        EnableDialogue();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        DisableDialogue();
    }

    private void EnableDialogue()
    {
        dialogueCanvas.enabled = true;

        canStartConvo = true;
    }

    private void DisableDialogue()
    {
        dialogueCanvas.enabled = false;

        canStartConvo = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }



    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    public void EndDialogue()
    {
        canStartConvo = false;
        convoStarted = false;
        dialogueText.text = "Press \"t\" to talk";
    }

}
