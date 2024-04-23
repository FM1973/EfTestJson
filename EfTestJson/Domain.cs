using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfTestJson
{
    public class Poll
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTimeOffset? Start { get; set; }

        public DateTimeOffset? End { get; set; }

        public PollStatus Status { get; set; }

        public IList<PollCategory> Categories { get; set; }

        public DateTimeOffset? CreationDate { get; set; }

        public DateTimeOffset? LastUpdate { get; set; }

        public byte[] Version { get; set; }
    }

    public enum PollStatus
    {
        Draft,
        Active,
        Closed
    }

    public class PollCategory
    {
        public PollCategory()
        {
            CategoryId = Guid.Empty;
            Order = 0;
            Name = string.Empty;
            Description = string.Empty;
            Tasks = new List<PollTask>();
        }

        public Guid CategoryId { get; set; }

        public int Order { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public IList<PollTask> Tasks { get; set; }
    }

    public class PollTask
    {
        public PollTask()
        {
            TaskId = Guid.Empty;
            Order = 0;
            Name = string.Empty;
            Placeholder = string.Empty;
            Tooltip = string.Empty;
            TaskType = PollTaskType.Text;
            TodoUntil = null;
            SetByAdmin = false;
            TasksUsers = new List<PollTaskUser>();
        }

        public Guid TaskId { get; set; }

        public int Order { get; set; }

        public string Name { get; set; } = null!;

        public string Placeholder { get; set; } = null!;

        public string Tooltip { get; set; } = null!;

        public PollTaskType TaskType { get; set; }

        public DateTimeOffset? TodoUntil { get; set; }

        public bool SetByAdmin { get; set; }

        public IList<PollTaskUser> TasksUsers { get; set; }
    }

    public class PollTaskUser
    {
        public PollTaskUser()
        {
            UserId = Guid.Empty;
            UserName = string.Empty;
            Percent = 0;
            Text = string.Empty;
            CreationDate = DateTimeOffset.UtcNow;
            LastUpdate = DateTimeOffset.UtcNow;
        }

        public Guid UserId { get; set; }

        public string UserName { get; set; } = null!;

        public decimal Percent { get; set; }

        public string? Text { get; set; }

        public DateTimeOffset? CreationDate { get; set; }

        public DateTimeOffset? LastUpdate { get; set; }
    }

    public enum PollTaskType
    {
        Text,
        Status
    }
}
