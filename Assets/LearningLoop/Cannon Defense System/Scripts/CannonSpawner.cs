using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    public GameObject cannonPrefab;
    public Camera mainCamera;

    void Update()
    {
        // Left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("SteppingStone"))
                {
                    Vector3 spawnPosition = new Vector3(
                        hit.collider.transform.position.x,
                        hit.collider.transform.position.y + 2.4f,
                        hit.collider.transform.position.z
                    );

                    Instantiate(cannonPrefab, spawnPosition, Quaternion.identity);
                }
            }
#if UNITY_EDITOR
UnityEditor.Selection.activeGameObject = hit.collider.gameObject;
#endif
        }
    }
}