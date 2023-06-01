using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UtilityAI;

namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Eat", menuName = "UtilityAI/Actions/Eat")]
    public class Eat : Action
    {

        public override void Execute(AIController ai)
        {
            ai.Eating(5f); // starts an async method in the aicontroller, taking in the time it takes to eat 
        }


    }
}
