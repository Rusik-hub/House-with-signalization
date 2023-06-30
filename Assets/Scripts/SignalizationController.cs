using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SignalizationController : MonoBehaviour
{
    [SerializeField] private TriggerChecker _signalizationZone;

    private AudioSource _audio;

    private void Start()
    {
        if (GetComponent<AudioSource>())
            _audio = GetComponent<AudioSource>();
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
        Debug.Log("Audio on");
        _audio.Play();
        StartCoroutine(MoveVolumeToTarget(1f));
    }

    private void DisableSignalization()
    {
        Debug.Log("Audio off");
        StartCoroutine(MoveVolumeToTarget(0f));
        _audio.Pause();
    }

    private IEnumerator MoveVolumeToTarget(float target)
    {
        _audio.volume = Mathf.MoveTowards(_audio.volume, target, 0.01f);

        yield return null;
    }
}
