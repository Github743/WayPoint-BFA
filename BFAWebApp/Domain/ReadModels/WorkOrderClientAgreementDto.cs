namespace BFAWebApp.Domain.ReadModels;

public class WorkOrderClientAgreementDto
{
    public int WorkOrderId { get; set; }
    public int SystemDiscountProgramId { get; set; }
    public bool IsMLCOption { get; set; }
    public bool IsISMOption { get; set; }
    public bool IsISPSOption { get; set; }
}
