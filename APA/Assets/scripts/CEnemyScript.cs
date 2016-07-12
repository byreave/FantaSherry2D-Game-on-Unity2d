using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class CEnemyScript : MonoBehaviour
{
	private CWeaponScript weapon;

	void Awake()
	{
		// Retrieve the weapon only once
		weapon = GetComponent<CWeaponScript>();
	}

	void Update()
	{
		// Auto-fire
		if (weapon != null && weapon.CanAttack)
		{
			weapon.Attack(true);
		}
	}
}
/*public class EnemyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}*/