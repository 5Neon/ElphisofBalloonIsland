using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMapState : MonoBehaviour
{
    Collider _collider;
    public PlayerMovement _player;
    public CameraSpinner _cameraS;
    public CameraLerp _cameraL;
    public Camera _maincamera;
    public GameObject rainbowonjump;

    Vector3 startPoint;
    bool lookCenter = false;
    bool transposition = false;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (lookCenter)
        {
            _cameraS.transform.LookAt(new Vector3(_player.jumpMapCenter.position.x, _cameraS.transform.position.y, _player.jumpMapCenter.position.z));
            _maincamera.transform.localRotation = Quaternion.Lerp(_maincamera.transform.localRotation, Quaternion.Euler(5, 0, 0), 1f * Time.fixedDeltaTime);    // 카메라의 y회전각이 0으로 되지 않는 문제로 인한 임시방편
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager.JumpMapTriggerOn = true;
        GameManager.isTalking = true;
        startPoint = new Vector3(_player.jumpMapCenter.position.x + Mathf.Cos(0) * _player.jumpMapRadiusSize, _player.transform.position.y, _player.jumpMapCenter.position.z + Mathf.Sin(0) * _player.jumpMapRadiusSize);

        StartCoroutine(MoveToStartPoint());
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(JumpMapEnd());
        GameManager.JumpMapTriggerOn = false;
        GameManager.doJumpMap = false;
        //GameObject.Find("jump_rainbow").gameObject.SetActive(true);
        rainbowonjump.SetActive(true);
        _collider.isTrigger = false;    // 점프맵을 끝낸 후 재입장할 수 없도록 하기 위함
    }

    IEnumerator MoveToStartPoint()
    {
        bool isMoveEnd = false;

        while (!isMoveEnd)
        {
            _cameraS.transform.LookAt(new Vector3(_player.jumpMapCenter.position.x, _cameraS.transform.position.y, _player.jumpMapCenter.position.z));

            _maincamera.transform.position = Vector3.Slerp(_maincamera.transform.position, new Vector3(_cameraL.transform.position.x, _cameraL.transform.position.y + 6f, _cameraL.transform.position.z), 8f * Time.fixedDeltaTime);
            _maincamera.transform.rotation = Quaternion.Slerp(_maincamera.transform.rotation, Quaternion.Euler(5, -90, 0), 1.8f * Time.fixedDeltaTime);

            _maincamera.orthographicSize = Mathf.Lerp(_maincamera.orthographicSize, 8f, 0.3f);
            _maincamera.nearClipPlane = Mathf.Lerp(_maincamera.nearClipPlane, -50f, 0.5f);

            _player.animator.SetBool("isMoving", true);
            _player.transform.LookAt(startPoint);
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, startPoint, 4f * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();

            if (_player.transform.position == startPoint)
            {
                isMoveEnd = true;
                _player.animator.SetBool("isMoving", false);

                GameManager.doJumpMap = true;
                GameManager.isTalking = false;
                lookCenter = true;
            }
        }
        yield break;
    }

    IEnumerator JumpMapEnd()
    {
        lookCenter = false;

        while (!transposition)
        {
            _cameraS.transform.position = new Vector3(_player.transform.position.x, _cameraS.transform.position.y, _player.transform.position.z);
            //_maincamera.transform.localPosition = new Vector3(-20, 18.5f, -20);
            //_maincamera.transform.localRotation = Quaternion.Euler(30, 45, 0);
            _maincamera.transform.localPosition = Vector3.Slerp(_maincamera.transform.localPosition, new Vector3(-20, 18.5f, -20), 8f * Time.fixedDeltaTime);
            _maincamera.transform.localRotation = Quaternion.Slerp(_maincamera.transform.localRotation, Quaternion.Euler(30f, 45f, 0f), 1.8f * Time.fixedDeltaTime);

            _maincamera.orthographicSize = Mathf.Lerp(_maincamera.orthographicSize, 5f, 0.3f);
            _maincamera.nearClipPlane = Mathf.Lerp(_maincamera.nearClipPlane, -10, 0.5f);
            yield return new WaitForFixedUpdate();

            if (_maincamera.transform.rotation == Quaternion.Euler(30, 45, 0))
            {
                transposition = true;
            }
            Debug.Log(transposition);
            _cameraS.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        yield break;
    }
}
