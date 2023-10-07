using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{
    public Material blueMaterial;
    public MeshRenderer lightRenderer;
    public bool playerInRange = false;

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.E))
            lightRenderer.material = blueMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
