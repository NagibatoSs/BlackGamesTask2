using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SortCubes
{
    public class GameStateMachineProvider : MonoBehaviour
    {
        [SerializeField] GameStateMachine _gameStateMachine;
        [SerializeField] private string _stateName;
        [SerializeField] private Animator _animator;

        public GameStateMachine GameStateMachine => _gameStateMachine;

        public UnityEvent OnChangeState;
        
        private void OnEnable() 
        {
            try
            {
                _animator=gameObject.GetComponent<Animator>();
            }
            catch {};
            _gameStateMachine.OnChangeState.AddListener(OnChangeStateDelegate);
        }

        private void OnDisable() 
        {
            _gameStateMachine.OnChangeState.RemoveListener(OnChangeStateDelegate);
        }

        private void OnChangeStateDelegate()
        {
            if (_stateName==GameStateMachine.GameState.ToString())
                OnChangeState.Invoke();
        }

        
    }
}
