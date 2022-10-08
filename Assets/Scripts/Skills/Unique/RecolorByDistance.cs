using UnityEngine;

namespace Game
{
    public class RecolorByDistance : Skill
    {
        private readonly float COLOR_MIN = 0.0f;
        private readonly float COLOR_MAX = 1.0f;

        [Header("Settings")]
        [SerializeField, Tooltip("Distance in meters to recolor the ball.")]
        private float _distanceToRecolor = 3.0f;

        private float distance = 0.0f;
        private Vector3 previousPosition;
        private MeshRenderer ownerRenderer;

        public override void Construct(Ball owner)
        {
            base.Construct(owner);

            previousPosition = Owner.transform.position;
            ownerRenderer = Owner.GetComponent<MeshRenderer>();

            if (ownerRenderer != null)
                return;

            throw new MissingComponentException($"Missing 'MeshRenderer' component on the ball! Ball: '{Owner.gameObject.name}'");
        }

        protected override void ProcessState(BallState state)
        {
            // TODO: add respawns support

            distance += (previousPosition - state.Position).magnitude;

            previousPosition = state.Position;

            if (distance < _distanceToRecolor)
                return;

            distance = 0.0f;

            Recolor();
        }

        private void Recolor()
        {
            ownerRenderer.material.color = RandomColor();
        }

        private Color RandomColor()
        {
            return new Color(
              Random.Range(COLOR_MIN, COLOR_MAX),
              Random.Range(COLOR_MIN, COLOR_MAX),
              Random.Range(COLOR_MIN, COLOR_MAX)
            );
        }
    }
}