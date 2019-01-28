namespace ecsdee.Tests.Components
{
    public class Transform : IComponent
    {
        public float X;

        public float Y;

        public float Width;

        public float Height;

        public Transform(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }
    }
}
