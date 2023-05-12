using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Toon;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("my camera")]
        GameObject cam;

        ThirdPersonCharacter m_Character;
        Transform m_Cam;
        Vector3 m_CamForward;
        Vector3 m_Move;
        bool m_Jump;

        void Start()
        {
            // don't need bcuz this isn't using main cam
            // if (Camera.main != null)
            {
                m_Cam = cam.transform;
            }

            m_Character = GetComponent<ThirdPersonCharacter>();
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
            float h = CrossPlatformInputManager.GetAxis(Const.Hor),
                v = CrossPlatformInputManager.GetAxis(Const.Ver);
            bool crouchKey = Input.GetKey(Const.Crouch);

            if (m_Cam != null)
            {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = h * m_Cam.right + v * m_CamForward;
            }
            else
            {
                m_Move = h * Vector3.right + v * Vector3.forward;
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                m_Move *= 0.5f;
            }

            m_Character.Move(m_Move, crouchKey, m_Jump);
            m_Jump = false;
        }
    }
}
