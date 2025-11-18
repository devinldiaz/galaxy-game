using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 10f;
    [SerializeField] float rotationSpeed = 10f;
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value){
        movement = value.Get<Vector2>();
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xClampRange, xClampRange);


        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(-controlPitchFactor * movement.y, 0f, -controlRollFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
