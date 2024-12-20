﻿using Entities;
using RepositoryContracts;

namespace CLI.UI.ManagePosts;

public class ManagePostsView
{
    private List<Post> posts;
    private readonly IPostRepository postRepository;
    
    
    public ManagePostsView(IPostRepository postRepository)
    {
        this.postRepository = postRepository;
    }
    
    
    public void AddPost(Post post)
    {
        postRepository.AddAsync(post);
    }
    
    
    public void DeletePost(Guid id)
    {
        postRepository.DeleteAsync(id);
    }
    
    public void UpdatePost(Post post)
    {
        postRepository.UpdateAsync(post);
    }
    
    public void GetSinglePost(Guid id)
    {
        postRepository.GetSingleAsync(id);
    }
    
}