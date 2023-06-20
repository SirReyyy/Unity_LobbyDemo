using UnityEngine;
using Photon.Pun;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
//using UnityEngine.InputSystem;
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
		public bool exit;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

		// Photon View component
        PhotonView photonView;

		void Start() {
			photonView = photonView = GetComponent<PhotonView>();
		}

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			if(photonView.IsMine) {
				MoveInput(value.Get<Vector2>());
			}
			// MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(photonView.IsMine) {
				if(cursorInputForLook)
				{
					LookInput(value.Get<Vector2>());
				}
			}
		}

		public void OnJump(InputValue value)
		{
			if(photonView.IsMine) {
				JumpInput(value.isPressed);
			}
			// JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			if(photonView.IsMine) {
				SprintInput(value.isPressed);
			}
			// SprintInput(value.isPressed);
		}

		//-- added --
		public void OnExit(InputValue value)
		{
			if(photonView.IsMine) {
				ExitInput(value.isPressed);
			}
			// ExitInput(value.isPressed);
		}
		//-- added --
#endif


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

		//-- added --
		public void ExitInput(bool newExitState)
		{
			exit = newExitState;
		}
		//-- added --

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}