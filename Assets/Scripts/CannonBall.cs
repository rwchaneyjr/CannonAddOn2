//Unity CannonBall Script
using UnityEngine;

public class Cannonball : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rat"))
        {
            Destroy(other.gameObject);  // Kill any rat
            Destroy(gameObject);        // Destroy cannonball
          
        }
    }


}
