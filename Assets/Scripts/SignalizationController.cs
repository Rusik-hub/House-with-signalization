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
    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Coroutine _runningCoroutine;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = 0;
    }

    private void OnEnable()
    {
        _signalizationZone.EnterInHouse += EnableSignalization;
        _signalizationZone.ExitFromHouse += DisableSignalization;
    }

    private void OnDisable()
    {
        _signalizationZone.EnterInHouse -= EnableSignalization;
        _signalizationZone.ExitFromHouse -= DisableSignalization;
    }

    private void EnableSignalization()
    {
        _audio.Play();

        if (_runningCoroutine != null)
            StopCoroutine(_runningCoroutine);
            _runningCoroutine = StartCoroutine(MoveVolumeToTarget(_maxVolume));
    }

    private void DisableSignalization()
    {
        if (_runningCoroutine != null)
            StopCoroutine(_runningCoroutine);
            _runningCoroutine = StartCoroutine(MoveVolumeToTarget(_minVolume));
    }

    private IEnumerator MoveVolumeToTarget(float target)
    {
        float _runningTime = 0;

        while (_audio.volume != target)
        {
            _runningTime += Time.deltaTime;
            _audio.volume = Mathf.MoveTowards(_audio.volume, target, _volumeMoveScale);

            yield return null;
        }
    }
}
