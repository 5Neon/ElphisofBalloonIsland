using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookJumpMapCneter : MonoBehaviour
{
    public Transform jumpMapCenter;
    private float timeCounter = 0;
    public float jumpMapSpeed = 3f;
    public float jumpMapRadiusSize = 10f;

    void FixedUpdate()
    {
        if (GameManager.doJumpMap)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                timeCounter -= jumpMapSpeed * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                timeCounter += jumpMapSpeed * Time.fixedDeltaTime;
            }

            float posx = jumpMapCenter.position.x + Mathf.Cos(timeCounter) * jumpMapRadiusSize;
            float posy = transform.position.y;
            float posz = jumpMapCenter.position.z + Mathf.Sin(timeCounter) * jumpMapRadiusSize;

            transform.position = new Vector3(posx, posy, posz);
            transform.LookAt(new Vector3(jumpMapCenter.position.x, transform.position.y, jumpMapCenter.position.z));
        }
    }
}
