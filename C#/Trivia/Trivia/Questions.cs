using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class Questions
    {
        private readonly Dictionary<string, Question> questions;

        public Questions(string[] categories)
        {
            questions = new Dictionary<string, Question>();
            CreateQuestions(categories);
        }

        private void CreateQuestions(string[] categories)
        {
            foreach (var category in categories)
            {
                this.questions.Add(category, new Question(category));
            }
        }

        public void NextQuestion(string category)
        {
            if (questions.TryGetValue(category, out var question))
                question.NextQuestion();
        }

        private class Question
        {
            private readonly string category;
            private readonly LinkedList<string> items;

            public Question(string category)
            {
                this.category = category;
                items = new LinkedList<string>();
                for (var i = 0; i < 50; i++) items.AddLast($"{category} Question {i}");
            }

            public void NextQuestion()
            {
                Console.WriteLine(items.First());
                items.RemoveFirst();
            }
        }
    }
}