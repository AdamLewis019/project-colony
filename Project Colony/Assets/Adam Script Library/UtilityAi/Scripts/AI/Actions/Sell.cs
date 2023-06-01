using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Sell", menuName = "UtilityAI/Actions/Sell")]
    public class Sell : Action
    {

        public override void Execute(AIController ai)
        {
            ai.Selling(1f); // 
        }


    }
}

