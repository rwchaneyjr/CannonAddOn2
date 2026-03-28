using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public GameObject cannonballPrefab;
    public float bulletSpeed = 20f;

    // 🔥 Now adjustable in Inspector (X, Y, Z)
    public Vector3 spawnOffset = Vector3.zero;

    private Transform firePoint;

    void Start()
    {
        firePoint = null;
        Debug.Log("This object is: " + gameObject.name);

        foreach (Transform t in GetComponentsInChildren<Transform>(true))
        {
            Debug.Log("Child under cannon: " + t.name);
        }
        foreach (Transform t in GetComponentsInChildren<Transform>(true))
        {
            if (t.name.Trim().ToLower() == "firepoint")
            {
                firePoint = t;
                Debug.Log("✅ firePoint found at runtime");
                break;
            }
        }

        if (firePoint == null)
        {
            Debug.LogError("❌ firePoint NOT FOUND at runtime");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    public void Fire()
    {
        if (firePoint == null || cannonballPrefab == null)
        {
            Debug.LogError("Missing firePoint or cannonballPrefab");
            return;
        }

        // 🔥 NEW: adjustable local offset
        Vector3 adjustedSpawnPos =
            firePoint.position
            + firePoint.right * spawnOffset.x
            + firePoint.up * spawnOffset.y
            + firePoint.forward * spawnOffset.z;

        GameObject ball = Instantiate(cannonballPrefab, adjustedSpawnPos, firePoint.rotation);

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Cannonball prefab has no Rigidbody!");
        }
    }
}