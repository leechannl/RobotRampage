using UnityEngine;

public class Gun : MonoBehaviour {
  public float fireRate;
  protected float lastFireTime;

  // Use this for initialization
  void Start() {
    lastFireTime = Time.time - 10;
  }

  // Update is called once per frame
  protected virtual void Update() { }

  protected void Fire() { }
}