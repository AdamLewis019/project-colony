using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UtilityAI.Actions
{
    [CreateAssetMenu(fileName = "Mine", menuName = "UtilityAI/Actions/Mine")]
    public class Mine : Action
    {

        public override void Execute(AIController ai)
        {

            ai.Mining(5f); // starts async method for mining an ore, takes in time needed to mine ore, should implement a change in time taken based on size of ore
        }


    }
}
