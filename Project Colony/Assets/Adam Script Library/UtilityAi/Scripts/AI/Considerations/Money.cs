using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;


namespace UtilityAI.consideration
{
    [CreateAssetMenu(fileName = "Money", menuName = "UtilityAI/Considerations/Money")]
    public class Money : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(Inventory inventory)
        { 
            considerationScore = responseCurve.Evaluate(Mathf.Clamp01(inventory.money));
            return considerationScore;
            
        }
    }
}
