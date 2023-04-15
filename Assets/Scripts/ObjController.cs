using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    private static ObjController _instance;
    public static ObjController Instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;
        }
    }
    private TrackingInfo trackingInfo;
    private GestureInfo gestureInfo;
    private Animator animator;
    public Vector3 localPosition;
    private float last_y;
    private float cur_y;
    private float rotate_y;
    private float speed_y = 0.0005f;
    private float speed_x;
    private float max_x;
    private float a;
    //public GameObject lantern;
    private bool fly = false;

    // Start is called before the first frame update
    void Start()
    {
        cur_y = transform.position.y;
        last_y = cur_y;
        rotate_y = 0;
        max_x = 0.0005f;
        speed_x = 0;
        a = 0.0001f;
        //animator = GetComponent<Animator>();
        //lantern = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        gestureInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info;
        trackingInfo = ManomotionManager.Instance.Hand_infos[0].hand_info.tracking_info;
        DisplayTriggerGesture(gestureInfo.mano_gesture_trigger, trackingInfo);
        if(fly)
        {
            //飞行运动
            cur_y=transform.position.y;
            
            if (cur_y < last_y)
            {
                cur_y = last_y;
                
            }
            else
            {
                cur_y += 0.005f;
                last_y=cur_y;
            }
            //x方向运动
            if (a > 0)
            {
                if (speed_x > max_x)
                {
                    a = a * -1;
                }

            }
            if (a < 0)
            {
                if (speed_x < 0)
                {
                    a = a * -1;
                }
            }
            speed_x += a * Time.deltaTime;
            transform.position = new Vector3(transform.position.x + speed_x, cur_y, transform.position.z);
            //旋转
            rotate_y += Time.deltaTime * 20;
            transform.rotation = Quaternion.Euler(0, rotate_y, 0);
            Loggercfz.Log2(""+transform.position.y);
            //lantern.transform.localPosition.y= lantern.transform.localPosition.y + 0.1f;
        }

    }
    void DisplayTriggerGesture(ManoGestureTrigger triggerGesture, TrackingInfo trackingInfo)

    {
        if (triggerGesture != ManoGestureTrigger.NO_GESTURE)
        {
            if (triggerGesture == ManoGestureTrigger.SWIPE_UP)
            {
                Loggercfz.Log("往上滑" + trackingInfo.palm_center.y);
                Handheld.Vibrate();
                fly= true;
                //animator.SetBool("Flying", true);

            }
            if (triggerGesture == ManoGestureTrigger.SWIPE_DOWN)
            {
                Loggercfz.Log("往下滑" + trackingInfo.palm_center.y);
                Handheld.Vibrate();
                fly = true;
                //animator.SetBool("Flying", true);

            }
        }


    }
}
