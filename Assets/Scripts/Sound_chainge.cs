using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_chainge : MonoBehaviour
{
    public AudioSource[] Chainge_Audio;

    int old_Audio;
    
    public void chainge_Audio(int Audio)
    {
        StartCoroutine(Audio_Fade(Audio));
        old_Audio = Audio;
    }

    IEnumerator Audio_Fade(int Audio)
    {
        while (true)
        {
            yield return null;
            Chainge_Audio[0].volume -= Time.deltaTime * 0.1f;
            Chainge_Audio[Audio].volume += Time.deltaTime * 0.1f;
            if (Chainge_Audio[0].volume < 0)
            {
                yield break;
            }
        }
        
    }

}
