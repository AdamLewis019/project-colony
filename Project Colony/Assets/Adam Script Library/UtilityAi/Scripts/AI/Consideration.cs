using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UtilityAI
{
    public abstract class Consideration : ScriptableObject
    {
        public string Name;

        private float ConsiderationScore;

        public float considerationScore
        {
            get { return ConsiderationScore; }
            set
            {
                this.ConsiderationScore = Mathf.Clamp01(value); // clamps scores between 0 and 1 to normalise values to be compared
            }
        }

        public virtual void Awake()
        {
            considerationScore = 0;
        }

        public abstract float ScoreConsideration(Inventory inventory);
    }
}
