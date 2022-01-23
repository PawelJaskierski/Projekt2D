using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] steps;

        public abstract void Rotate();
        public abstract void Initialize();
    }
}