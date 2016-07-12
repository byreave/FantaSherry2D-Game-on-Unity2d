using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Skill2 : MonoBehaviour {

    public float turnSpeed;
    public float stringSpeed;
    public float stringLength;
    //public Color color;
    private GameObject [] myHooks;
    private Vector3 vertexPos;
    private Vector3 moveDirection;
    private Vector3 targetPos;
    private LineRenderer skillLine;
    private int hookIndex;
    private bool isShooting;
    private bool isLong;
    private bool isHooked;
    private bool isBlocked; // To block mouse event when paused
    Animator m_anim;
	// Use this for initialization
    //private bool hasGetTouch;
	void Start () {
        isBlocked = false;
        isLong = true;
        isShooting = false;
        isHooked = false;
        hookIndex = -1;
        m_anim = GetComponent<Animator>();
       // hasGetTouch = false;
        vertexPos = transform.position;
        myHooks = GameObject.FindGameObjectsWithTag("HookPlace");
        skillLine = this.gameObject.GetComponent<LineRenderer>();
        //skillLine.SetColors(color, color);
        skillLine.SetWidth(0.1f, 0.1f);
        skillLine.enabled = false;
		Debug.Log (myHooks.Length);
        for(int  i = 0; i < myHooks.Length; ++ i) //initialize the joints
        {
			myHooks[i].GetComponent<DistanceJoint2D>().connectedBody = GameObject.Find("Sherry").GetComponent<Rigidbody2D>();
            myHooks[i].GetComponent<DistanceJoint2D>().enabled = false;
            //myHooks[i].GetComponent<DistanceJoint2D>().distance = (transform.position - myHooks[i].transform.position).magnitude;
        }
	}

	// Update is called once per frame
	void Update () {
        //hasGetTouch = false;
        Vector3 currentPosition = transform.position;
        skillLine.SetPosition(0, currentPosition);
        Vector3 m_mouse, m_player;
        if (!GetComponent<Game>().isFanta && GetComponent<Game>().isModeRope)
            isBlocked = false;
        else
            isBlocked = true;
        //Debug.Log(GetComponent<Game>().isModeRope);
        //Debug.Log(isBlocked);
        //if (Input.touchCount > 0 && !isBlocked)
        //isBlocked = GetComponent<Game>().isFanta;
        if(Input.GetButtonDown("Fire1") && !isBlocked)
        {
            m_mouse = Input.mousePosition;
            m_player = Camera.main.WorldToScreenPoint(GameObject.FindWithTag("Player").transform.position);
            //if(Input.touchCount == 1) //In case of mutiple tou
            //    m_touch = Input.GetTouch(0);
            //else
            //{
            //    for(int i = 0; i < Input.touchCount; ++ i)
            //    {
            //        if (Input.GetTouch(i).position.y > GameObject.FindWithTag("Player").transform.position.y)
                    //{
                    //    m_touch = Input.GetTouch(i);
                    //    hasGetTouch = true;
                    //    break;
                    //}
                    
                //}
            //}
            //m_touch = Input.GetTouch(0);//消除没赋值警告
            //Debug.Log("111");
            //if (hasGetTouch && m_touch.phase == TouchPhase.Began)
            //{
           // Debug.Log(m_mouse);
           // Debug.Log(m_player);
                if (!checkMouseOnUI(m_mouse) && (m_mouse.y > m_player.y))
                {
                    skillLine.enabled = true;
                    //Debug.Log(111);
                    if (!isShooting)
                    {
                        m_anim.SetBool("Rope", true);
                        targetPos = Camera.main.ScreenToWorldPoint(m_mouse);
                        // 4
                        moveDirection = targetPos - currentPosition;
                        moveDirection.z = 0;
                        moveDirection.Normalize();
                        vertexPos = currentPosition;
                        isLong = true;
                        skillLine.SetPosition(1, currentPosition);
                    }
                    if (isHooked)
                    {
                        //Debug.Log("222");
                        myHooks[hookIndex].GetComponent<DistanceJoint2D>().enabled = false;
                        isHooked = false;
                        vertexPos.x = 0;
                        vertexPos.y = 0;
                        vertexPos.z = 1;
                        skillLine.SetPosition(1, vertexPos);
                        hookIndex = -1;
                    }
                    isShooting = true;
                }
            //}
        }
        
        if (isShooting)
        {
            Vector3 temp = vertexPos - currentPosition;
            if (temp.magnitude > stringLength)
            {
                isLong = false;
            }
            if(isLong)
            {
                vertexPos += moveDirection * stringSpeed;
                skillLine.SetPosition(1, vertexPos);
            }
            else if (vertexPos.y > currentPosition.y)
            {
                vertexPos -= moveDirection * stringSpeed;
                skillLine.SetPosition(1, vertexPos);
            }
            else
            {
                //end
                vertexPos.x = 0;
                vertexPos.y = 0;
                vertexPos.z = 1;
                skillLine.SetPosition(1, vertexPos);
                isLong = true;
                isShooting = false;
                skillLine.enabled = false;
                m_anim.SetBool("Rope", false);
            }
            hookIndex = checkBoundary(myHooks);
            if (hookIndex != -1)
            {
                //Debug.Log("111");
                isHooked = true;
                isShooting = false;
                //isLong = false;
                vertexPos = myHooks[hookIndex].transform.position;
                skillLine.SetPosition(0, currentPosition);
                skillLine.SetPosition(1, vertexPos);
                m_anim.SetBool("Rope", false);
            }
        }
        if (isHooked)
        {
            //Debug.Log("1111");
            //Debug.Log(hookIndex);
            float h = CrossPlatformInputManager.GetAxis("Vertical");
            myHooks[hookIndex].GetComponent<DistanceJoint2D>().enabled = true;
            myHooks[hookIndex].GetComponent<DistanceJoint2D>().distance = (vertexPos - currentPosition).magnitude;
            if (CrossPlatformInputManager.GetButton("Jump"))
            {
                //Debug.Log("11111");
                //Debug.Log(hookIndex);
                myHooks[hookIndex].GetComponent<DistanceJoint2D>().enabled = false;
                isHooked = false;
                vertexPos.x = 0;
                vertexPos.y = 0;
                vertexPos.z = 1;
                skillLine.SetPosition(1, vertexPos);
                skillLine.enabled = false;
            }
            if (h > 0)
            {
                myHooks[hookIndex].GetComponent<DistanceJoint2D>().distance -= 0.05f;
            }
            if (h < 0)
            {
                myHooks[hookIndex].GetComponent<DistanceJoint2D>().distance += 0.05f;
            }
        }
	}
    int checkBoundary(GameObject [] arr)
    {
        for (int i = 0; i < arr.Length; ++ i)
        {
            if (vertexPos.x < arr[i].transform.position.x + 0.25f && vertexPos.x > arr[i].transform.position.x - 0.25f
                && vertexPos.y < arr[i].transform.position.y + 0.25f && vertexPos.y > arr[i].transform.position.y - 0.25f)
            {
                //Debug.Log(i);
                return i;
            }
        }
        return -1;
    }
    public void blockMouseEvent()
    {
        isBlocked = true;
    }
    public void releaseBlock()
    {
        isBlocked = false;
    }
    bool checkMouseOnUI(Vector3 Pos)
    {
        //Debug.Log(Pos);
        GameUI ui = Camera.main.GetComponent<GameUI>();
        
        if(Pos.x > Screen.width-10-ui.pauseBut.width && Pos.x < Screen.width-10 &&
            Pos.y < 50 + ui.pauseBut.height && Pos.y > 50)
        {
            return true;
        }
        if(ui.isPaused)
        {
            return true;
        }
        
        //change character button
        //change mode button
        //to be implemented
        //stillBuggy

        //Debug.Log("11111");
        return false;
    }
}
