using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent _enterInHouse;
    [SerializeField] private UnityEvent _exitFromHouse;

    public event UnityAction EnterInHouse
    {
        add => _enterInHouse.AddListener(value);
        remove => _enterInHouse.RemoveListener(value);
    }

    public event UnityAction ExitFromHouse
    {
        add => _exitFromHouse.AddListener(value);
        remove => _exitFromHouse.RemoveListener(value);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _enterInHouse?.Invoke();
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Burglar>(out Burglar burglar))
        {
            _exitFromHouse?.Invoke(); ;
        }
    }
}
