namespace IPLab1BMVC.Models
{
	public static class DataWorker
	{
		public static List<Fairy> FairyList
		{
			get
			{
				var result = new List<Fairy>();
				using (StreamReader sr = new("TextData/fairies.txt"))
				{
					var currentString = sr.ReadLine();
					while (currentString != null)
					{
						var fairyData = currentString.Split(';');
						var newFairy = new Fairy()
						{
							Name = fairyData[0],
							Description = fairyData[1],
							ImageSrc = fairyData[2]
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
	}
}
