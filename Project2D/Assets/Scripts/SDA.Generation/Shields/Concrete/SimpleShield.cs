using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SDA.Generation{
    public class SimpleShield : BaseShield
    {
        private float currentNormalizedTime;
        private float duration;
        private float startTime;
        private Vector3 startAngle;
        private Vector3 endAngle;

        private int currentStep; 
        public override void Rotate(){

            currentNormalizedTime = (Time.time -startTime)/duration;
            if(currentNormalizedTime >= 1f){
                currentStep++;
                if(currentStep == steps.Length){
                    currentStep = 0;
                }
                GetNextStep();
                startTime = Time.time;
                
                var currentStepData = steps[currentStep];
                
                startTime = Time.time;
                duration = currentStepData.time;
                currentNormalizedTime = 0f;
                startAngle = transform.rotation.eulerAngles;
                endAngle = startAngle +Vector3.forward*currentStepData.angle;
                
            }
            Debug.Log(startAngle);
            var  finalAngle = Vector3.Slerp(startAngle, endAngle, currentNormalizedTime);
            Debug.Log(finalAngle);
            transform.rotation = Quaternion.Euler(finalAngle);
        }
        public override void Initialize(){
            currentStep = 0;
            var currentStepData = steps[currentStep];
            startTime = Time.time;
            duration = currentStepData.time;
            currentNormalizedTime = 0f;
            startAngle = transform.rotation.eulerAngles;
            endAngle = startAngle + Vector3.forward*currentStepData.angle;

        }
        public void GetNextStep(){

        }
    }
}
