using UnityEngine;
using System.Collections;

/// <summary>
/// Projectile behavior
/// </summary>
public class ShotScript : MonoBehaviour
{
	// 1 - Designer variables

	/// <summary>
	/// Damage inflicted
	/// </summary>
	public int damage = 1;
	public bool isitself = true;
	public int  radius=5;
	public int layerMask=LayerMask.GetMask("body");
	public Collider2D[] colliders;
	/// <summary>
	/// Projectile damage player or enemies?
	/// </summary>
	public bool isEnemyShot = false;
	void OnBecameInvisible(){
		Destroy (gameObject, 3);
	}
	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		//Destroy(gameObject, 20); // 20sec
	}
	void FixUpdate()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position,radius,1 << LayerMask.NameToLayer("body"));

	}
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders [i].gameObject != gameObject)
				isitself = false;
		}
		if(!isitself)
		Destroy(gameObject); // Remember to always target the game object, otherwise you will just remove the script
	}
}
