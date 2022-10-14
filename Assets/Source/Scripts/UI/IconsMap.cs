using System;
using UnityEngine;

namespace CarAssembler
{
    public class IconsMap : MonoBehaviour
    {
        [SerializeField] private Sprite[] _defaultSprite;
        [SerializeField] private Sprite[] _framesSprites;
        [SerializeField] private Sprite[] _doorsSprites;
        [SerializeField] private Sprite[] _windowsSprites;
        [SerializeField] private Sprite[] _wheelsSprites;
        [SerializeField] private Sprite[] _spoilersSprites;
        [SerializeField] private Sprite[] _enginesSprites;
        [SerializeField] private Sprite[] _tuningSprites;
        [SerializeField] private Sprite[] _bumbersSprites;
        [SerializeField] private int _gradeOffsetInFeatureTypes = 4;

        public Sprite GetIconBy(SlotType slotType, FeatureType featureType)
        {
            var sprite = _defaultSprite[0];

            switch (slotType)
            {
                case SlotType.Empty:
                    break;
                case SlotType.Frame:
                    if (featureType == FeatureType.Empty)
                        sprite = _framesSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _framesSprites.Length - 1);
                        sprite = _framesSprites[index];
                    }
                    break;
                case SlotType.Doors:
                    if (featureType == FeatureType.Empty)
                        sprite = _doorsSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _doorsSprites.Length - 1);
                        sprite = _doorsSprites[index];
                    }
                    break;
                case SlotType.Windows:
                    if (featureType == FeatureType.Empty)
                        sprite = _windowsSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _windowsSprites.Length - 1);
                        sprite = _windowsSprites[index];
                    }
                    break;
                case SlotType.Wheels:
                    if (featureType == FeatureType.Empty)
                        sprite = _wheelsSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _wheelsSprites.Length - 1);
                        sprite = _wheelsSprites[index];
                    }
                    break;
                case SlotType.Spoiler:
                    if (featureType == FeatureType.Empty)
                        sprite = _spoilersSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _spoilersSprites.Length - 1);
                        sprite = _spoilersSprites[index];
                    }
                    break;
                case SlotType.Engine:
                    if (featureType == FeatureType.Empty)
                        sprite = _enginesSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _enginesSprites.Length - 1);
                        sprite = _enginesSprites[index];
                    }
                    break;
                case SlotType.Tuning:
                    if (featureType == FeatureType.Empty)
                        sprite = _tuningSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _tuningSprites.Length - 1);
                        sprite = _tuningSprites[index];
                    }
                    break;
                case SlotType.FrontBumper:
                    if (featureType == FeatureType.Empty)
                        sprite = _bumbersSprites[0];
                    else
                    {
                        var index = Mathf.Clamp((int) featureType - _gradeOffsetInFeatureTypes, 0, _bumbersSprites.Length - 1);
                        sprite = _bumbersSprites[index];
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(slotType), slotType, null);
            }

            if(sprite == null)
                sprite = _defaultSprite[0];

            return sprite;
        }
    }
}