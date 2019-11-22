using System;

namespace Mojifier.Models
{
    public class EmotivePoint
    {
        public double anger { get; set; }
        public double contempt { get; set; }
        public double disgust { get; set; }
        public double fear { get; set; }
        public double happiness { get; set; }
        public double neutral { get; set; }
        public double sadness { get; set; }
        public double surprise { get; set; }

        public EmotivePoint(double anger, double contempt, double disgust, double fear, double happiness, double neutral, double sadness, double surprise)
        {
            this.anger = anger;
            this.contempt = contempt;
            this.disgust = disgust;
            this.fear = fear;
            this.happiness = happiness;
            this.neutral = neutral;
            this.sadness = sadness;
            this.surprise = surprise;
        }

        public double[] ToArray()
        {
            return new double[]
            {
                this.anger, this.contempt,
                this.disgust,
                this.fear,
                this.happiness,
                this.neutral,
                this.sadness,
                this.surprise
            };
        }

        public double GetEuclideanDistance(EmotivePoint point)
        {
            var thisPoint = this.ToArray();
            var otherPoint = point.ToArray();
            var euclidean = CalculateEuclideanDistance(thisPoint, otherPoint);
            return euclidean;
        }

        private double CalculateEuclideanDistance(double[] point1, double[] point2)
        {
            double Sum=0;
            double distance=0;
            for (int i = 0; i < point1.Length; i++)
            {
                Sum += Math.Pow((point1[i] - point2[i]), 2.0);
                distance = Math.Sqrt(Sum);
            }
            return distance;
        }
    }
}