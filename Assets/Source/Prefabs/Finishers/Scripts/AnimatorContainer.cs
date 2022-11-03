using UnityEngine;

public class AnimatorContainer : MonoBehaviour
{
    private const string DefaultDirtRace = nameof(DefaultDirtRace);
    private const string DirtRace = nameof(DirtRace);
    
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
