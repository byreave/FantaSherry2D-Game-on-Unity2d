using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class BirdEnemyScript : MonoBehaviour
{
	private BirdWeaponScript weapon1;

	void Awake()
	{
		// Retrieve the weapon only once
		weapon1 = GetComponent<BirdWeaponScript>();
	}

	void Update()
	{
		// Auto-fire
		if (weapon1 != null && weapon1.CanAttack)
		{
			weapon1.Attack(true);
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
