using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootHoldFade : MonoBehaviour
{
    [HideInInspector]
    public MeshRenderer _renderer;
    Collider _collider;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(Dissappear());
    }

    IEnumerator Dissappear()
    {
        yield return new WaitForSeconds(2f);
        while (_renderer.material.color.a > 0)
        {
            var color = _renderer.material.color;
            color.a -= (0.5f * Time.deltaTime);

            _renderer.material.color = color;
            yield return null;
        }
        _collider.enabled = false;

        yield return new WaitForSeconds(5f);
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        _collider.enabled = true;
        while(_renderer.material.color.a < 1)
        {
            var color = _renderer.material.color;
            color.a += (0.5f * Time.deltaTime);

            _renderer.material.color = color;
            yield return null;
        }
    }
}
