using UnityEngine;

namespace DefaultNamespace.Ai
{
    public static class AimUtils
    {
        public static bool CanSeePlayer(Transform _transform)
        {
            var playerPos = CharactersManager.Instance.Player.transform.position;
            var direction = playerPos - _transform.position;
            if (Physics.Raycast(_transform.position, direction, out var hit))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}