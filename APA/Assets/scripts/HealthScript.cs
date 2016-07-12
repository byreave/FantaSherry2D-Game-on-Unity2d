using UnityEngine;
using System.Collections;

/// <summary>
/// Handle hitpoints and damages
/// </summary>
public class Health1Script : MonoBehaviour
{
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp= 1;
	private Animator m_Anim;
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = true;

	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp--;
		m_Anim = GetComponent<Animator>();
		if (hp <= 0)
		{
			m_Anim.SetBool ("IsAlive", false);
			// 'Splosion!
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			// Dead!
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);

				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}
/*public class HealthScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}*/
