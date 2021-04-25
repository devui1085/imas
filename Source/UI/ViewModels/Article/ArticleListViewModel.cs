﻿using System.Collections.Generic;
using IMAS.PresentationModel.Model;

namespace IMAS.UI.ViewModels.Article
{
    public class ArticleListViewModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public IEnumerable<ContentInfo3PM> Articles { get; set; }
        public int TotallRows { get; set; }
    }
}