using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CarAssembler
{
    public class YokeMassage : MonoBehaviour
    {
        [SerializeField] private UIYoke _yoke;
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _excelentText;
        [SerializeField] private TMP_Text _badlyText;
        [SerializeField] private AnimationCurve _messageShowCurve;
        [SerializeField][Min(0)] private float _duration;

        private void OnEnable()
        {
            _button.onClick.AddListener(ShowValue);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowValue);
        }

        private void ShowValue()
        {
            if (_yoke.InputValue >= 1)
            {
                StartCoroutine(MessageShowing(_excelentText));
            }
            else
            {
                StartCoroutine(MessageShowing(_badlyText));
            }
        }

        private IEnumerator MessageShowing(TMP_Text text)
        {
            for (float i = 1; i > 0; i -= Time.deltaTime/_duration)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, _messageShowCurve.Evaluate(i));

                yield return null;
            }
            
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }
    }
}