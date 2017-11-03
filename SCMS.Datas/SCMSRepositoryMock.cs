﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCMS.Models;
using SCMS.Models.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Contexts;
using SCMS.Models.ViewModels;

namespace SCMS.Datas
{
    public class SCMSRepositoryMock : ISCMS
    {

        static List<User> _users = new List<User>
        {
            new User { Id = "admin", UserName = "scms", Nickname = "scms", Email = "scms@gmail.com", PasswordHash = "123456", IsActive = true },
            new User { Id = "Na", UserName = "Na", Nickname = "Na", Email = "na@gmail.com", PasswordHash = "123456", IsActive = true },
            new User { Id = "Nik", UserName = "Nik", Nickname = "Nik", Email = "nik@gmail.com", PasswordHash = "123456", IsActive = false },
            new User { Id = "Javier", UserName = "Javier", Nickname = "Javier", Email = "javier@gmail.com", PasswordHash = "123456" , IsActive = true}
        };

        static List<Category> _categories = new List<Category>
        {
            new Category{ CategoryId = 1, Description = "Food" },
            new Category{ CategoryId = 2, Description = "Love" },
            new Category{ CategoryId = 3, Description = "Culture" },
            new Category{ CategoryId = 4, Description = "Science" },
            new Category{ CategoryId = 5, Description = "Bedtime Story" }
        };

        static List<Intimacy> _intimacies = new List<Intimacy>
        {
            new Intimacy{ IntimacyId = 1, Description = "Low"},
            new Intimacy{ IntimacyId = 2, Description = "Miduim"},
            new Intimacy{ IntimacyId = 3, Description = "High"}
        };

        static List<Story> _stories = new List<Story> {
            new Story{StroyId = 1, CategoryId = _categories[0].CategoryId, Category = _categories[0],  Title = "How to make a creemy cubcake",
                        Content = "Creemy cubcake blah blah blah....", IntimacyId = _intimacies[0].IntimacyId, Intimacy = _intimacies[0], Picture = null,
                        ApproveStatue = 'Y', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StroyId = 2, CategoryId = _categories[1].CategoryId, Category = _categories[1],  Title = "My love story",
                        Content = "When I first meet her....", IntimacyId = _intimacies[1].IntimacyId, Intimacy = _intimacies[1], Picture = null,
                        ApproveStatue = 'Y', NoView = 5000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StroyId = 3, CategoryId = _categories[2].CategoryId, Category = _categories[2],  Title = "Angkor Wat",
                        Content = "In 11th century....", IntimacyId = _intimacies[2].IntimacyId, Intimacy = _intimacies[2], Picture = null,
                        ApproveStatue = 'Y', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StroyId = 4, CategoryId = _categories[3].CategoryId, Category = _categories[3],  Title = "Discover Mars",
                        Content = "A group of scientist from USA, Russia and China....", IntimacyId = _intimacies[2].IntimacyId, Intimacy = _intimacies[2], Picture = null,
                        ApproveStatue = 'Y', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},
            new Story{StroyId = 5, CategoryId = _categories[4].CategoryId, Category = _categories[4],  Title = "Mr and Mrs Poor",
                        Content = "Once upon time....", IntimacyId = _intimacies[1].IntimacyId, Intimacy = _intimacies[1], Picture = null,
                        ApproveStatue = 'Y', NoView = 1000, Hashtags = _hashtags, UserId = _users[0].Id},

        };
        static List<Hashtag> _hashtags = new List<Hashtag> {
                new Hashtag{ HashtagId = 1, Description = "yummy", Stories = _stories},
                new Hashtag{ HashtagId = 2, Description = "sweet", Stories = _stories},
                new Hashtag{ HashtagId = 3, Description = "thousandyear", Stories = _stories},
                new Hashtag{ HashtagId = 4, Description = "Mars", Stories = _stories},
                new Hashtag{ HashtagId = 5, Description = "fly", Stories = _stories}
        };

