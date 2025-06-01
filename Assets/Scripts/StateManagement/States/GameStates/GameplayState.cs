namespace Scripts.StateManagement.States.GameStates
{
    using Fusion;
    using Scripts.Core;
    using Scripts.StateManagement.Core;
    using Scripts.StateManagement.StateManagers;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameplayState : BaseGameState
    {
        private Dictionary<PlayerRef, Vector3> cardPositions;
        private Vector3[] cardSlots = new Vector3[2];

        public GameplayState(GameStateManager stateManager) : base(stateManager)
        {
            stateType = GameStateType.Gameplay;
            sceneName = stateType.ToString();

            cardSlots = Main.instance.data.gameData.cardSlotsPos;
            cardPositions = Main.instance._playerCardPositions;

            MainEventBus.OnAssignCardSlots += AssignCardPositions;
        }

        public void AssignCardPositions(NetworkRunner runner)
        {
            int i = 0;
            foreach (var player in runner.ActivePlayers)
            {
                if (!cardPositions.ContainsKey(player) && i < cardSlots.Length)
                {
                    cardPositions[player] = cardSlots[i];
                    i++;
                }
            }
        }
    }
}
