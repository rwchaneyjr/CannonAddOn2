//UNITY CANNON TARGETER

using UnityEngine;

public class CannonTargeter : MonoBehaviour
{
    public Transform muzzle;
    public float rotationSpeed = 9f;
    public float range = 100f;

    void Update()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("target");
        Transform nearestTarget = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float dist = Vector3.Distance(transform.position,target.transform.position);
            if (dist < minDist && dist < range)
            {
                minDist = dist;
                nearestTarget = target.transform;
            }
        }

        if (nearestTarget != null)
        {
            Vector3 direction = nearestTarget.position - transform.position;
            direction.y = 0; // Keep rotation horizontal
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}