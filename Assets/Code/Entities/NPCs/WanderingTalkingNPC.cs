using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WanderingTalkingNPC : Entity
{

    [SerializeField]
    public Canvas dialogueCanvas;
    public Animator animator;

    public Dialogue dialogue;

    public Queue<string> sentences;

    public Text dialogueText;

    private bool canStartConvo = false;
    private bool convoStarted = false;
    private bool convoEnded = false;

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



        if (canStartConvo && Input.GetKeyDown(KeyCode.T))
        {

            convoStarted = true;
            stopForConvo = true;
            StartDialogue(dialogue);
        }

        if (canStartConvo && convoStarted && Input.GetKeyDown(KeyCode.Return))
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


        //Updating the animator on the NPCs movements 

        if (animator != null)
        {
            animator.SetFloat("Horizontal", myRigidbody2D.velocity.x); //x movement 
            animator.SetFloat("Vertical", myRigidbody2D.velocity.y); //y movement
            animator.SetFloat("Speed", myRigidbody2D.velocity.sqrMagnitude);

        }



    }

    public bool ConversationFinished()
    {
        return convoEnded;
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.name.Equals("Player"))
        {
            ChooseDirection();
        } else {
            if (this.entityName.Equals("ForestMan"))
            {
                Debug.LogError("COllided with a forestman");
                AchievementManager.ach02Trigger = true;
            }
        }

    }




    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name.Equals("Player"))
        {
            EnableDialogue();
        }

        else
        {
            //myRigidbody2D.velocity.Set(2, -2);

            //ChooseDirection();

            //Vector2 newVelo = new Vector2(-5, 0);
            //myRigidbody2D.velocity = newVelo;
            //walkCounter = 0;

            //why is none of this changing the character's velocity???
            //myRigidbody2D.velocity = new Vector2(-5, 0);
        }

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
            convoEnded = true;
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
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
        //dialogueText.text = "Press \"t\" to talk";
    }

}
