namespace Mojifier.Models
{
    public class Face
    {
        public EmotivePoint EmotivePoint { get; set; }
        public FaceRectangle FaceRectangle { get; set; }
        public Mojis moji { get; set; }
        public string mojiIcon { get; set; }

        public Face(EmotivePoint emotivePoint, FaceRectangle faceRectangle)
        {
            EmotivePoint = emotivePoint;
            FaceRectangle = faceRectangle;
            moji = chooseMoji(EmotivePoint);
            mojiIcon = moji.Emoji;
        }

        private Mojis chooseMoji(EmotivePoint emotivePoint)
        {
            Mojis closestMoji = null;
            var closestDistance = double.MaxValue;
            foreach (var moji in Mojis.MOJIS)
            {
                var emoPoint = moji.EmotiveValues;
                var distance = emoPoint.GetEuclideanDistance(emotivePoint);
                if (distance<closestDistance)
                {
                    closestMoji = moji;
                    closestDistance = distance;
                }
            }

            return closestMoji;
        }
    }
}