using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SDA.Generation{
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField]
        private Transform shieldPos;
        [SerializeField]
        private Transform knifePos;

        [SerializeField]
        private BaseShield shieldPrefab;

        [SerializeField]
        private Transform shieldRoot;
        [SerializeField]
        private BaseKnife knifePrefab;
        [SerializeField] 
        private Transform knifeRoot;
        public void SpawnShield(){
            var shiledObj = Instantiate(shieldPrefab,shieldPos.position,shieldPos.rotation);
            shiledObj.transform.SetParent(shieldRoot);
        }

        public void SpawnKnife(){
            var knifeObj = Instantiate(knifePrefab,knifePos.position,knifePos.rotation);
            knifeObj.transform.SetParent(knifeRoot);
        }
    }
}
