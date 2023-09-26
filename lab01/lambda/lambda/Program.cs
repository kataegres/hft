using System;
using System.IO;

namespace lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // default
            FeedbackProcessor processor = new FeedbackProcessor((feedback) =>
            {
                Console.WriteLine($"Default action for the feedback of {feedback.Category}");
            });

            Feedback f1 = new Feedback() { Category = Category.Opinion, Priority = 1, Product = "Edge", Description = "Yuck" };
            Feedback f2 = new Feedback() { Category = Category.BugReport, Priority = 6, Product = "Chrome", Description = "Froze 13 times" };
            Feedback f3 = new Feedback() { Category = Category.FeatureRequest, Priority = 9, Product = "Firefox", Description = "Make it better pls" };

            processor.AddFeedback(f1);
            processor.AddFeedback(f2);
            processor.AddFeedback(f3);

            Console.ReadLine();

            // #1
            Action<Feedback> writeOut = (fb) =>
            {
                Console.WriteLine(fb.ToString());
            };

            // #2
            Action<Feedback> saveToFile = (fb) =>
            {
                File.AppendAllText("feedbacks.log", fb.ToString() + "\r\n");
                Console.WriteLine("FILE UPDATED");
            };

            processor.AddAction(Category.Opinion, WriteToConsole);
            processor.AddAction(Category.BugReport, writeOut);
            processor.AddAction(Category.FeatureRequest, writeOut);

            processor.AddAction(Category.BugReport, saveToFile);
            processor.AddAction(Category.FeatureRequest, saveToFile);

            processor.AddFeedback(f1);
            processor.AddFeedback(f2);
            processor.AddFeedback(f3);

            Console.ReadLine();
        }

        // #1 other
        static void WriteToConsole(Feedback fb)
        {
            Console.WriteLine(fb.ToString());
        }
    }
}
