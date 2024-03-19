using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public GameObject bluePortalPrefab;
    public GameObject orangePortalPrefab;
    public Transform gunTip; // Position where the portal will be created

    private GameObject currentPortalPrefab;
    private GameObject bluePortal;
    private GameObject orangePortal;

    void Start()
    {
        // Start with blue portal type
        currentPortalPrefab = bluePortalPrefab;
    }

    void Update()
    {
        // Shoot blue portal on right click
        if (Input.GetKeyDown(KeyCode.R)) // Right mouse button
        {
            currentPortalPrefab = bluePortalPrefab;
            ShootPortal();
        }

        // Shoot orange portal on left click
        if (Input.GetKeyDown(KeyCode.E)) // Left mouse button
        {
            currentPortalPrefab = orangePortalPrefab;
            ShootPortal();
        }
    }

    void ShootPortal()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit))
        {
            // Check if there's already an active portal of the current type
            if ((currentPortalPrefab == bluePortalPrefab && bluePortal != null) ||
                (currentPortalPrefab == orangePortalPrefab && orangePortal != null))
            {
                Destroy(currentPortalPrefab == bluePortalPrefab ? bluePortal : orangePortal);
            }

            // Calculate the portal position based on the hit point and surface normal
            Vector3 portalPosition = hit.point;
            Quaternion portalRotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);

            // Spawn a new portal at the calculated position and rotation
            GameObject newPortal = Instantiate(currentPortalPrefab, portalPosition, portalRotation);

            // Assign the new portal to the corresponding variable
            if (currentPortalPrefab == bluePortalPrefab)
            {
                bluePortal = newPortal;
            }
            else
            {
                orangePortal = newPortal;
            }
        }
    }
}
