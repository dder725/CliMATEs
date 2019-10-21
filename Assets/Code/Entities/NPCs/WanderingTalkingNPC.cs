using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WanderingTalkingNPC : Entity
{
    public enum Gender { Male, Female, Penguin };

    [SerializeField]
    public Canvas dialogueCanvas;
    public Animator animator;

    public Dialogue dialogue;

    private AudioClip[] dialogueSounds;
    private AudioSource dialogueSound;
    private AudioClip dialogueClip;

    public Queue<string> sentences;
    string sentence = "";

    public Text dialogueText;

    public static GameObject player;
    public Gender gender;
    private bool canStartConvo = false;
    private bool convoStarted = false;
    private bool convoEnded = false;
    public bool canTalk = true;

    private Rigidbody2D myRigidbody2D;

    public bool isWalking;
    private bool stopForConvo = false;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;
    private Coroutine c = null;

    void Start()
    {
        dialogueCanvas.enabled = false;
        sentences = new Queue<string>();

        myRigidbody2D = GetComponent<Rigidbody2D>();

        //Set up the sound for dialogue voiceover
        if (GetComponent<AudioSource>() == null)
        {
            dialogueSound = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            dialogueSound = GetComponent<AudioSource>();
        }
        dialogueSound.volume = 0.5f;

        // Select the soundbyte with respect to gender of an entity
        if (gender.Equals(Gender.Male))
        {
            //   dialogueSound.clip = Resources.Load<AudioClip>("Sounds/maleGibberish");
            dialogueSounds = Resources.LoadAll<AudioClip>("Sounds/maleSounds");
            dialogueSound.pitch = 0.7f;

        }
        else if (gender.Equals(Gender.Penguin))
        {
            canStartConvo = false;
        }
        else
        {
            //    dialogueSound.clip = Resources.Load<AudioClip>("Sounds/femaleGibberish");
            dialogueSounds = Resources.LoadAll<AudioClip>("Sounds/femaleSounds");
            dialogueSound.pitch = 1.3f;
        }
        dialogueSound.clip = dialogueSounds[0];

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

    }

    void Update()
    {

        // Select random sound


        if (canStartConvo && Input.GetKeyDown(KeyCode.T))
        {

            convoStarted = true;
            stopForConvo = true;
            //Freezing player during conversations so user doesn't miss sentences
            player = GameObject.Find("Player");
            if (!gender.Equals(Gender.Penguin))
            {
                Player.freezePlayer();
            }
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
        }
        else
        {
            if (this.entityName.Equals("ForestMan"))
            {
                AchievementManager.ach02Trigger = true;
            }
            EnableDialogue();
        }

    }




    void OnTriggerStay2D(Collider2D other)
    {
        // if (other.name.Equals("Player") && canTalk)
        // {
        //     EnableDialogue();
        // }


        //Making the NPC stop if they hit something
        //if (!other.name.Equals("Player"))
        //{
        //    Debug.Log("Collision");

        //    //myRigidbody2D.velocity = new Vector2(0, 0);
        //    //animator.SetFloat("Speed", 0); 
        //    isWalking = false;
        //}


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name.Equals("Player"))
        {
            EndDialogue();
        }
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
        // Select a random soundbyte
        int index = Random.Range(0, dialogueSounds.Length);
        dialogueSound.clip = dialogueSounds[index];
        dialogueSound.Play();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }



    public void DisplayNextSentence()
    {

        //End conversation when Count=1, so each NPC has an extra hint sentence for if they are reapproached
        if (sentences.Count == 1)
        {
            dialogueText.text = sentence;
            convoEnded = true;
            EndDialogue();
            SetHintMessage();
            return;
        }

        sentence = sentences.Dequeue();

        //Select a random soundbyte
        int index = Random.Range(0, dialogueSounds.Length);
        dialogueSound.clip = dialogueSounds[index];

        dialogueSound.Play();
        //StopAllCoroutines();
        if (c != null)
        {
            StopCoroutine(c);
        }
        c = StartCoroutine(TypeSentence(sentence));

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
        // StopAllCoroutines();
        if (c != null)
        {
            StopCoroutine(c);
        }
        //Player can walk again when conversation is finished
        player = GameObject.Find("Player");
        Player.unfreezePlayer();

    }

    public void SetHintMessage()
    {
        sentence = sentences.Dequeue();
        StartCoroutine(HintMessage(sentence));
    }

    IEnumerator HintMessage(string sentence)
    {
        //We don't want hint message to display instantly
        yield return new WaitForSeconds(10);
        dialogueText.text = sentence;
        Debug.Log("Hint is set");
        dialogueCanvas.enabled = true;
    }


}
