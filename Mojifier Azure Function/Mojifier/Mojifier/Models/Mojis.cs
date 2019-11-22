using System.Collections.Generic;

namespace Mojifier.Models
{
    public class Mojis
    {
        public  EmotivePoint EmotiveValues { get; set; }
        public string Emoji { get; set; }
        public string MojiName { get; set; }

        public static List<Mojis> MOJIS=
            new List<Mojis>
            {
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,1,0, 0,0,0,0,0),
                    Emoji= "😒",
                    MojiName = "unamused"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(1,0,0, 0,0,0,0,0),
                    Emoji= "😡",
                    MojiName = "rage"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,0.962,0.037,0,0.001),
                    Emoji= "☺️",
                    MojiName="smiley"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.572,0.025,0.242, 0.001,0.014,0.111,0.033,0.003),
                    Emoji= "💩",
                    MojiName="poop"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,0.997,0.003,0,0),
                    Emoji= "🤓",
                    MojiName="nerd_face"

                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.005,0.007,0, 0,0.001,0.978,0.009,0),
                    Emoji= "🤔",
                    MojiName = "thinking"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0.001,0, 0,0.948,0.052,0,0),
                    Emoji= "🦄",
                    MojiName = "unicorn"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.001,0,0, 0,0.969,0.03,0,0),
                    Emoji= "😃",
                    MojiName="smiley"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,1,0,0,0),
                    Emoji= "😆",
                    MojiName = "laughing"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0.081,0, 0,0.871,0.032,0,0.016),
                    Emoji= "😉",
                    MojiName = "wink"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,0.995,0.005,0,0),
                    Emoji= "😆",
                    MojiName = "laughing"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,1,0,0,0),
                    Emoji= "😍",
                    MojiName="heart_eyes"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.001,0.003,0, 0,0.002,0.99,0.003,0.001),
                    Emoji= "😎",
                    MojiName = "sunglasses"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.005,0.03,0.001, 0.049,0.012,0.511,0.016,0.375),
                    Emoji= "😆",
                    MojiName="laughing"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,1,0,0,0),
                    Emoji= "😐",
                    MojiName="neutral_face"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0.001,0, 0,0.039,0.952,0.002,0.006),
                    Emoji= "😕",
                    MojiName="confused"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.093,0.003,0.001, 0.003,1,0.881,0.006,0.013),
                    Emoji= "😖",
                    MojiName="confounded"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0.001,0, 0,1,0.988,0.011,0),
                    Emoji= "😘",
                    MojiName="kissing_heart"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.001,0.181,0.003, 0,0.727,0.087,0,0),
                    Emoji= "😜",
                    MojiName = "stuck_out_tongue_winking_eye"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,1,0,0,0),
                    Emoji= "😝",
                    MojiName="stuck_out_tongue_closed_eyes"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.049,0.002,0, 0,0,0.941,0.008,0),
                    Emoji= "😠",
                    MojiName = "angry"
                }
                ,new Mojis
                {
                    EmotiveValues= new EmotivePoint(0,0,0, 0,1,0,0,0),
                    Emoji= "😧",
                    MojiName="anguished"
                },new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.031,0.009,0.096, 0.017,0,0.584,0.223,0.04),
                    Emoji= "😩",
                    MojiName = "weary"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.001,0.007,0.003, 0.001,0,0.298,0.689,0),
                    Emoji= "😭",
                    MojiName="sob"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.003,0,0.001, 0.034,0,0,0,0.961),
                    Emoji= "😱",
                    MojiName="scream"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.007,0.003,0, 0.057,0,0.098,0,0.834),
                    Emoji= "😳",
                    MojiName="flushed"
                },
                new Mojis
                {
                    EmotiveValues= new EmotivePoint(0.004,0.006,0.008, 0.002,0,0.872,0.105,0.003),
                    Emoji= "😴",
                    MojiName="sleeping"
                },
            };
    }
}