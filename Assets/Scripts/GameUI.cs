using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
  [SerializeField] private Sprite m_RedReticle;
  [SerializeField] private Sprite m_YellowReticle;
  [SerializeField] private Sprite m_BlueReticle;
  [SerializeField] private Image m_Reticle;
  [SerializeField] private Text m_AmmoText;
  [SerializeField] private Text m_HealthText;
  [SerializeField] private Text m_ArmorText;
  [SerializeField] private Text m_PickupText;
  [SerializeField] private Text m_WaveText;
  [SerializeField] private Text m_EnemyText;
  [SerializeField] private Text m_WaveClearText;
  [SerializeField] private Text m_NewWaveText;
  [SerializeField] private Player player;

  public void UpdateReticle() {
    switch (GunEquipper.ActiveWeaponType) {
      case Constants.Pistol:
        m_Reticle.sprite = m_RedReticle;
        break;
      case Constants.AssaultRifle:
        m_Reticle.sprite = m_BlueReticle;
        break;
      case Constants.Shotgun:
        m_Reticle.sprite = m_YellowReticle;
        break;
      default:
        return;
    }
  }
}