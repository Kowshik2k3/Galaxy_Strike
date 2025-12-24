using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] lasers;
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform trackingTarget;
    [SerializeField] private float targetDistance = 100f;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false; // Hide the cursor
    }
    private void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
        // Debug.Log("Pressed");
    }

    private void Update()
    {
        ProcessFire();
        TrackMouse();
        TrackTarget();
        RotateToTarget();
    }

    private void RotateToTarget()
    {
        foreach (ParticleSystem laser in lasers)
        {
            Vector3 direction = trackingTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            laser.transform.rotation = lookRotation;
        }
    }
    private void TrackTarget()
    {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        trackingTarget.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }

    private void TrackMouse()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    private void ProcessFire()
    {
        foreach (ParticleSystem laser in lasers)
        {
            var emissionModule = laser.emission;
            emissionModule.enabled = isFiring;
        }
    }
}
