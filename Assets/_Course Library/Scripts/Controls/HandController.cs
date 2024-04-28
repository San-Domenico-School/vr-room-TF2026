using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*****
 * This script should be attached to the HandModel.  It is used to take input from the 
 * users hand controllers and pass it using an Input Action to the Hand Model animation.
 * 
 * Bruce Gustin 
 * Apr 28, 2024
*/

public class HandController : MonoBehaviour
{
    [SerializeField] private InputActionReference gripInput;
    [SerializeField] private InputActionReference triggerInput;

    private Animator animator;                                    

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(animator != null)
        {
            RespondToUserInput();
        }
    }

    private void RespondToUserInput()
    {
        float grip = gripInput.action.ReadValue<float>();
        float trigger = triggerInput.action.ReadValue<float>();

        animator.SetFloat("Grip", grip);
        animator.SetFloat("Trigger", trigger);
    }
}
