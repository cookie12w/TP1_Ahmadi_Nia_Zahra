using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermidiairesZone : MonoBehaviour
{
    bool Allowed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Allowed == false)
            {
                Allowed = true;
                PointManager.Point += 1;
            }
        }
    }
}
