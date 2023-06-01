using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;


namespace UtilityAI.consideration
{
    [CreateAssetMenu(fileName = "Hunger", menuName = "UtilityAI/Considerations/Hunger")]
    public class Hunger : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(Inventory inventory)
        {
            considerationScore = responseCurve.Evaluate(Mathf.Clamp01(inventory.hunger));
            return considerationScore;
            
        }
    }
}