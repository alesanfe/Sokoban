using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public float speed = 5.0f;

        private Rigidbody2D _rigidbody;
        private float _rightOrLeft, _upOrDown;
        private static float Direction(KeyCode firstDirection, KeyCode secondDirection) => 
            Input.GetKey(firstDirection) ? 1.0f : Input.GetKey(secondDirection) ? -1.0f : 0.0f;
        
        private Animator _body;
        private bool _isSides, _isUp, _isDown, _isMoving;
        private static readonly int IsSides = Animator.StringToHash("isSides"),
            IsUp = Animator.StringToHash("isUp"),
            IsDown = Animator.StringToHash("isDown");
        

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _body = GetComponent<Animator>();
            _isDown = true;
        }

        private void Update()
        {
            // Reset variables animation.
            _isMoving = false;
            
            // Define controls.
            _rightOrLeft = Direction(KeyCode.D, KeyCode.A);
            _upOrDown = Direction(KeyCode.W, KeyCode.S);
            
            // Create a move.
            var move = _rightOrLeft != 0 ? MoveX() : _upOrDown != 0 ? MoveY() : 
                new Vector3(_rightOrLeft, _upOrDown, 0.0f);
            
            // Give some speed.
            _rigidbody.velocity = move * speed;
            
            // Animation;
            AnimatorBody(_isSides, _isUp, _isDown, _isMoving);
        }

        // Control movement.
        private Vector3 MoveX()
        {
            // Variables animation.
            ChangesVariablesAnimatorBody(
                true, 
                false, 
                false, 
                true
            );
            

            // Variables.
            var localScale = transform.localScale;
            
            // Flip the character if it's needed.
            localScale = new Vector3(_rightOrLeft==0?localScale.x:_rightOrLeft, 
                localScale.y, 
                localScale.z);
            transform.localScale = localScale;
            
            // Move the character.
            return new Vector3(_rightOrLeft, 0.0f, 0.0f);
        }

        

        private Vector3 MoveY()
        {
            // Variables animation.
            ChangesVariablesAnimatorBody(
                false,
                Input.GetKey(KeyCode.W),
                Input.GetKey(KeyCode.S),
                true
            );

            // Move the character.
            return new Vector3(0.0f, _upOrDown, 0.0f);

            
        }
        
        private void ChangesVariablesAnimatorBody(bool isSlides, bool isUp, bool isDown, bool isMoving)
        {
            _isSides = isSlides;
            _isUp = isUp;
            _isDown = isDown;
            _isMoving = isMoving;
        }
        
        
        
        
        
        // Animator control body.
        private void AnimatorBody(bool isSlides, bool isUp, bool isDown, bool isMoving)
        {
            _body.SetBool(IsSides, isSlides);
            _body.SetBool(IsUp, isUp);
            _body.SetBool(IsDown, isDown);
            _body.SetLayerWeight(isMoving ? 1 : 0, 1);
            _body.SetLayerWeight(isMoving ? 0 : 1, 0);
        }
        
        
    }
}
