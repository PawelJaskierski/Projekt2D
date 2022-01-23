using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SDA.UI;
using SDA.Input;
using SDA.Generation;
using SDA.CoreGameplay;

namespace SDA.Architecture{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private GameView gameView;
        [SerializeField] private MenuView menuView;

        [SerializeField] private LevelGenerator levelGenerator;
        private InputSystem inputSystem;

        private ShieldMovementController shieldMovementController;

        private MenuState menuState;
        private GameState gameState;

        private BaseState currentState;

        private UnityAction transitionToGameState;
        void Start()
        {
            inputSystem = new InputSystem();
            transitionToGameState = () => ChangeState(gameState);
            shieldMovementController = new ShieldMovementController();
            menuState = new MenuState(transitionToGameState,menuView);
            gameState = new GameState(gameView, inputSystem, levelGenerator, shieldMovementController);
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