using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Move : MonoBehaviour
{

    public GameObject StartNPC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(0, 0, 0);

        float speed = 1f;

        transform.position = Vector3.SmoothDamp(transform.position, target, ref velo, speed);
    }
}
