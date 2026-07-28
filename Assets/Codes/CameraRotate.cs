using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public VariableJoystick variableJoystick;
    public Transform playerObjesi;
    public Transform kameraObjesi;

    [Header("Orbit")]
    public float distance = 7f;
    public float pivotHeight = 2f;

    [Header("Rotation")]
    public float rotateSpeed = 120f;   // derece / saniye
    public float defaultPitch = 20f;   // kameranin X rotation degeri
    public bool allowVerticalRotation = false;
    public float minPitch = 5f;
    public float maxPitch = 45f;

    private float yaw;
    private float pitch;

    void Start()
    {
        yaw = kameraObjesi.eulerAngles.y;
        pitch = defaultPitch;
        Uygula();
    }

    void LateUpdate()
    {
        if (variableJoystick != null)
        {
            yaw += variableJoystick.Horizontal * rotateSpeed * Time.deltaTime;

            if (allowVerticalRotation)
            {
                pitch += variableJoystick.Vertical * rotateSpeed * Time.deltaTime;
                pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            }
        }

        Uygula();
    }

    // Aci degerlerinden transform'u her karede sifirdan kurar, boylece birikimli sapma olmaz.
    private void Uygula()
    {
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 pivot = playerObjesi.position + Vector3.up * pivotHeight;

        kameraObjesi.position = pivot + rotation * (Vector3.back * distance);
        kameraObjesi.rotation = rotation;
    }
}
