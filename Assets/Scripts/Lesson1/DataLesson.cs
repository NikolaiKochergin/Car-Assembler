using System;
using UnityEngine;

public class DataLesson : MonoBehaviour
{
    private const string _dataKeyName = "SaveName";
    private SaveOptionsLesson _options = new SaveOptionsLesson();

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(_options);
        PlayerPrefs.SetString(_dataKeyName, json);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_dataKeyName) == false)
        {
            _options = new SaveOptionsLesson();
            Save();
        }
        else
            _options = JsonUtility.FromJson<SaveOptionsLesson>(PlayerPrefs.GetString(_dataKeyName));
    }

    public int GetCarIndex()
    {
        return _options.CarIndex;
    }

    public void SetCarIndex(int index)
    {
        _options.CarIndex = index;
    }

    public void SetValue(int value)
    {
        _options.Value = value;
    }
}

[Serializable]
public class SaveOptionsLesson
{
    public int CarIndex = 0;
    public int Value;
}

