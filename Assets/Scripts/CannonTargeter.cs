//UNITY CANNON TARGETER

using UnityEngine;

public class CannonTargeter : MonoBehaviour
{
    public Transform muzzle;
    public float rotationSpeed = 9f;
    public float range = 100f;

    void Update()
    {
        GameObject[] rats = GameObject.FindGameObjectsWithTag("Rat");
        Transform nearestRat = null;
        float minDist = Mathf.Infinity;

        foreach (GameObject rat in rats)
        {
            float dist = Vector3.Distance(transform.position, rat.transform.position);
            if (dist < minDist && dist < range)
            {
                minDist = dist;
                nearestRat = rat.transform;
            }
        }

        if (nearestRat != null)
        {
            Vector3 direction = nearestRat.position - transform.position;
            direction.y = 0; // Keep rotation horizontal
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}