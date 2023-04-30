namespace IPLab1BMVC.Models
{
	public class Fairies
	{
		public List<Fairy> FairyList
		{
			get
			{
				var result = new List<Fairy>();
				using (StreamReader sr = new("Models/fairies.txt"))
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
	}
}
