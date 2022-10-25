using UnityEngine;
using UnityEngine.Events;

namespace SortCubes
{
    [CreateAssetMenu(fileName = "GameStateMachine", menuName = "Create GameStateMachine", order = 0)]

    public class GameStateMachine : ScriptableObject 
    {
        [SerializeField] private GameState _gameState;
        public UnityEvent OnChangeState;

        public GameState GameState
        {
            get { return _gameState; }
            set 
            {
                if (_gameState == value)
                    return;
                _gameState=value;
                OnChangeState.Invoke();
            }
        }

    }
}
