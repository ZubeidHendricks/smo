﻿namespace NPOMS.Domain.ResourceParameters
{
	public abstract class ResourceParametersBase
    {
        public int MaxPageSize = 100;

        public string SearchQuery { get; set; }

        public int PageNumber { get; set; } = 1;

        private int _pageSize = 20;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
