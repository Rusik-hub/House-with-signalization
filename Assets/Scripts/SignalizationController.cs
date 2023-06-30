using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]

public class SignalizationController : MonoBehaviour
{
    [SerializeField] private TriggerChecker _signalizationZone;

    private AudioSource _audio;
    private float _volumeMoveScale = 0.001f;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
    }

    private void OnEnable()
    {
        _signalizationZone.GetComponent<TriggerChecker>().EnterInHouse += EnableSignalization;
        _signalizationZone.GetComponent<TriggerChecker>().ExitFromHouse += DisableSignalization;
    }

    private void OnDisable()
    {
        _signalizationZone.GetComponent<TriggerChecker>().EnterInHouse -= EnableSignalization;
        _signalizationZone.GetComponent<TriggerChecker>().ExitFromHouse -= DisableSignalization;
    }

    private void EnableSignalization()
    {
        _audio.Play();
        StartCoroutine(MoveVolumeToTarget(1f));
    }

    private void DisableSignalization()
    {
        StartCoroutine(MoveVolumeToTarget(0f));
        _audio.Pause();
    }

    private IEnumerator MoveVolumeToTarget(float target)
    {
        while (_audio.volume != target)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _volumeMoveScale);

            yield return null;
        }

    }
}
