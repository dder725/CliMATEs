using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimator : MonoBehaviour
{

    Animator animator;

    RuntimeAnimatorController boyAnimator;
    RuntimeAnimatorController girlAnimator;
    bool isBoy = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();


        girlAnimator = (RuntimeAnimatorController) Resources.Load("Animation/Player/GirlPlayer/GirlPlayer");
        boyAnimator = (RuntimeAnimatorController)Resources.Load("Animation/Player/BoyPlayer/BoyPlayer");
        RuntimeAnimatorController forestMan = (RuntimeAnimatorController)Resources.Load("Animation/ForestMan/ForestManSprite");


        if (isBoy)
        {
            animator.runtimeAnimatorController = boyAnimator;
        }
        else
        {
            animator.runtimeAnimatorController = girlAnimator;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
