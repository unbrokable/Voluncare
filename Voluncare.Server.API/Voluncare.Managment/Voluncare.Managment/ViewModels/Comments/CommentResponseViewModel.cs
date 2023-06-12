namespace Voluncare.Managment.ViewModels.Comments
{
    public class CommentResponseViewModel
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
