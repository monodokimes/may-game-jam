﻿using Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRoll : MonoBehaviour
{
    [SerializeField]
    private float _maxTilt;

    private PlayerInput _input;

    // Use this for initialization
    void Start()
    {
        _input = this.Find<PlayerInput>(GameTags.Input);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _input.HorizontalRotation(_maxTilt);
    }
}
