namespace IPLab1BMVC.Models
{
	public static class DataWorker
	{
		public static List<Character> FairyList
		{
			get
			{
				var result = new List<Character>();
				using (StreamReader sr = new("TextData/fairies.txt"))
				{
					var currentString = sr.ReadLine();
					while (currentString != null)
					{
						var fairyData = currentString.Split(';');
						var newFairy = new Character()
						{
							Name = fairyData[0],
							ShortDescription = fairyData[1],
							LongDescription = fairyData[2],
							ImageSrc = fairyData[3]
						};
						result.Add(newFairy);
						currentString = sr.ReadLine();
					}
				}
				return result;
			}
		}
		public static List<Comment> CommentList
		{
			get
			{
				var result = new List<Comment>();
				using (StreamReader sr = new("TextData/comments.txt"))
				{
					var currentString = sr.ReadLine();
					while (currentString != null)
					{
						var commentData = currentString.Split(';');
						var newComment = new Comment()
						{
							SenderName = commentData[0],
							CommentValue = commentData[1]
						};
						result.Add(newComment);
						currentString = sr.ReadLine();
					}
				}
				return result;
			}
		}
		public static void AddComment(Comment comment)
		{
			using (StreamWriter sw = new("TextData/comments.txt", true))
			{
				sw.WriteLine(comment.SenderName + ";" + comment.CommentValue);
			}
		}
	}
}
