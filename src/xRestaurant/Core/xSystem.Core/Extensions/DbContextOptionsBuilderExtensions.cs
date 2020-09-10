using System;
using System.Diagnostics.CodeAnalysis;
using xSystem.Core.Data;

namespace Microsoft.EntityFrameworkCore
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseDataProvider([NotNullAttribute] this DbContextOptionsBuilder optionsBuilder, [NotNullAttribute] DataProvider dataProvider)
        {
            if (dataProvider.Provider.Equals("MSSQL"))
                optionsBuilder.UseSqlServer(dataProvider.ConnectionString);
            else if (dataProvider.Provider.Equals("SQLite"))
                optionsBuilder.UseSqlite(dataProvider.ConnectionString);
            return optionsBuilder;
        }
    }
}
