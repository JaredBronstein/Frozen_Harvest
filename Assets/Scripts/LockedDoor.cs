using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : Door
{
    private Animator animator;

    /// <summary>
    /// Using a constructor here to initialize DisplayText in the editor
    /// </summary>
    public LockedDoor()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        base.InteractWith();
        animator.SetBool("shouldOpen", true);
        displayText = string.Empty;
        animator.SetBool("shouldOpen", false);
    }
}
