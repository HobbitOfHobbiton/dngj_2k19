using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetMoveVelocity(float velocity)
    {
        _animator.SetFloat("Horizontal", Mathf.Abs(velocity));
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }

    public void Jump()
    {
        _animator.SetTrigger("Jump");
    }

    public void Land()
    {
        _animator.SetTrigger("Land");
    }

    public void CheckDamage()
    {

    }
}
