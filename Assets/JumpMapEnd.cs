using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMapEnd : MonoBehaviour
{
    public PlayerMovement _player;
    public Transform airballoontarget;
    public Transform airballoonposition;
    bool balloon = false;

    private void OnTriggerEnter(Collider other)
    {
        _player.rb.AddForce(transform.up * 8, ForceMode.Impulse);
        _player.rb.AddForce(transform.right * -3, ForceMode.Impulse);
        _player.rb.AddForce(transform.forward, ForceMode.Impulse);
        balloon = true;
    }

    private void Update()
    {
        if (balloon && _player.transform.position.y >= 41f)
        {
            _player.InstantiateBalloon();
            _player.animator.SetBool("isHanging", true);
            GameManager.onBalloon = true;

            if (GameManager.onAir == true)
            {
                _player.rb.drag = _player.fallSpeed;
            }

            airballoontarget.position = new Vector3(-390, airballoontarget.transform.position.y, 17.5f);
            airballoonposition.position = new Vector3(-390, airballoonposition.transform.position.y, 17.5f);
            balloon = false;
        }
    }
}
