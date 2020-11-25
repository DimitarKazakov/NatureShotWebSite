﻿namespace NatureShot.Services.Data.NormalPosts
{
    using System;
    using System.Collections.Generic;

    using NatureShot.Web.ViewModels.NormalPosts;

    public interface INormalPostsMostDislikes
    {
        IEnumerable<NormalPostViewModel> GetNormalPostsMostDislikes(int page, int count = 10);

        IEnumerable<NormalPostViewModel> SearchByCaption(int page, string input, int count = 10);

        IEnumerable<NormalPostViewModel> SearchByUsername(int page, string input, int count = 10);

        IEnumerable<NormalPostViewModel> SearchByTags(int page, string input, int count = 10);
    }
}