using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CamType
{
    First,
    Third
}
public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private CamType camType;
    [SerializeField]
    private Transform targetTransform;
    [SerializeField]
    private Transform firstCamPos;
    private Transform cameraTransform;

    [Range(2.0f, 20.0f)]
    public float distance = 10.0f;

    [Range(0.0f, 10.0f)]
    public float height = 2.0f;

    public float moveDamping = 15f;
    public float rotateDamping = 150f;
    [SerializeField]
    private float cameraRotationLimit = 40f;
    public float targetOffset = 2.0f;
    public float rotationX = 0.0f;
    public float rotationY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (camType == CamType.First)
        {
            FirstCam();
        }
        else if (camType == CamType.Third)
        {
            ThreeCam();
        }
    }
    private void FirstCam()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX = cameraTransform.eulerAngles.y + mouseX * rotateDamping;
        rotationX = (rotationX > 180.0f) ? rotationX - 360 : rotationX;
        rotationY = rotationY + mouseY * rotateDamping;
        rotationY = Mathf.Clamp(rotationY, -45, 80);
        cameraTransform.eulerAngles = new Vector3(-rotationY, rotationX, 0);
        cameraTransform.position = firstCamPos.position;
        targetTransform.eulerAngles = cameraTransform.eulerAngles;
    }
    private void ThreeCam()
    {
        Vector3 pos = targetTransform.position
                      + (-targetTransform.forward * distance)
                      + (Vector3.up * height);

        cameraTransform.position = Vector3.Slerp(cameraTransform.position, pos, moveDamping * Time.deltaTime);

        cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, targetTransform.rotation, rotateDamping * Time.deltaTime);

        cameraTransform.LookAt(targetTransform.position + (targetTransform.up * targetOffset));
    }
}
