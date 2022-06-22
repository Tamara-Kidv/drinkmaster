﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkMaster.Model
{
    public class Answer
    {
        public Answer(string Answer, Boolean IsCorrect)
        {
            Value = Answer;
            this.IsCorrect = IsCorrect;
        }

        public string Value { get; private set; }
        public bool IsCorrect { get; private set; }
    }
}