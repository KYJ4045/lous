﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Fire();
    }

    void Fire()
    {
        CreateBullte();
    }

    void CreateBullte()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }
}