        static List<Comment> _comments = new List<Comment> {
                new Comment{ CommentId =1, Descriptiopn = "Such a great story", StoryId = 1, Story = _stories[1]},
                new Comment{ CommentId =2, Descriptiopn = "Yeah, that's so romantic", StoryId = 1, Story = _stories[1]},
                new Comment{ CommentId =3, Descriptiopn = "We'll be able to live on Mars soon", StoryId = 4, Story = _stories[4]},
                new Comment{ CommentId =4, Descriptiopn = "I've been there one time, it's amazing", StoryId = 3, Story = _stories[3]},
                new Comment{ CommentId =5, Descriptiopn = "I will visit there one time", StoryId = 3, Story = _stories[3]},
        };


        #region "Category"
        public List<Category> GetCategoryList()
        {
            return _categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }

        public int AddCategory(Category category)
        {
            if (_categories.Count <= 0)
            {
                category.CategoryId = 1;
            }
            else
            {
                category.CategoryId = _categories.Max(c => c.CategoryId) + 1;
            }
            _categories.Add(category);
            return category.CategoryId;
        }

        public bool UpdateCategory(Category category)
        {
            _categories.RemoveAll(c => c.CategoryId == category.CategoryId);
            _categories.Add(category);
            return true;
        }

        public bool DeleteCategory(int categoryId)
        {
            _categories.RemoveAll(c => c.CategoryId == categoryId);
            return true;
        }
        #endregion

        #region "Intimacy"
        public List<Intimacy> GetIntimacyList()
        {
            return _intimacies;
        }

        public Intimacy GetIntimacyById(int itimacyId)
        {
            return _intimacies.FirstOrDefault(i => i.IntimacyId == itimacyId);
        }
        public int AddIntimacy(Intimacy intimacy)
        {
            if (_intimacies.Count <= 0)
            {
                intimacy.IntimacyId = 1;
            }
            else
            {
                intimacy.IntimacyId = _intimacies.Max(c => c.IntimacyId) + 1;
            }
            _intimacies.Add(intimacy);
            return intimacy.IntimacyId;
        }

        public bool UpdateIntimacy(Intimacy intimacy)
        {
            _intimacies.RemoveAll(i => i.IntimacyId == intimacy.IntimacyId);
            _intimacies.Add(intimacy);
            return true;
        }
        public bool DeleteIntimacy(int intimacyId)
        {
            _intimacies.RemoveAll(i => i.IntimacyId == intimacyId);
            return true;
        }

        #endregion

        #region "Story"
        public List<Story> GetStoryList()
        {
            return _stories;
        }

        public Story GetStoryById(int storyId)
        {
            return _stories.FirstOrDefault(s => s.StroyId == storyId);
        }

        public int AddStory(StoryVM storyVM)
        {
            if (_stories.Count <= 0)
            {
                storyVM.StroyId = 1;
            }
            else
            {
                storyVM.StroyId = _stories.Max(c => c.StroyId) + 1;
            }
            Story story = new Story
            {

                StroyId = storyVM.StroyId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatue = storyVM.ApproveStatue,
                UserId = storyVM.UserId,

                Category = storyVM.Category,
                Intimacy = storyVM.Intimacy,

                Hashtags = storyVM.Hashtags
            };

            _stories.Add(story);
            return story.StroyId;
        }

        public bool UpdateStory(StoryVM storyVM)
        {
            Story story = new Story
            {

                StroyId = storyVM.StroyId,
                CategoryId = storyVM.CategoryId,
                IntimacyId = storyVM.IntimacyId,
                Title = storyVM.Title,
                Content = storyVM.Content,
                HashtagWord = storyVM.HashtagWord,
                Picture = storyVM.Picture,
                NoView = storyVM.NoView,
                ApproveStatue = storyVM.ApproveStatue,
                UserId = storyVM.UserId,

                Category = storyVM.Category,
                Intimacy = storyVM.Intimacy,

                Hashtags = storyVM.Hashtags
            };
            _stories.RemoveAll(s => s.StroyId == story.StroyId);
            _stories.Add(story);
            return true;
        }
        public bool DeleteStory(int storyId)
        {
            _stories.RemoveAll(s => s.StroyId == storyId);
            return true;
        }


        #endregion

