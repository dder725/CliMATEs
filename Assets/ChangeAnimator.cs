using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimator : MonoBehaviour
{

    Animator animator;

    RuntimeAnimatorController boyAnimator;
    RuntimeAnimatorController girlAnimator;
    private int charID;  


    // Start is called before the first frame update
    void Start()
    {
        //Get the animator object and the character id
        animator = gameObject.GetComponent<Animator>();
        charID = CharacterSelectionManager.GetCharID();


        //Get the girl and boy animators 
        girlAnimator = (RuntimeAnimatorController) Resources.Load("Animation/Player/GirlPlayer/GirlPlayer");
        boyAnimator = (RuntimeAnimatorController)Resources.Load("Animation/Player/BoyPlayer/BoyPlayer");
        RuntimeAnimatorController forestMan = (RuntimeAnimatorController)Resources.Load("Animation/ForestMan/ForestManSprite");


        //animator.runtimeAnimatorController = girlAnimator;

        if (charID == 1)
        {
            animator.runtimeAnimatorController = girlAnimator;

        }
        else if (charID == 2)
        {
            animator.runtimeAnimatorController = boyAnimator;

        }


    }

}
