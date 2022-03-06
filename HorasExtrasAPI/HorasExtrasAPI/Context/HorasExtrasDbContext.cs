using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorasExtrasAPI.Context
{
    public class HorasExtrasDbContext: DbContext
    {
        public HorasExtrasDbContext(DbContextOptions<HorasExtrasDbContext> options)
        :base(options)
        { 

        }

    }
}
