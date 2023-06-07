﻿namespace Project.ServiceInformationService.Dtos.ServicePackageDTOs;

public class CreateServicePackageDTO
{
    public string ServicePackageName { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public double Discount { get; set; }
    public int EstimatedTime { get; set; }
    public bool IsActive { get; set; }

    // Foreign Key
    public List<Guid> ServiceItemIds { get; set; } = new List<Guid>();

}
