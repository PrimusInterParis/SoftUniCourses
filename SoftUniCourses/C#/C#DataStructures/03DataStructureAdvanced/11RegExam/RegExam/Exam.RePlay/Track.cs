﻿using System.Text;

namespace Exam.RePlay
{
    public class Track
    {
        public Track(string id, string title, string artist, int plays, int durationInSeconds)
        {
            this.Id = id;
            this.Title = title;
            this.Artist = artist;
            this.Plays = plays;
            this.DurationInSeconds = durationInSeconds;
        }

        public string AlbumName { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int Plays { get; set; }

        public int DurationInSeconds { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Album name:" + this.AlbumName);
            sb.AppendLine("Plays:" +this.Plays.ToString());
            sb.AppendLine("Duration " +this.DurationInSeconds.ToString());
            sb.AppendLine();
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
