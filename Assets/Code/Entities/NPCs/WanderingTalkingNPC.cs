using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WanderingTalkingNPC : Entity
{

    [SerializeField]
    public Canvas dialogueCanvas;

    public Dialogue dialogue;

    public Queue<string> sentences;

    public Text dialogueText;

    private bool canStartConvo = false;
    private bool convoStarted = false;

    private Rigidbody2D myRigidbody2D;

    public bool isWalking;
    private bool stopForConvo = false;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;

    void Start()
    {
        dialogueCanvas.enabled = false;
        sentences = new Queue<string>();

        myRigidbody2D = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    void Update()
    {
        if(canStartConvo && Input.GetKeyDown(KeyCode.T)){
 
            convoStarted = true;
            stopForConvo = true;
            StartDialogue(dialogue);
        }

        if(canStartConvo && convoStarted && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }

        if (isWalking == true && !stopForConvo)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidbody2D.velocity = new Vector2(0, speed);
                    break;
                case 1:
                    myRigidbody2D.velocity = new Vector2(speed, 0);
                    break;

                case 2:
                    myRigidbody2D.velocity = new Vector2(0, -speed);

                    break;

                case 3:
                    myRigidbody2D.velocity = new Vector2(-speed, 0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {

            waitCounter -= Time.deltaTime;
            myRigidbody2D.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }


    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }




    void OnTriggerStay2D(Collider2D other)
    {
        EnableDialogue();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        EndDialogue();
    }

    private void EnableDialogue()
    {
        dialogueCanvas.enabled = true;

        canStartConvo = true;
    }

    private void DisableDialogue()
    {
        dialogueCanvas.enabled = false;
        stopForConvo = false;
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void EndDialogue()
    {
        canStartConvo = false;
        convoStarted = false;
        DisableDialogue();
        dialogueText.text = "Press \"t\" to talk";
    }

}
