using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject _character;

    private void Update()
    {
        transform.position = _character.transform.position + new Vector3(0, 2.5f, -8);
        transform.rotation = Quaternion.Euler(new Vector3(12, 0, 0));
    }
}
