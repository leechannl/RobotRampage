using UnityEngine;

public class Gun : MonoBehaviour {
  public float FireRate;
  public Ammo Ammo;
  public AudioClip LiveFire;
  public AudioClip DryFire;
  protected float LastFireTime;

  // Use this for initialization
  private void Start() {
    LastFireTime = Time.time - 10;
  }

  // Update is called once per frame
  protected virtual void Update() { }

  protected void Fire() {
    if (Ammo.HasAmmo(tag)) {
      GetComponent<AudioSource>().PlayOneShot(LiveFire);
      Ammo.ConsumeAmmo(tag);
    } else {
      GetComponent<AudioSource>().PlayOneShot(DryFire);
    }
    GetComponent<Animator>().Play("Fire");
  }
}