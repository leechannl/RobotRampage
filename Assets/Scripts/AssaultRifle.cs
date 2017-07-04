﻿using UnityEngine;

public class AssaultRifle : Gun {
  protected override void Update() {
    base.Update();
    if (Input.GetMouseButton(0) && Time.time - LastFireTime > FireRate) {
      LastFireTime = Time.time;
      Fire();
    }
  }
}