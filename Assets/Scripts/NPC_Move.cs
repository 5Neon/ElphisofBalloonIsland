using System.Collections;
using UnityEngine;

public class NPC_Move : MonoBehaviour
{
    public GameObject targetPosition;
    public Transform targetEnInfo;
    public Transform targetPlayer;

    public float speed = 4;

    private bool isFinished = false;

    public void npc_move()
    {
        StartCoroutine(npc_Move());
        isFinished = true;
    }

    IEnumerator npc_Move()
    {
        float speed = 2f;
        Vector3 vel = Vector3.zero;

        while (true)
        {
            yield return null;
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition.transform.position, ref vel, speed);
        }       
    }


    void Update()
    {
        LookTarget();
    }

    void LookTarget()
    {
        if (targetEnInfo != null && isFinished == true)
        {
            Vector3 dir = (targetEnInfo.position - transform.position).normalized;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        }
    }
}
