using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool act;

		[Header("Movement Settings")]
		public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnAction()
        {
			act = true;
        }

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#else

        // old input sys if we do decide to have it (most likely wont)...
#endif

        [SerializeField]
        private float m_mouseSensetivity = 100;
        private Vector2 m_inputMove = Vector2.zero;
        private Vector2 m_inputLook = Vector2.zero;
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            m_inputMove.Set(x, y);
            MoveInput(m_inputMove);

            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");
            m_inputLook.Set(mouseX, mouseY);
            LookInput(m_inputLook * m_mouseSensetivity);

            JumpInput(Input.GetButton("Jump"));

            SprintInput(Input.GetButton("Sprint"));
        }


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}