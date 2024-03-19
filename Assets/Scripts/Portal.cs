using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    /* private Portal otherPortal; // Reference to the other portal
     private bool isTeleporting = false; // Flag to prevent multiple teleportations in a single frame

     void Start()
     {
         FindOtherPortal();
     }

     private void OnTriggerEnter(Collider other)
     {
         if (!isTeleporting)
         {
             isTeleporting = true;

             Vector3 newPos = otherPortal.transform.position + otherPortal.transform.forward * 2; // Adjust 2 with your desired teleportation distance
             Quaternion newRot = Quaternion.LookRotation(otherPortal.transform.forward);

             other.transform.position = newPos;
             other.transform.rotation = newRot;

             Rigidbody rb = other.GetComponent<Rigidbody>();
             if (rb != null)
             {
                 Vector3 relativeVelocity = otherPortal.transform.InverseTransformDirection(rb.velocity);
                 relativeVelocity *= -1f;
                 rb.velocity = otherPortal.transform.TransformDirection(relativeVelocity);
             }

             Invoke("ResetTeleportingFlag", 0.1f);
         }
     }

     private void ResetTeleportingFlag()
     {
         isTeleporting = false;
     }

     private void FindOtherPortal()
     {
         string thisPortalTag = gameObject.tag;
         string otherPortalTag = thisPortalTag == "BluePortal" ? "YellowPortal" : "BluePortal";

         GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(otherPortalTag);
         if (objectsWithTag.Length > 0)
         {
             otherPortal = objectsWithTag[0].GetComponent<Portal>();
         }
         else
         {
             Debug.LogError("No GameObject with tag " + otherPortalTag + " found for the other portal.");
         }
     }*/

    public Portal otherPortal;
    private bool isTeleporting = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isTeleporting)
        {
            isTeleporting = true;

            Vector3 newPos = otherPortal.transform.position + otherPortal.transform.forward * 2;
            Quaternion newRot = Quaternion.LookRotation(otherPortal.transform.forward);


            other.transform.position = newPos;
            other.transform.rotation = newRot;


            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 relativeVelocity = otherPortal.transform.InverseTransformDirection(rb.velocity);
                relativeVelocity *= -1f;
                rb.velocity = otherPortal.transform.TransformDirection(relativeVelocity);
            }


            Invoke("ResetTeleportingFlag", 0.1f);
        }
    }

    // Method to reset the teleporting flag
    private void ResetTeleportingFlag()
    {
        isTeleporting = false;
    }
}

