using UnityEngine;

namespace CarAssembler
{
    public static class Storage
    {
        private const string Data = nameof(Data);

        private static Data _data;

        public static Data Load()
        {
            _data ??= new Data();

            if (PlayerPrefs.HasKey(Data))
            {
                var serialized = PlayerPrefs.GetString(Data);
                _data = JsonUtility.FromJson<Data>(serialized);
            }
            else
            {
                Save(new Data());
            }

            return _data;
        }

        public static void Save(Data data)
        {
            _data = data;
            var serialized = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(Data, serialized);
        }
    }
}