using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;


namespace UtilityAI.consideration
{
    [CreateAssetMenu(fileName = "CarryWeight", menuName = "UtilityAI/Considerations/CarryWeight")]
    public class CarryWeight : Consideration
    {
        [SerializeField] private AnimationCurve responseCurve;
        public override float ScoreConsideration(Inventory inventory)
        {
            considerationScore = responseCurve.Evaluate(Mathf.Clamp01(inventory.oreCount));
            return considerationScore;

        }
    }
}

