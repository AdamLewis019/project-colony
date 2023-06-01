using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;


namespace UtilityAI.consideration
{
    [CreateAssetMenu(fileName = "Energy", menuName = "UtilityAI/Considerations/Energy")]
    public class Energy : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(Inventory inventory)
        {
            considerationScore = responseCurve.Evaluate(Mathf.Clamp01(inventory.energy));
            return considerationScore;
            
        }
    }
}
