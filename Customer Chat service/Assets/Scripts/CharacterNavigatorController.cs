using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigatorController : MonoBehaviour
{

    private Vector3 destination;
    public bool reachedDestination;
    public float stopDistace;
    public float rotationSpeed;
    public float movementSpeed;



    // Update is called once per frame
    void Update()
    {

        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopDistace)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }
        }

    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }
}
