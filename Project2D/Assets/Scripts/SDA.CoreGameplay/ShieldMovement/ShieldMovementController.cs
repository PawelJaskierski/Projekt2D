using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.Generation;
namespace SDA.CoreGameplay{
    public class ShieldMovementController{

        private BaseShield currentlyActiveShield;

        public void InitializeShield(BaseShield newShield){
            //destroy old shield

            currentlyActiveShield = newShield;
            currentlyActiveShield?.Initialize();
        }

        public void UpdateSystem(){
            currentlyActiveShield?.Rotate();
        }

    }
}