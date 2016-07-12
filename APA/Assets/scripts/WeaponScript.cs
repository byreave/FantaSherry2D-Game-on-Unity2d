using UnityEngine;
using System.Collections;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
	//--------------------------------
	// 1 - Designer variables
	//--------------------------------

	/// <summary>
	/// Projectile prefab for shooting
	/// </summary>
	public Transform shotPrefab;
	public Vector2 moveDirection;
	public Vector2 moveToward;
	public Vector2 currentPosition;
	public float moveSpeed=10.0f;
	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 1f;
    Animator m_anim;
	//--------------------------------
	// 2 - Cooldown
	//--------------------------------

	private float shootCooldown;
	void Start()
	{
        m_anim = GetComponent<Animator>();
		shootCooldown = 0f;
	}

	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
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
        //Vector3 v = Camera.main.WorldToScreenPoint(transform.position);
		if (CanAttack&&!GetComponent<Game>().isModeRope) {
			if (Input.GetButtonDown ("Fire1")) {
                //Invoke("SetFalse", 2);
				shootCooldown = shootingRate;

				currentPosition = this.transform.position;
				//Debug.Log (currentPosition);

				//Debug.Log (transform.position);
                
				moveToward = Camera.main.ScreenToWorldPoint (Input.mousePosition);
                if(moveToward.y > transform.position.y)
                {
                    m_anim.SetBool("Shooting", true);

                    //moveToward = Input.mousePosition;
                    //Debug.Log (moveToward);
                    //得到移动方向的单位向量
                    moveDirection = moveToward - currentPosition;
                    //Debug.Log (currentPosition);
                    //moveDirection.z = 0; 
                    //Debug.Log (moveDirection);
                    moveDirection.Normalize();

                    // Create a new shot
                    var shotTransform = Instantiate(shotPrefab) as Transform;
                    // Assign position
                    shotTransform.position = this.transform.position;
                    // The is enemy property
                    ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                    if (shot != null)
                    {
                        shot.isEnemyShot = isEnemy;
                    }
                    //Vector3 target = moveDirection * moveSpeed + currentPosition;

                    //以 moveSpeed 的速度向指定方向前进
                    //transform.position = Vector3.Lerp( currentPosition, target, Time.deltaTime );

                    //transform.position = currentPosition + moveDirection * moveSpeed * Time.deltaTime;
                    // Make the weapon shot always towards it
                    MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
                    if (move != null)
                    {
                        move.direction = this.moveDirection; // towards in 2D space is the right of the sprite
                    }
                }
			}
            Invoke("setFalse", 1.0f) ;
		}
	}
    void setFalse()
    {
        m_anim.SetBool("Shooting", false);
    }
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
	/// <summary>
	/// Is the weapon ready to create a new projectile?
	/// </summary>
}
/*public class WeaponScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}*/
