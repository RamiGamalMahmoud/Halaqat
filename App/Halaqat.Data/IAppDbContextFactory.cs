﻿namespace Halaqat.Data
{
    public interface IAppDbContextFactory
    {
        AppDbContext CreateAppDbContext();
        AppDbContext CreateAppDbContextWithoutDatabase();
    }
}
