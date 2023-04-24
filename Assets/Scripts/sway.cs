using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sway : MonoBehaviour
{
    private Quaternion originLocalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originLocalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        updateSway();
    }

    private void updateSway()
    {
        float t_xLookInput = Input.GetAxis("Mouse X");
        float t_yLookInput = Input.GetAxis("Mouse Y");

        Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(-t_xLookInput * 7f, Vector3.up);
        Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(t_yLookInput * 7f, Vector3.right);
        Quaternion t_targetRotation = originLocalRotation * t_xAngleAdjustment * t_yAngleAdjustment;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targetRotation, Time.deltaTime * 10f);
    }
}
