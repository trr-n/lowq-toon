using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Toon;
using Toon.Extend;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("mine")]
        GameObject cam;

        ThirdPersonCharacter m_Character;

        Transform m_Cam;
        Vector3 m_CamForward;
        Vector3 m_Move;
        public Vector3 M_Move => m_Move;

        bool m_Jump;

        void Start()
        {
            // don't need bcuz this isn't using main cam
            // if (Camera.main != null)
            {
                m_Cam = cam.transform;
            }

            m_Character = GetComponent<ThirdPersonCharacter>();
            cam = GameObject.FindGameObjectWithTag(constant.Camera);
        }

        void Update()
        {
            if (!m_Jump)
            {
                // m_Jump = CrossPlatformInputManager.GetButtonDown(Keys.Jump);
            }
        }

        void FixedUpdate()
        {
            float h = CrossPlatformInputManager.GetAxis(constant.Horizontal),
                v = CrossPlatformInputManager.GetAxis(constant.Vertical);
            bool crouchKey = Input.GetKey(constant.Crouch);

            if (m_Cam != null)
            {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = h * m_Cam.right + v * m_CamForward;
            }
            else
            {
                m_Move = h * Vector3.right + v * Vector3.forward;
            }

            if (Input.GetKey(KeyCode.LeftShift) || m_Character.WalkWhileShooting)
            {
                m_Move *= 0.5f;
            }

            m_Move.show();
            m_Character.Move(m_Move, crouchKey, m_Jump);
            m_Jump = false;
        }
    }
}
