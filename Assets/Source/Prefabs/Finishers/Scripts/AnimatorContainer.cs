using UnityEngine;

public class AnimatorContainer : MonoBehaviour
{
    private const string DefaultDirtRace = nameof(DefaultDirtRace);
    private const string DirtRace = nameof(DirtRace);
    private const string Idle = nameof(Idle);
    private const string Lowride = nameof(Lowride);
    
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        Disable();
    }

    public void ShowDefaultDirtRace()
    {
        _animator.SetTrigger(DefaultDirtRace);
    }
    
    public void ShowDirtRace()
    {
        _animator.SetTrigger(DirtRace);
    }

    public void ShowIdle()
    {
        _animator.SetTrigger(Idle);
    }

    public void ShowLowride()
    {
        _animator.SetTrigger(Lowride);
    }
    
    public void Enable()
    {
        _animator.enabled = true;
    }
    
    public void Disable()
    {
        _animator.enabled = false;
    }
    

    private void ResetTriggers()
    {
        _animator.ResetTrigger(DefaultDirtRace);
        _animator.ResetTrigger(DirtRace);
    }
}
