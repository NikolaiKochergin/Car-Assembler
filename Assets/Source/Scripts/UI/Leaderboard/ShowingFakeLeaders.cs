using System.Collections.Generic;
using UnityEngine;

namespace CarAssembler
{
    public class ShowingFakeLeaders : MonoBehaviour
    {
        [SerializeField] private UILeaderBoard _leaderBoard;

        private readonly List<LeaderBoardRecord> _records = new();

        private void Awake()
        {
            _records.Add(new LeaderBoardRecord(1, "Vasya", 1200));
            _records.Add(new LeaderBoardRecord(2, "Petya", 1003));
            _records.Add(new LeaderBoardRecord(3, "Misha", 995));
            _records.Add(new LeaderBoardRecord(4, "Vova", 845));
            _records.Add(new LeaderBoardRecord(5, "Katya", 721));
            _records.Add(new LeaderBoardRecord(6, "Sasha", 666));
            _records.Add(new LeaderBoardRecord(7, "Lena", 568));
        }

        private void Start()
        {
            _leaderBoard.ShowWith(_records);
            Debug.Log("Удалить после добавления настоящих результатов.");
        }
    }
}