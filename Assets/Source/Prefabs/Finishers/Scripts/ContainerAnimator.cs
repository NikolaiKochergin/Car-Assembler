using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    public void Enable()
    {
        _animator.enabled = true;
    }
    
    public void Disable()
    {
        _animator.enabled = false;
    }
}
