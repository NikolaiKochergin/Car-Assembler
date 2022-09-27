using System.Collections.Generic;
using UnityEngine;

public class CarSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cars;
    [SerializeField] private DataLesson _data;
    
    private int _carIndex = 0;

    private void Start()
    {
        _carIndex = _data.GetCarIndex();
        _cars[_carIndex].SetActive(true);
    }

    public void ChangeCarIndex(int summand)
    {
        if(_carIndex + summand < _cars.Count && _carIndex + summand >= 0)
        {
            _cars[_carIndex].SetActive(false);
            _carIndex += summand;
            _cars[_carIndex].SetActive(true);
            _data.SetCarIndex(_carIndex);
        }
    }
}
