using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda
{
    enum Category { Opinion, BugReport, FeatureRequest }
    internal class Feedback
    {
        public Category Category { get; set; }
        public int Priority { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Category} of priority {Priority}: {Product} - {Description}";
        }

    }

    internal class FeedbackProcessor
    {
        const int LIMIT = 3;
        Dictionary<Category, Action<Feedback>> feedbackActions;
        List<Feedback> feedbacks;

        public FeedbackProcessor(Action<Feedback> defaultAction)
        {
            feedbacks = new List<Feedback>();
            feedbackActions = new Dictionary<Category, Action<Feedback>>();

            foreach (Category item in Enum.GetValues(typeof(Category)))
            {
                feedbackActions.Add(item, defaultAction);
            }
        }

        public void AddAction(Category category, Action<Feedback> method)
        {
            feedbackActions[category] += method;
        }

        public void AddFeedback(Feedback feedback)
        {
            feedbacks.Add(feedback);
            if (feedbacks.Count == LIMIT)
            {
                foreach (Feedback item in feedbacks)
                {
                    feedbackActions[item.Category].Invoke(item);
                    Console.WriteLine("FEEDBACK PROCESSED");
                    Console.WriteLine();
                }
                feedbacks.Clear();
            }
        }
    }
}
