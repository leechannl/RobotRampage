using UnityEngine;

public class Gun : MonoBehaviour {
  public float FireRate;
  public Ammo Ammo;
  public AudioClip LiveFire;
  public AudioClip DryFire;
  public float ZoomFactor;
  public int Range;
  public int Damage;

  protected float LastFireTime;
  private float m_ZoomFov;
  private float m_ZoomSpeed = 6;

  // Use this for initialization
  private void Start() {
    m_ZoomFov = Constants.CameraDefaultZoom / ZoomFactor;
    LastFireTime = Time.time - 10;
  }

  // Update is called once per frame
  protected virtual void Update() {
    if (Input.GetMouseButton(1)) {
      Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, m_ZoomFov, m_ZoomSpeed * Time.deltaTime);
    } else {
      Camera.main.fieldOfView = Constants.CameraDefaultZoom;
    }
  }

  protected void Fire() {
    if (Ammo.HasAmmo(tag)) {
      GetComponent<AudioSource>().PlayOneShot(LiveFire);
      Ammo.ConsumeAmmo(tag);
    } else {
      GetComponent<AudioSource>().PlayOneShot(DryFire);
    }
    GetComponent<Animator>().Play("Fire");

    var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, Range)) {
      processHit(hit.collider.gameObject);
    }
  }

  private void processHit(GameObject hitObject) {
    if (hitObject.GetComponent<Player>() != null) {
      hitObject.GetComponent<Player>().TakeDamage(Damage);
    }

    if (hitObject.GetComponent<Robot>() != null) {
      hitObject.GetComponent<Robot>().TakeDamage(Damage);
    }
  }
}