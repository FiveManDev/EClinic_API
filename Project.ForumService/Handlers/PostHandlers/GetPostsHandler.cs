﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Common.Paging;
using Project.Common.Response;
using Project.Core.AWS;
using Project.Core.Logger;
using Project.Data.Repository.MongoDB;
using Project.ForumService.Data;
using Project.ForumService.Dtos.Model;
using Project.ForumService.Dtos.PostsDtos;
using Project.ForumService.Queries;

namespace Project.ForumService.Handlers.PostHandlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, ObjectResult>
    {
        private readonly IMongoDBRepository<Post> postRepository;
        private readonly IMongoDBRepository<Answer> answerRepository;
        private readonly IAmazonS3Bucket s3Bucket;
        private readonly IMapper mapper;
        private readonly ILogger<GetPostsHandler> logger;

        public GetPostsHandler(IMongoDBRepository<Post> postRepository, IMongoDBRepository<Answer> answerRepository, IAmazonS3Bucket s3Bucket, IMapper mapper, ILogger<GetPostsHandler> logger)
        {
            this.postRepository = postRepository;
            this.answerRepository = answerRepository;
            this.s3Bucket = s3Bucket;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ObjectResult> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var searchText = request.SearchPostDtos.SearchText;
                if (searchText == null) { searchText = ""; }
                var posts = await postRepository.GetAllAsync(x => x.Title.ToLower().Contains(searchText.ToLower()) || x.Title.ToLower().Contains(searchText.ToLower()));
                if (posts == null)
                {
                    return ApiResponse.NotFound("Post Not Found.");
                }
                if (request.SearchPostDtos.SearchText != null)
                {
                    var answer = await answerRepository.GetAllAsync(x => x.Content.ToLower().Contains(searchText.ToLower()));
                    if (answer != null)
                    {
                        if (request.SearchPostDtos.Tags != null)
                        {
                            answer = answer.Where(x => x.Tags.Any(z => request.SearchPostDtos.Tags.Contains(z))).ToList();
                        }
                        var ListPostIDInAnswer = answer.Select(x => x.PostID).ToList();
                        var ListPostIDInPost = posts.Select(x => x.Id).ToList();
                        var ListPostIDNotInPost = ListPostIDInAnswer.Except(ListPostIDInPost).ToList();
                        var listAnswerPost = await postRepository.GetAllAsync(x => ListPostIDNotInPost.Contains(x.Id));
                        posts.AddRange(listAnswerPost);
                    }
                }
                PaginationResponseHeader header = new PaginationResponseHeader();
                header.TotalCount = posts.Count;
                posts = posts
                    .OrderBy(x => x.CreatedAt)
                    .Skip((request.PaginationRequestHeader.PageNumber - 1) * request.PaginationRequestHeader.PageSize)
                    .Take(request.PaginationRequestHeader.PageSize).ToList();

                header.PageIndex = request.PaginationRequestHeader.PageNumber;
                header.PageSize = request.PaginationRequestHeader.PageSize;

                request.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(header));
                List<PostDtos> postDtos = mapper.Map<List<PostDtos>>(posts);
                foreach (PostDtos post in postDtos)
                {
                    if (post.Image.Count > 0)
                    {
                        var images = await s3Bucket.GetManyFileAsync(post.Image);
                        post.Image = images;
                    }
                    post.Author.Avatar = await s3Bucket.GetFileAsync(post.Author.Avatar);

                }
                return ApiResponse.OK<List<PostDtos>>(postDtos);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
                return ApiResponse.InternalServerError();
            }
        }
    }
}
