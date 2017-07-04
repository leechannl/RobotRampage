using System;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {
  [SerializeField] private GameUI m_GameUi;
  [SerializeField] private int pistolAmmo = 20;
  [SerializeField] private int shotgunAmmo = 10;
  [SerializeField] private int assaultRifleAmmo = 50;

  public Dictionary<String, int> tagToAmmo;
  
  
}