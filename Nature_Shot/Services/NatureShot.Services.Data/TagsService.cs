﻿namespace NatureShot.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using NatureShot.Data;
    using NatureShot.Data.Common.Repositories;
    using NatureShot.Data.Models;

    public class TagsService : ITagsService
    {
        private readonly IDeletableEntityRepository<Tag> tagsRepository;

        public TagsService(IDeletableEntityRepository<Tag> tagsRepository)
        {
            this.tagsRepository = tagsRepository;
        }

        public async Task<List<Tag>> GetTagsForPost(string tagsInput)
        {
            var listOfTags = new List<Tag>();
            var tags = tagsInput.Split(' ');
            var tagsFromDb = this.tagsRepository.All().ToList();

            foreach (var tagName in tags)
            {
                var tag = new Tag
                {
                    Name = tagName,
                };

                if (!tagsFromDb.Contains(tag))
                {
                    if (!tag.Name.StartsWith('#'))
                    {
                        tag.Name.Insert(0, "#");
                    }

                    await this.tagsRepository.AddAsync(tag);
                }

                listOfTags.Add(tag);
            }

            return listOfTags;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllTagsAsKeyValuePair()
        {
            return this.tagsRepository.AllAsNoTracking()
                                      .Select(x => new
                                      {
                                          x.Id,
                                          x.Name,
                                      })
                                      .Distinct()
                                      .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
