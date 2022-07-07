using System.Collections;
using UnityEngine;

public class NPC_Move : MonoBehaviour
{

    public GameObject targetPosition;
    public GameObject targetEnInfo;
    public float speed = 4;

    public void npc_move()
    {
        StartCoroutine(npc_Move());

    }

    IEnumerator npc_Move() //°íÃÄ¾ßµÊ
    {
        float speed = 2f;
        Vector3 vel = Vector3.zero;
        while (true)
        {
            yield return null; //°íÃÄ¾ßµÊ
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition.transform.position, ref vel, speed);
        }
    }

    
    void Update()
    {
        FollowTarget();
    }
    void FollowTarget()

    {
        if (targetEnInfo != null)
        {
            Vector3 dir = targetEnInfo.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        }

    }
}
