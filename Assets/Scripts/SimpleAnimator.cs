namespace CornellTech.View
{

    using UnityEngine;

    /// <summary>
    /// Simple Animator.
    /// This class is responsible for animating the gameObject.
    /// </summary>
    public class SimpleAnimator : MonoBehaviour
    {

        private enum AnimationState { Default, MovingTowards, Rotating };

        private const float c_TargetRotationValue = 360.0f;

        private const float c_RotationTime = 3.0f;

        private const float c_RotationSpeed = c_TargetRotationValue / c_RotationTime;
        
        private AnimationState ControlState;


        // TODO: Declare private properties here
        private float step;
        private float rotstep;
        private Vector3 LetsGo;
        private Vector3 WhereamI;
        private float Spinning;
        private Vector3 AmIDone;
        ///////////////////////////////////////////////////////////////////////////
        //
        // Inherited from MonoBehaviour
        //
        // Read more about these events here: https://docs.unity3d.com/Manual/ExecutionOrder.html
        // 

        private void Awake()
        {
            //TODO: Intialise viriables and game state here.
            ControlState = AnimationState.Default;
        }

        private void Update()
        {
            //TODO: Implement the movement and rotation here.
            if (ControlState == AnimationState.MovingTowards)
            {
                transform.position = Vector3.MoveTowards(transform.position, LetsGo, step);
                WhereamI = GetPosition();
                 if (WhereamI == LetsGo)
                    {
                        ControlState = AnimationState.Rotating;
//                        SpinStart = transform.eulerAngles.z;
                    }
            }
            else if (ControlState == AnimationState.Rotating)
            {
                Spinning = Spinning - rotstep;
//                AmIDone = c_RotationSpeed;
                    if (Spinning <= 0.0)
                    {
                        transform.rotation = Quaternion.Euler(0,0,0);
                        ControlState = AnimationState.Default;
                    }
                    else
                    {
                        transform.Rotate(0,0,rotstep);
                    }
            }
        }

        ///////////////////////////////////////////////////////////////////////////
        //
        // SimpleAnimator Methods
        //

        public void StartAnimation(SimpleAnimationData animationData)
        {
            Debug.Log("MoveTowards@SimpleAnimator: " + animationData.p_EndPosition.ToString());
            ControlState = AnimationState.MovingTowards;
            step = animationData.p_Speed * Time.deltaTime;
            rotstep = c_RotationSpeed * Time.deltaTime;
            Spinning = 360.0f;
            LetsGo = animationData.p_EndPosition;
//            transform.position = Vector3.MoveTowards(transform.position, animationData.p_EndPosition, step);
            //TODO: Trigger the animation.
        }


        ////////////////////////////////////////
        //
        // Utility Methods

        private Vector3 GetPosition()
        {
            return transform.localPosition;
        }

//        private Quaternion GetRotation()
//        {
//            return transform.localRotation;
//        }

        private void SetPosition(Vector3 p)
        {
            transform.localPosition = p;
        }
    }
}