using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorContainer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Disable();
    }

    public void Enable()
    {
        _animator.enabled = true;
    }
    
    public void Disable()
    {
        _animator.enabled = false;
    }
}
