using UnityEngine;
using UnityEngine.Events;

namespace SortCubes
{
   // [CreateAssetMenu(fileName = "GameStateMachine", menuName = "BlackGamesTask2/GameStateMachine", order = 0)]

    public class GameStateMachine : ScriptableObject 
    {
        [SerializeField] private GameState _gameState;
        public UnityEvent OnChangeState;

        public GameState GameState
        {
            get { return _gameState; }
            set 
            {
                _gameState=value;
                OnChangeState.Invoke();
            }
        }

    }
}
