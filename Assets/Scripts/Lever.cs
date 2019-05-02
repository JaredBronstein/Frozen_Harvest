using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractiveObject
{
    [Tooltip("Check true if Up is the correct position for the Lever to be in. Check false if it is down")]
    [SerializeField]
    private bool isUpCorrect;

    private Animator animator;
    private bool isUp_UseProperty = true;

    public bool IsLeverCorrect => IsUp == isUpCorrect;

    private bool IsUp
    {
        get { return isUp_UseProperty;}
        set
        {
            isUp_UseProperty = value;
            animator.SetBool(nameof(IsUp), value);
        }
    }

    public override void InteractWith()
    {
        base.InteractWith();
        IsUp = !IsUp;
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }
}
