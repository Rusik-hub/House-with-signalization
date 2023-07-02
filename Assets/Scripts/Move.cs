using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private House _house;

    private Vector3 _startPosition;
    private Vector3 _housePosition;

    private void Start()
    {
        _startPosition = transform.position;
        _housePosition = _house.GetComponent<Transform>().position;
    }

    //private void Update()
    //{
    //    transform.position = Vector3.Lerp(transform.position, _housePosition, 0.1f);
    //}

    public void SetNormalizedPosition(float position)
    {
        transform.position = Vector3.Lerp(_startPosition, _housePosition, position);
    }
}
