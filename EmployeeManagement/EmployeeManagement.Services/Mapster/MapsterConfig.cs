﻿namespace EmployeeManagement.Services.Mapster
{
    public static class MapsterConfig
    {
        public static void Configure()
        {
            EmployeeMapper.Configure();
            DepartmentMapper.Configure();
        }
    }
}
