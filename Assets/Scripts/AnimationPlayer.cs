using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string target;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            animator.Play(target);
        });
    }
}