using UnityEngine;

public class GunEquipper : MonoBehaviour {
  public static string ActiveWeaponType;
  public GameObject Pistol;
  public GameObject AssaultRifle;
  public GameObject Shotgun;

  [SerializeField] private GameUI m_GameUi;

  private GameObject m_ActiveGun;

  // Use this for initialization
  void Start() {
    ActiveWeaponType = Constants.Pistol;
    LoadWeapon(Pistol);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown("1")) {
      LoadWeapon(Pistol);
      ActiveWeaponType = Constants.Pistol;
      m_GameUi.UpdateReticle();
    } else if (Input.GetKeyDown("2")) {
      LoadWeapon(AssaultRifle);
      ActiveWeaponType = Constants.AssaultRifle;
      m_GameUi.UpdateReticle();
    } else if (Input.GetKeyDown("3")) {
      LoadWeapon(Shotgun);
      ActiveWeaponType = Constants.Shotgun;
      m_GameUi.UpdateReticle();
    }
  }

  public GameObject GetActiveWeapon() {
    return m_ActiveGun;
  }

  private void LoadWeapon(GameObject weapon) {
    Pistol.SetActive(false);
    AssaultRifle.SetActive(false);
    Shotgun.SetActive(false);

    weapon.SetActive(true);
    m_ActiveGun = weapon;
  }
}