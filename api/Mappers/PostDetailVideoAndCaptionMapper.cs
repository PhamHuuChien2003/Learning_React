using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailVideoAndCaption;
using api.Models;

namespace api.Mappers
{
    public static class PostDetailVideoAndCaptionMapper
    {
        public static PostDetailVideoAndCaptionDto ToPostDetailVideoAndCaptionDto(this PostDetailVideoAndCaption postDetailVideoAndCaptionModel)
        {
            return new PostDetailVideoAndCaptionDto
            {
                PostDetailVideoAndCaptionID = postDetailVideoAndCaptionModel.PostDetailVideoAndCaptionID,
                PostID = postDetailVideoAndCaptionModel.PostID,
                Content = postDetailVideoAndCaptionModel.Content,
                HashTag = postDetailVideoAndCaptionModel.HashTag,
                VideoURL = postDetailVideoAndCaptionModel.VideoURL,
            };
        }
    }
}