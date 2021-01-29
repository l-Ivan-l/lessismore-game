using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class RocksTrigger : MonoBehaviour
{
    private Collider col;
    private List<GameObject> rocks = new List<GameObject>();

    [Header("Camera Screenshake")]
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    public float shakeDuration = 3f;
    public float shakeAmplitude = 1.2f;
    public float shakeFrequency = 2f;
    private float shakeElapsedTime = 0f;

    [Space]
    [SerializeField]
    private SoundManager soundManager;

    private void Awake()
    {
        col = GetComponent<Collider>();    
        for(int i = 0; i < transform.childCount; i++)
        {
            rocks.Add(transform.GetChild(i).gameObject);
        }

        virtualCameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if(!col.enabled)
        {
            ScreenShake();
        }
    }

    void ScreenShake()
    {
        if (shakeElapsedTime > 0)
        {
            virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
            virtualCameraNoise.m_FrequencyGain = shakeFrequency;

            shakeElapsedTime -= Time.deltaTime;
        }
        else
        {
            virtualCameraNoise.m_AmplitudeGain = 0f;
            shakeElapsedTime = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Release rocks
            soundManager.PlayTremorSound(1f);
            col.enabled = false;
            shakeElapsedTime = shakeDuration; //Activate screenshake
            StartCoroutine(RocksFalling());
        }
    }

    IEnumerator RocksFalling()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < rocks.Count; i++)
        {
            rocks[i].SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
