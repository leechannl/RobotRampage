using UnityEngine;

public class Gun : MonoBehaviour {
  public float FireRate;
  protected float LastFireTime;

  // Use this for initialization
  private void Start() {
    LastFireTime = Time.time - 10;
  }

  // Update is called once per frame
  protected virtual void Update() { }

  protected void Fire() { }
}