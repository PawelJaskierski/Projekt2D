using System.Collections;
using System.Collections.Generic;
using SDA.Input;
using UnityEngine;
using SDA.UI;
using SDA.Generation;
using SDA.CoreGameplay;

namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;

        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        

        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator, ShieldMovementController shieldMovementController)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
        }

        public override void InitState()
        {
            if(gameView!=null)
                gameView.ShowView();
            BaseShield startShield = levelGenerator.SpawnShield();
            levelGenerator.SpawnKnife();
            inputSystem.AddListener(PrintDebug);
            shieldMovementController.InitializeShield(startShield);
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
            shieldMovementController.UpdateSystem();
        }

        public override void DestroyState()
        {
            if(gameView!=null)
                gameView.HideView();
            
            inputSystem.RemoveAllListeners();
        }

        private void PrintDebug()
        {
            Debug.Log("BUTTON CLICKED");
        }
    }
}
