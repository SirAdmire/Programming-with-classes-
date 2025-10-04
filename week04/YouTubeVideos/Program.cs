using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create 4 Video objects
        Video video1 = new Video("Product Showcase: The Aero Bike", "Fitness Fanatic", 305);
        Video video2 = new Video("Unboxing the MegaMixer 5000", "Gadget Guru", 820);
        Video video3 = new Video("Review: New Energy Drink Flavor", "Taste Tester", 450);
        Video video4 = new Video("Behind the Scenes: Product Photo Shoot", "Marketing Dept", 185);

        // 2. Add comments to each video

        // Video 1 Comments
        video1.Comments.Add(new Comment("Cyclist45", "Wow! That bike looks incredibly fast. Great placement!"));
        video1.Comments.Add(new Comment("BreezyRides", "Is the aero helmet included with the purchase?"));
        video1.Comments.Add(new Comment("ProductWatcher", "I've seen this brand in a few videos now. Smart marketing."));

        // Video 2 Comments
        video2.Comments.Add(new Comment("KitchenQueen", "I've been waiting for this mixer! Does it handle dough well?"));
        video2.Comments.Add(new Comment("User789", "Thanks for the thorough unboxing. Very helpful."));
        video2.Comments.Add(new Comment("HomeChefDan", "Mine arrived broken. Customer service was slow to respond."));
        video2.Comments.Add(new Comment("MixMaster", "That blue color is perfect for my kitchen!"));

        // Video 3 Comments
        video3.Comments.Add(new Comment("HydrationHulk", "Finally, a real review. Thanks!"));
        video3.Comments.Add(new Comment("EnergyDrinker", "I disagree, the old flavor was much better."));
        video3.Comments.Add(new Comment("AdSpotter", "I'm keeping track of where this drink shows up. This is video 4!"));

        // Video 4 Comments
        video4.Comments.Add(new Comment("BTSFan", "Love seeing the hard work that goes into the pictures."));
        video4.Comments.Add(new Comment("PhotoGeek", "What camera were you using for the shots?"));
        video4.Comments.Add(new Comment("ProductFan", "The product looks great on camera!"));

        // 3. Put all videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // 4. Iterate through the list and display video information and comments
        Console.WriteLine("--- Video and Comment Analysis Report ---");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            // Display Video Information
            Console.WriteLine($"======================================================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            
            // Call the method to get the comment count
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine($"----------------------------------------------------------------------");

            // Display Comments
            if (video.GetNumberOfComments() > 0)
            {
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"  Comment by {comment.CommenterName}: \"{comment.CommentText}\"");
                }
            }
            else
            {
                Console.WriteLine("  No comments found for this video.");
            }
            Console.WriteLine();
        }
    }
}
