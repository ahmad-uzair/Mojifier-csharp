namespace Mojifier.Models
{
    public class FaceRectangle
    {
        public int width { get; set; }
        public int height { get; set; }
        public int left { get; set; }
        public int top { get; set; }

        public FaceRectangle(int top, int left, int width, int height)
        {
            this.top = top;
            this.left = left;
            this.width = width;
            this.height = height;
        }
    }
}