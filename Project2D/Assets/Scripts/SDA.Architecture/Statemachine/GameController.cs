using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Architecture{
    public class GameController : MonoBehaviour
    {
        private MenuState menuState;
        private BaseState currentState;
        void Start()
        {
            menuState = new MenuState();
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