using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MiniMapView : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    private Transform _player;
    private void Start()
    {
        _offset = new Vector3(0, 0, 4);
        _player = Camera.main.transform;
        transform.parent = null;
        transform.rotation = Quaternion.Euler(90.0f, 0, 0);
        transform.position = _player.position + _offset;

        var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

        GetComponent<Camera>().targetTexture = rt;
    }

    private void LateUpdate()
    {
        var newPosition = _player.position + _offset;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation =  Quaternion.Euler(90, _player.eulerAngles.y, 0);
    }
}
