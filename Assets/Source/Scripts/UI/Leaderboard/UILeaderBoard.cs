
using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class UILeaderBoard : MonoBehaviour
    {
        [SerializeField] private UIPlayerResult _playerResultPrefab;
        [SerializeField] private Transform _content;

        public void ShowWith(IReadOnlyList<LeaderBoardRecord> records)
        {
            foreach (var record in records)
            {
                var newRecord = Instantiate(_playerResultPrefab, _content);
                newRecord.Initialize(record.OrderNumber, record.Name, record.Score);
            }
        }
    }
}
