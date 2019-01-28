namespace ecsdee.Tests.Components
{
    public class Color : IComponent
    {
        public float R;

        public float G;

        public float B;

        public Color(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
