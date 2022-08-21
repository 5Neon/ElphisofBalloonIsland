using System.Collections;
using UnityEngine;

public class NPC_Move : MonoBehaviour
{

    public GameObject megas; // 스크립트 찾기
    public GameObject target_looking;
    public GameObject targetPosition;
    public GameObject Delay_Text;

    public int looking_speed = 1;
    public float Stoplooking_time = 9f;

    public bool looking;

    public float move_speed = 4;

    public void FixedUpdate()
    {
        if (looking)
        {
            megas.GetComponent<Look_Player>().lookingstop = true;
            target_Looking();
        }
        
    }



    public void target_Looking()
    {
        Vector3 dir = target_looking.transform.position - this.transform.position;
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * looking_speed);
    }

    public void npc_move()
    {
        StartCoroutine(Times());
    }
    IEnumerator Times()
    {
        Delay_Text.GetComponent<TextManager>().Delay_Text = true; 
        StartCoroutine(npc_Move());
        yield return new WaitForSeconds(move_speed * 2);
        Delay_Text.GetComponent<TextManager>().Delay_Text = false;
        GameManager.isTalking = false;
        yield return new WaitForSeconds(Stoplooking_time - 1f);
        StopCoroutine(npc_Move());
        looking = false;
        megas.GetComponent<Look_Player>().lookingstop = false;
    }
    IEnumerator npc_Move()
    {
        Vector3 vel = Vector3.zero;
        while (true)
        {
            yield return null;
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, targetPosition.transform.position, ref vel, move_speed);
        }
    }

    void Update()
    {

    }


}
