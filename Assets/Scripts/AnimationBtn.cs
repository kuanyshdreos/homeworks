using UnityEngine;

public class AnimationBtn : MonoBehaviour
{
    private Animator anim;
    private bool isAnim1Playing = true;
    private bool isAnim2Playing = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAnim()
    {
        if (isAnim1Playing)
        {
            anim.SetTrigger("Anim2");
            isAnim1Playing = false;
        }
        else
        {
            anim.SetTrigger("Anim1");
            isAnim1Playing = true;
        }
    }

    public void Back()
    {
        if (isAnim2Playing)
        {
            anim.SetTrigger("Anim2");
            isAnim1Playing = false;
        }
        else
        {
            anim.SetTrigger("Back");
            isAnim1Playing = true;
        }
    }
}