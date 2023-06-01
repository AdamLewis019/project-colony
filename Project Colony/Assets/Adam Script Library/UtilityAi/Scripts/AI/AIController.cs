using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace UtilityAI
{
    public class AIController : MonoBehaviour
    {

        public string whatAmIDoing = "nothing";
        public AIBrain aiBrain { get; set; }

        public Action[] actionsAvailable;

        private NavMeshAgent navmesh;

        private Inventory inventory;

        public bool pendingDestination = false;

        public float timesMined;
        public float timesSlept;
        public float timesAte;
        public float timesSold;

        public TMP_Text doingText;

        private void Start()
        {
            aiBrain = GetComponent<AIBrain>();
            navmesh = GetComponent<NavMeshAgent>();
            inventory = GetComponent<Inventory>();
            EnergyAndHunger(5);
        }

        private void Update()
        {
            doingText.text = whatAmIDoing;
            doingText.transform.rotation = Quaternion.Euler(0, -60, 0);
            if (aiBrain.chosenAction)
            {
                aiBrain.chosenAction = false;
                aiBrain.bestAction.Execute(this);
            }

            if (!navmesh.pathPending)
            {
                if (navmesh.remainingDistance <= navmesh.stoppingDistance)
                {
                    
                    if (!navmesh.hasPath || navmesh.velocity.sqrMagnitude == 0f)
                    {
                        pendingDestination = false;
                    }
                }
            }
        }

        public async void EnergyAndHunger(float frequency)
        {
            var end = Time.time + frequency;
            while (Time.time < end)
            {
                await Task.Yield();
            }
            inventory.energy --;
            inventory.hunger ++;
            EnergyAndHunger(frequency);
        }
        public async void Eating(float duration)
        {
            timesAte++;
            whatAmIDoing = "Eating";
            GameObject closestFood = FindClosestThing("Food");
            
            navmesh.destination = closestFood.transform.position;
            pendingDestination = true;
            var end = Time.time + duration;
            while(Time.time < end)
            {
                await Task.Yield();
            }

            while (pendingDestination)
            {
                await Task.Yield();
            }
            Debug.Log("Ive Eaten!");
            if (inventory.money != 0)
            {
                inventory.hunger -= 1;
                inventory.money -= 10;
            }
            whatAmIDoing = "nothing";

            aiBrain.ChooseBestAction(actionsAvailable);
        }


        public async void Sleeping(float duration)
        {
            timesSlept++;
            whatAmIDoing = "sleeping";
            GameObject bed = FindClosestThing("bed");
            navmesh.destination = bed.transform.position;
            pendingDestination = true;
            var end = Time.time + duration;
            while (Time.time < end)
            {

                await Task.Yield();
            }

            while (pendingDestination)
            {
                await Task.Yield();
            }

            whatAmIDoing = "nothing";
            inventory.energy += 50;
            Debug.Log("Slept!");


            aiBrain.ChooseBestAction(actionsAvailable); // choses best action once finished with this action
        }

        public async void Mining(float duration)
        {
            timesMined++;
            whatAmIDoing = "mining";
            GameObject ore = GameObject.FindGameObjectWithTag("Ore");
            ore.tag = "Untagged";
            navmesh.destination = ore.transform.position;
            pendingDestination = true;
            var end = Time.time + duration;
            
            while (Time.time < end)
            {
                await Task.Yield();
            }

            while (pendingDestination)
            {
                await Task.Yield();
            }
            Debug.Log("Mined");
            whatAmIDoing = "nothing";
            inventory.oreCount++;
            aiBrain.ChooseBestAction(actionsAvailable);
        }

        public async void Selling(float duration)
        {
            timesSold ++;
            whatAmIDoing = "selling";
            GameObject sellPoint = FindClosestThing("SellPoint");
            navmesh.destination = sellPoint.transform.position;
            pendingDestination = true;
            var end = Time.time + duration;
            while (Time.time < end)
            {
                await Task.Yield();
            }
           

            while (pendingDestination)
            {
                await Task.Yield();
            }

            inventory.oreCount--;
            inventory.money += 5;

            Debug.Log("I sold an ore!");
            whatAmIDoing = "nothing";
            aiBrain.ChooseBestAction(actionsAvailable);
        }

        public GameObject FindClosestThing(string thing) //https://docs.unity3d.com/ScriptReference/GameObject.FindGameObjectsWithTag.html
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(thing);
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            Debug.Log(closest.ToString() + "is the closest thing");
            return closest;
        }
    }
}