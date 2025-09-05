namespace BFAWebApp.Domain.ReadModels;

public class SystemDiscountSchedule
{
    public int SystemDiscountScheduleId { get; set; }
    public string Name { get; set; } = "";

    public SystemDiscountSchedule() { }

    public SystemDiscountSchedule(int id, string name)
    {
        SystemDiscountScheduleId = id;
        Name = name;
    }
}
