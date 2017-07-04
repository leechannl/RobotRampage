using UnityEngine;

public class Pistol : Gun {
  protected override void Update() {
    base.Update();
    if (Input.GetMouseButtonDown(0) && Time.time - LastFireTime > FireRate) {
      LastFireTime = Time.time;
      Fire();
    }
  }
}