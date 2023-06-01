using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{ 
    
    public abstract class Action : ScriptableObject
    {
        public Consideration[] considerations;
        public AIController ai;
        public string Name;

        private float ActionScore;
        public float actionScore
        {
            get { return ActionScore; }
            set
            {
                this.ActionScore = Mathf.Clamp01(value); // clamps scores between 0 and 1 to normalise values to be compared
            }
        }
        
        public virtual void awake()
        {
            actionScore = 0;
        }

        public abstract void Execute(AIController aIController);
    }
}