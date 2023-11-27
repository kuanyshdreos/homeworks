using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    private Slider slider;
    public GameObject Nick2;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void Nick2pos()
    {
        Animator Animation2 = Nick2.GetComponent<Animator>();

        float animationSpeed = slider.value;

        if (animationSpeed <= 50f)
        {
            Animator Animation1 = Nick2.GetComponent<Animator>();
            Animation1.Play("Animation1");
        }
        else if (animationSpeed >= 100f)
        {
            Animation2.Play("Animation2");
        }
        else
        {
            Animation2.Play("Animation2");
        }
    }
}