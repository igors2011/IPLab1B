using IPLab1BMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IPLab1BMVC.Controllers
{
	public class CommentController : Controller
	{
		[HttpGet]
		public IActionResult Comments()
		{
			ViewBag.Comments = DataWorker.CommentList;
			return View();
		}
		[HttpGet]
		public IActionResult Comment()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddComment(Comment comment)
		{
			if (string.IsNullOrEmpty(comment.SenderName) || string.IsNullOrEmpty(comment.CommentValue))
			{
				ViewBag.ResponseValue = "Не заполнено имя или комментарий";
			}
			else
			{
				DataWorker.AddComment(comment);
				ViewBag.ResponseValue = $"Спасибо за комментарий, {comment.SenderName}";
			}
			return View();
		}
	}
}
