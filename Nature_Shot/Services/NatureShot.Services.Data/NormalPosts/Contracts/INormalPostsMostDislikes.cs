namespace NatureShot.Services.Data.NormalPosts.Contracts
{
    using System;
    using System.Collections.Generic;
    using NatureShot.Common;
    using NatureShot.Web.ViewModels.NormalPosts;

    public interface INormalPostsMostDislikes
    {
        IEnumerable<NormalPostViewModel> GetNormalPostsMostDislikes(int page, int count = GlobalConstants.Pages);

        IEnumerable<NormalPostViewModel> SearchByCaption(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<NormalPostViewModel> SearchByUsername(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<NormalPostViewModel> SearchByTags(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<NormalPostViewModel> SearchByLikedPosts(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<NormalPostViewModel> SearchByDislikedPosts(int page, string input, int count = GlobalConstants.Pages);

        IEnumerable<NormalPostViewModel> SearchByCommentedPosts(int page, string input, int count = GlobalConstants.Pages);
    }
}
