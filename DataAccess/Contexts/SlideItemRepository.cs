using System;
using Core.Entities;
using DataAccess.Interfaces;

namespace DataAccess.Contexts
{
    public class SlideItemRepository : Repository<SlideItem>,ISlideItemRepository
    {
        public SlideItemRepository(AppDbContext context) : base(context)
        {
        }
    }
}

