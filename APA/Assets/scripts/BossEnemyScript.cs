using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy generic behavior
/// </summary>
public class BossEnemyScript : MonoBehaviour
{
	private BossWeaponScript weapon;
	private Animator m_Anim;
	private bool flag = false;
	void Awake()
	{
		// Retrieve the weapon only once
		weapon = GetComponent<BossWeaponScript>();
		m_Anim = GetComponent<Animator>();
	}

	void Update ()
	{
		// Auto-fire
		if (weapon != null && weapon.CanAttack) {
			if(!flag)
			{m_Anim.SetBool ("Gun", true);

				Invoke ("Set", 2);
				flag = true;
			}
			weapon.Attack (true);
		}
	}
	void Set()
	{
		m_Anim.SetBool ("Gun", false);
		flag = false;

	}
}
