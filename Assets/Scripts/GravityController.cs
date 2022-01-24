using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    const float Gravity = 9.81f; // �d�͉����x

    public float gravityScale = 1f; // �d�͂̓K�p�

    void Update()
    {
        Vector3 vector = new Vector3();

        if (Application.isMobilePlatform)
        {
            vector.x = Input.acceleration.x;
            vector.z = Input.acceleration.y;
            vector.y = Input.acceleration.z;
        }
        else
        {
            vector.x = Input.GetAxis("Horizontal");
            vector.z = Input.GetAxis("Vertical");

            if (Input.GetKey("z"))
            {
                vector.y = 1f;
            }
            else
            {
                vector.y = -1f;
            }
        }
        Physics.gravity = Gravity * vector.normalized * gravityScale;
    }
}
