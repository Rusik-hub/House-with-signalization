using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _enterInHouse;

    private float _volumeMoveScale = 0.01f;
    private float _targetVolume;
    private AudioSource _signalizationAudio;

    private void Awake()
    {
        _signalizationAudio = GetComponent<AudioSource>();
        _signalizationAudio.volume = 0f;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _targetVolume = 1f;

            _enterInHouse?.Invoke();
        }
    }

    public void OnTriggerStay(Collider collision)
    {
        _signalizationAudio.volume = Mathf.MoveTowards(_signalizationAudio.volume, _targetVolume,
            _volumeMoveScale);
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _targetVolume = 0f;
        }
    }
}
