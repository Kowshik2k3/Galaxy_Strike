using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    private SceneManagerScript sceneManagerScript;

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Application.Quit();
        }
    }

    private void Start()
    {
        sceneManagerScript = FindFirstObjectByType<SceneManagerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        sceneManagerScript.RelodeScene();
        Debug.Log("Player collided with: " + other.gameObject.name);
    }
}

    