﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Business
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAll();
    }
}
