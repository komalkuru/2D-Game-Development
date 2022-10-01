
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UIController
{
    public class StartScreenParticleSystemOffsetter : MonoBehaviour
    {
        public float spriteOffset;
        Vector3 initialPosition;
        Vector3 newPosition;

        private void Start()
        {
            initialPosition = transform.position;
        }

        void Update()
        {
            transform.position = new Vector3((initialPosition.x + (spriteOffset * Input.mousePosition.x)), (initialPosition.y + (spriteOffset * Input.mousePosition.y)), initialPosition.z);
        }
    }
}