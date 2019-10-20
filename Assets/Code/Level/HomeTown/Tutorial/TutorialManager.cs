using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text nameText;
    public Text tutorialText;

    public Animator animator;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Awake()
    {
        sentences = new Queue<string>();
    }

    public void StartTutorial(Tutorial tutorial)
    {
        animator.SetBool("isOpen", true);

        Debug.Log(tutorial.sentences[0]);

        nameText.text = tutorial.name;

        sentences.Clear();

        foreach (string sentence in tutorial.sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log(sentence.Length);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndTutorial();
            return;
        }

        string sentence = sentences.Dequeue();
        tutorialText.text = sentence;
    }

    void EndTutorial()
    {
        Debug.Log("End of conversation");
        animator.SetBool("isOpen", false);
    }
}
 