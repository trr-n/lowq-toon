using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using GameTitle;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ThirdPersonUserControl : MonoBehaviour
    {
        [SerializeField]
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
                m_Jump = CrossPlatformInputManager.GetButtonDown(Keys.Jump);
            }
        }

        void FixedUpdate()
        {
            float h = CrossPlatformInputManager.GetAxis(Keys.Hor),
                v = CrossPlatformInputManager.GetAxis(Keys.Ver);
            bool crouchKey = Input.GetKey(Keys.Crouch);

            if (m_Cam != null)
            {
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                // Vector3 hv = h * camera.transform.right + v * camera.transform.forward;
                m_Move = h * m_Cam.right + v * m_CamForward;
                "m_Cam is not null".show();
            }
            else
            {
                m_Move = v * Vector3.forward + h * Vector3.right;
                "m_Cam is null".show();
            }
#if !MOBILE_INPUT

            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            m_Character.Move(m_Move, crouchKey, m_Jump);
            m_Jump = false;
        }
    }
}
