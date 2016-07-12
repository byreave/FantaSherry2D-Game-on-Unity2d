using UnityEngine;
using System.Collections;

public class BossKnScript : MonoBehaviour {

	//--------------------------------
	// 1 - Designer variables
	//--------------------------------

	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform playerPrefab;
	public Transform kPrefab;
	public Vector2 direction = new Vector2(0, 0);
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	/// 这个是子弹射击间隔
	public float shootingRate = 1f;

	//--------------------------------
	// 2 - Cooldown
	//--------------------------------

	private float shootCooldown;

	void Start()
	{
		shootCooldown = 1f;
	}

	void Update()
	{
		if (Vector2.Distance (playerPrefab.position, this.transform.position) < 20) {
			if (shootCooldown > 0) {
				shootCooldown -= Time.deltaTime;
			}
		}
	}

	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------

	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			// Create a new shot
			var shotTransform = Instantiate(kPrefab) as Transform;

			// Assign position
			shotTransform.position = transform.position;

			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();

			direction=new Vector2(-1,0);
			direction.Normalize();
			if (move != null)
			{
				move.direction = this.direction; // towards in 2D space is the right of the sprite
			}
		}
	}

	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
