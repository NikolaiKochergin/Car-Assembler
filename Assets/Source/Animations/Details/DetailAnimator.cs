using UnityEngine;

public class DetailAnimator : MonoBehaviour
{
    private const string Show = nameof(Show);
    private const string Hide = nameof(Hide);
    
    [SerializeField] private Animator _detailAnimator;

    public void PlayShow()
    {
        _detailAnimator.SetTrigger(Show);
        ResetTriggers();
    }

    public void PlayHide()
    {
        _detailAnimator.SetTrigger(Hide);
        ResetTriggers();
    }

    private void ResetTriggers()
    {
        _detailAnimator.ResetTrigger(Show);
        _detailAnimator.ResetTrigger(Hide);
    }
}