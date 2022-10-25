using UnityEngine;

namespace SortCubes
{
    public class GameStateChanger : MonoBehaviour
    {
        [SerializeField] GameStateMachine _gameStateMachine;
        [SerializeField] GameState _gameState;
        [SerializeField] Animator _animator;

        public GameStateMachine GameStateMachine => _gameStateMachine;

        public void ChangeState()
        {
            if (_animator!=null)
            _animator.SetTrigger("Close");
            GameStateMachine.GameState = _gameState;
        }

    }
}
