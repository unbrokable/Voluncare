namespace Voluncare.Managment.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        public Guid UserId { get; set; }

        public Guid? ReceiverId { get; set; }

        public Guid? HelpRequestId { get; set; }

        public string Text { get; set; }
    }
}
