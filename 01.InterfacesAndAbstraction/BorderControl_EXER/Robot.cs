﻿namespace BorderControl_EXER
{
    public class Robot : IInteligent
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; set; }
        public string Id { get; }
    }
}