namespace NatureShot.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using NatureShot.Data.Models;

    public interface ITagsService
    {
        Task<List<Tag>> GetTagsForPost(string tagsInput);

        IEnumerable<KeyValuePair<string, string>> GetAllTagsAsKeyValuePair();

    }
}
