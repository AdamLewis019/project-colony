using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UtilityAI
{
    public class AIBrain : MonoBehaviour
    {
        public Action bestAction { get; set; }
        private AIController ai;
        private Inventory inventory;
        public bool chosenAction;

        void Start()
        {
            ai = GetComponent<AIController>();
            inventory = GetComponent<Inventory>();
            ChooseBestAction(ai.actionsAvailable);
        }

        public void ChooseBestAction(Action[] actionsAvailable)  // this decides which action is the best one to do by looking at each action score and returning the highest scoring action
        {
            float score = 0f;
            int nextBestActionIndex = 0;
            for (int i = 0; i < actionsAvailable.Length; i++) // goes through list and grabs the score of each action
            {
               if(ScoreAction(actionsAvailable[i]) > score) // checks if the current action is higher scoring than the last and updates the next best action if it is
                {
                   nextBestActionIndex = i;
                   score = actionsAvailable[i].actionScore;
                }

            }
            bestAction = actionsAvailable[nextBestActionIndex]; // sets the best action
            chosenAction = true;
        }

        public float ScoreAction(Action action) 
        {
            float scoreTotal = 0f;
            for(int i =0; i < action.considerations.Length; i++) //looks at all of the consideration scores of an action
            {
                float considerationScore = action.considerations[i].ScoreConsideration(inventory);
                scoreTotal += considerationScore; // adds all of the scores together

                if(scoreTotal == 0) // no need to find the average if the total score is 0
                {
                    action.actionScore = 0;
                    return action.actionScore;
                }
            }

            float averageScore = scoreTotal / action.considerations.Length;

            return averageScore; // returns an average consideration score 
        }
    }
}