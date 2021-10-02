using UnityEngine;

namespace Player
{
    public class Head : MonoBehaviour
    {

        public Rigidbody2D player;

        private Animator _head;

        private bool _isSlides, _isUp, _isDown;

        private static readonly int IsSlides = Animator.StringToHash("isSlides"),
            IsUp = Animator.StringToHash("isUp"),
            IsDown = Animator.StringToHash("isDown");

        // Start is called before the first frame update
        private void Awake()
        {
            _head = GetComponent<Animator>();
            _isDown = true;
        }

        // Update is called once per frame
        private void Update()
        {
            
            if (player.velocity.y >= 1.0f) 
                ChangesVariablesAnimatorHead(false, true, false);
            else if (player.velocity.y <= -1.0f)
                ChangesVariablesAnimatorHead(false, false, true);
            if (player.velocity.x != 0)
                ChangesVariablesAnimatorHead(true, false, false);
            
            AnimatorHead(_isSlides, _isUp, _isDown);
        }

        private void AnimatorHead(bool isSlides, bool isUp, bool isDown)
        {
            _head.SetBool(IsSlides, isSlides);
            _head.SetBool(IsUp, isUp);
            _head.SetBool(IsDown, isDown);
        }

        private void ChangesVariablesAnimatorHead(bool isSlides, bool isUp, bool isDown)
        {
            _isSlides = isSlides;
            _isUp = isUp;
            _isDown = isDown;
        }
    }
}
