﻿namespace NatureShot.Services.Data.NormalPosts.Contracts
{
    using System;
    using System.Collections.Generic;

    using NatureShot.Web.ViewModels.NormalPosts;

    public interface INormalPostsOldest
    {
        IEnumerable<NormalPostViewModel> GetNormalPostsOldest(int page, int count = 4);

        IEnumerable<NormalPostViewModel> SearchByCaption(int page, string input, int count = 4);

        IEnumerable<NormalPostViewModel> SearchByUsername(int page, string input, int count = 4);

        IEnumerable<NormalPostViewModel> SearchByTags(int page, string input, int count = 4);

        IEnumerable<NormalPostViewModel> SearchByLikedPosts(int page, string input, int count = 4);

        IEnumerable<NormalPostViewModel> SearchByDislikedPosts(int page, string input, int count = 4);

        IEnumerable<NormalPostViewModel> SearchByCommentedPosts(int page, string input, int count = 4);
    }
}