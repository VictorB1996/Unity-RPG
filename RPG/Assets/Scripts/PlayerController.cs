using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    PlayerMotor playerMotor;

    public LayerMask movementMask;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        playerMotor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Move player to what we hit
                playerMotor.MoveToPoint(hit.point);

                //Stop focusing any objects
            }
        }
    }
}
