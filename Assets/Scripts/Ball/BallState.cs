using UnityEngine;

namespace Game
{
    // Contains general ball's data
    public struct BallState
    {
        /// <summary>
        /// Ball movement direction.
        /// </summary>
        public readonly Vector3 Direction;
        /// <summary>
        /// Ball movement speed.
        /// </summary>
        public readonly float Speed;
        /// <summary>
        /// Ball world position.
        /// </summary>
        public readonly Vector3 Position;

        public BallState(Vector3 direction, float speed, Vector3 position)
        {
            Direction = direction;
            Speed = speed;
            Position = position;
        }
    }
}