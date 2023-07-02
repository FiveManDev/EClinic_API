﻿using Microsoft.EntityFrameworkCore;
using Project.BookingService.Data;
using Project.BookingService.Data.Configurations;
using Project.Data.Repository.MSSQL;
using System.Linq.Expressions;

namespace Project.BookingService.Repository.BookingPackageRepository;

public class BookingPackageRepository : MSSQLRepository<ApplicationDbContext, BookingPackage>, IBookingPackageRepository
{
    public BookingPackageRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}
