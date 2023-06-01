using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;

    void Update()
    {
        // Simple movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mine(PlayerStats.MineSpeedMultiplier);
        }


    }


    public void mine(float speed)
    {
        // Shoots a ray from the camera to the world and stores the location of where it hit
        Ray hit;
        hit = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        if (Physics.Raycast(hit, out RaycastHit hitInfo))
        {
            Debug.Log(hitInfo);
            if (hitInfo.collider.tag == "Wood")
            {
                (hitInfo.transform.gameObject.GetComponent<BreakableObject>()).mineThis();
                
            }
        }
    }


}