        #region "Comment"
        public List<Comment> GetCommentList()
        {
            return _comments;
        }

        public Comment GetCommentById(int commentId)
        {
            return _comments.FirstOrDefault(c => c.CommentId == commentId);
        }

        public List<Comment> GetCommentByStory(int storyId)
        {
            return _comments.Where(c => c.StoryId == storyId).ToList();
        }

        public int AddComment(Comment comment)
        {
            if (_comments.Count <= 0)
            {
                comment.CommentId = 1;
            }
            else
            {
                comment.CommentId = _comments.Max(c => c.CommentId) + 1;
            }
            _comments.Add(comment);
            return comment.CommentId;
        }

        public bool UpdateComment(Comment comment)
        {
            _comments.RemoveAll(c => c.CommentId == comment.CommentId);
            _comments.Add(comment);
            return true;
        }
        public bool DeleteCommentById(int commentId)
        {
            _comments.RemoveAll(c => c.CommentId == commentId);
            return true;
        }

        public bool DeleteCommentByStory(int storyId)
        {
            _comments.RemoveAll(c => c.StoryId == storyId);
            return true;
        }
        #endregion

        #region "Hashtag"
        public List<Hashtag> GetHashtagList()
        {
            return _hashtags;
        }

        public Hashtag GetHashtagById(int hastagId)
        {
            return _hashtags.FirstOrDefault(h => h.HashtagId == hastagId);
        }

        public List<Hashtag> GetHashtagByStory(int storyId)
        {
            return _hashtags.Where(h => h.Stories.Any(s => s.StroyId == storyId)).ToList();
        }

        public int AddHastag(Hashtag hashtag)
        {
            if (_hashtags.Count <= 0)
            {
                hashtag.HashtagId = 1;
            }
            else
            {
                hashtag.HashtagId = _hashtags.Max(h => h.HashtagId) + 1;
            }
            _hashtags.Add(hashtag);
            return hashtag.HashtagId;
        }

        public bool UpdateHashtag(Hashtag hashtag)
        {
            _hashtags.RemoveAll(h => h.HashtagId == hashtag.HashtagId);
            _hashtags.Add(hashtag);
            return true;
        }

        public bool DeleteHashtagById(int hashtagId)
        {
            _hashtags.RemoveAll(h => h.HashtagId == hashtagId);
            return true;
        }

        public bool DeleteHashtagByStory(int storyId)
        {
            _hashtags.RemoveAll(h => h.Stories.Any(s => s.StroyId == storyId));
            return true;
        }

        #endregion

        #region "User"
        public List<User> GetUserList()
        {
            return _users;
        }

        public List<User> GetUserListByRole(string role)
        {
            //Need Modify to get by role
            return GetUserList();
        }

        public User GetUserById(string userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public User GetUserByUserName(string userName)
        {
            return _users.FirstOrDefault(u => u.UserName == userName);
        }

        public string AddUser(User user, string role)
        {
            _users.Add(user);
            return user.Id;
        }

        public async Task<bool> DeactivateUser(string userId)
        {
            User user = GetUserById(userId);
            if (user != null)
            {
                user.IsActive = false;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> ReactivateUser(string userId)
        {
            User user = GetUserById(userId);
            if (user != null)
            {
                user.IsActive = true;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
            }
            return await Task.FromResult(true);
        }

        public bool ChangePassword(string userId, string currentPassword, string newPassword)
        {
            User user = GetUserById(userId);
            if (user != null && user.PasswordHash == currentPassword)
            {
                user.PasswordHash = newPassword;
                _users.RemoveAll(u => u.Id == user.Id);
                _users.Add(user);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _users.RemoveAll(u => u.Id == user.Id);
            _users.Add(user);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUser(string userId)
        {
            _users.RemoveAll(u => u.Id == userId);
            return await Task.FromResult(true);
        }

        public async Task<bool> Login(string userId, string password)
        {
            if (_users.Any(u => u.Id == userId && u.PasswordHash == password))
            {
                User user = _users.FirstOrDefault(u => u.Id == userId);
                CurrentUser.User = user;
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }

        #endregion
    }
}
