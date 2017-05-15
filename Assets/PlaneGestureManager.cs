using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;
using DG.Tweening;


public class PlaneGestureManager : MonoBehaviour
{

    public TapGesture singleTap;
    public TapGesture doubleTap;
    public FlickGesture flick;
    public GameObject second_robot;
    public GameObject first_robot;
    private Animator anim;
    private Animator anim2;
    public static bool first_active = true;
    // Use this for initialization
    void Start()
    {
        anim = first_robot.GetComponent<Animator>();
        anim2 = second_robot.GetComponent<Animator>();
        singleTap.Tapped += (object sender, System.EventArgs e) =>
        {
            if (first_active)
            {
                anim.SetBool("tap1", true);
                anim.SetBool("shaking", false);
                anim.SetBool("tap2", false);
            }
            else
            {
                anim2.SetBool("tap1", true);
                anim2.SetBool("shaking", false);
                anim2.SetBool("tap2", false);
            }
        };

        doubleTap.Tapped += (object sender, System.EventArgs e) =>
        {
            if (first_active)
            {
                anim.SetBool("tap2", true);
                anim.SetBool("shaking", false);
                anim.SetBool("tap1", false);
            }
            else
            {
                anim2.SetBool("tap2", true);
                anim2.SetBool("shaking", false);
                anim2.SetBool("tap1", false);
            }
        };

        flick.Flicked += (object sender, System.EventArgs e) =>
        {
            first_active = !first_active;
            second_robot.SetActive(!first_active);
            first_robot.SetActive(first_active);
        };
    }
}
