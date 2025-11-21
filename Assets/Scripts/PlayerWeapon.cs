using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    void Start(){
        Cursor.visible = false;
    }

    void Update()
    {
        MoveCrossHair();
    }

    public void OnFire(InputValue value)
    {
        foreach (GameObject laser in lasers) {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = value.isPressed;
        }
    }

    void MoveCrossHair(){
        crosshair.position = Input.mousePosition;
    }
}


