using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Sleep", menuName = "UtilityAI/Actions/Sleep")]
    public class Sleep : Action
    {

        public override void Execute(AIController ai)
        {
            ai.Sleeping(5f); // starts an async method taking in the time it takes to sleep/ time needed?
        }

    }
}
