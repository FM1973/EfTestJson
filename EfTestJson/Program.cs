// See https://aka.ms/new-console-template for more information

using EfTestJson;
using EfTestJson.Data;
using Microsoft.Extensions.Configuration;


using (var context = new ApplicationDbContext())
{
    Console.WriteLine("Clear data");

    var existingPolls = context.Polls.ToList();
    context.Polls.RemoveRange(existingPolls);
    await context.SaveChangesAsync(CancellationToken.None);

    Console.WriteLine("Data cleared - Press key for next step");
    Console.ReadLine();

    Console.WriteLine("Creating Poll");

    var poll = new Poll()
    {
        Id = Guid.NewGuid(),
        Title = "Poll 1",
        Description = "Poll 1 Description",
        Start = DateTimeOffset.Now,
        End = DateTimeOffset.Now.AddDays(1),
        Status = PollStatus.Draft,
        CreationDate = DateTimeOffset.Now,
        LastUpdate = DateTimeOffset.Now,
        Categories = new List<PollCategory>()
    };

    context.Polls.Add(poll);
    await context.SaveChangesAsync(CancellationToken.None);

    context.SaveChanges();

    Console.WriteLine("Poll created  - Press key for next step");

    Console.ReadLine();

    Console.WriteLine("Create a category");

    var existingPoll = context.Polls.FirstOrDefault();

    var category = new PollCategory()
    {
        CategoryId = Guid.NewGuid(),
        Name = "Category 1",
        Description = "Category 1 Description",
        Order = 1,
    };

    existingPoll.Categories.Add(category);

    context.Polls.Update(existingPoll);
    await context.SaveChangesAsync(CancellationToken.None);

    Console.WriteLine("Poll with category saved  - Press key for next step");

    Console.ReadLine();

    Console.WriteLine("Create a task and add it to the existing category");

    existingPoll = context.Polls.FirstOrDefault();

    var task = new PollTask()
    {
        TaskId = Guid.NewGuid(),
        Order = 1,
        Name = "Task 1",
        Placeholder = string.Empty,
        Tooltip = string.Empty,
        TaskType = PollTaskType.Status,
        TodoUntil = null,
        SetByAdmin = false,
        TasksUsers = new List<PollTaskUser>()
    };

    var existingCategory = existingPoll.Categories.First();

    existingCategory.Tasks.Add(task);

    context.Polls.Update(existingPoll);
    await context.SaveChangesAsync(CancellationToken.None);

    Console.WriteLine("Task added - Press key for next step");

    Console.ReadLine();

    Console.WriteLine("Done");
}




