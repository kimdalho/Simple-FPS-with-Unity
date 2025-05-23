using UnityEngine;

public class AnimController : MonoBehaviour
{
    private Animator _animator;
    public Animator animator
    {
        get
        {
            return _animator;
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
