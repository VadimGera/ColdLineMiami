using UnityEngine;

namespace DefaultNamespace
{
    public class AimInput : MonoBehaviour
    {
        private CharacterAim _characterAim;

        private void Awake()
        {
            _characterAim = GetComponent<CharacterAim>();
        }

        private void Update()
        {
            var mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out var hit))
            {
                _characterAim.LookAt(hit.point);
            }
        }
    }
}