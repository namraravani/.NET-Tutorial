using FluentValidation;

namespace FluentValidationDemo.Models
{
    public class Taskitem
    {
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool RemindMe { get; set; }

        public int? RemindMinutesBeforeDueDate { get; set; }

        public List<string> SubItems { get; set; }
    }


    public class TaskItemValidatior : AbstractValidator<Taskitem>
    {
        public TaskItemValidatior()
        {
            RuleFor(t => t.Description).NotEmpty();
            RuleFor(t => t.DueDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("DueDate must be in the Future");
            RuleFor(t => t.RemindMe).NotEmpty();
            When(t => t.RemindMe == true, () =>
            {
                RuleFor(t => t.RemindMinutesBeforeDueDate)
                
                .GreaterThan(0).WithMessage("It Should be Greater than Zero");
            });

            RuleForEach(t => t.SubItems).NotEmpty().WithMessage("The Sub Items Cannot be empty");
        }
    }

}
