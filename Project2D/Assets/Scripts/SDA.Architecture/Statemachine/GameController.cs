using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SDA.UI;
using SDA.Input;

namespace SDA.Architecture{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private MenuView menuView;
        private InputSystem inputSystem;

        private MenuState menuState;
        private GameState gameState;

        private BaseState currentState;

        private UnityAction transitionToGameState;
        void Start()
        {
            inputSystem = new InputSystem();
            transitionToGameState = () => ChangeState(gameState);
            menuState = new MenuState(transitionToGameState,menuView);
            gameState = new GameState(gameView, inputSystem);
            ChangeState(menuState);
        }

        // Update is called once per frame
        void Update(){
            currentState?.UpdateState();
        }
        private void OnDestroy(){
            
        }  

        private void ChangeState(BaseState newState){
            currentState?.DestroyState();
            currentState = newState;
            currentState?.InitState();
        }
    }
}