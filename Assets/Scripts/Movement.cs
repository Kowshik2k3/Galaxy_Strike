
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xRange = 15f;
    [SerializeField] private float yRange = 15f;
    [SerializeField] private float rollingFactor = 10f;
    [SerializeField] private float pitchFactor = 10f;
    [SerializeField] private float rotationSpeed = 5f;

    Vector2 movement;
    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float xRaw = transform.localPosition.x + xOffset;
        float xFinal = Mathf.Clamp(xRaw, -xRange, xRange);  // clamp is used to fix the limit of movement range 

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float yRaw = transform.localPosition.y + yOffset;
        float yFinal = Mathf.Clamp(yRaw, -yRange, yRange);
        transform.localPosition = new Vector3(xFinal,yFinal, 0f);
    }

    private void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(-pitchFactor * movement.y, 0f,-rollingFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>()); 
        movement = value.Get<Vector2>();
    }
}
    