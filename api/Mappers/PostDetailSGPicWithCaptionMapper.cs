using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.PostDetailSGPicWithCaption;
using api.Models;

namespace api.Mappers
{
    public static class PostDetailSGPicWithCaptionMapper
    {
        public static PostDetailSGPicWithCaptionDto ToPostDetailSGPicWithCaptionDto(this PostDetailSGPicWithCaption postDetailSGPicWithCaptionModel)
        {
            return new PostDetailSGPicWithCaptionDto
            {
                PostDetailSGPicWithCaptionID = postDetailSGPicWithCaptionModel.PostDetailSGPicWithCaptionID,
                PostID = postDetailSGPicWithCaptionModel.PostID,
                Content = postDetailSGPicWithCaptionModel.Content,
                HashTag = postDetailSGPicWithCaptionModel.HashTag,
                ImageURL = postDetailSGPicWithCaptionModel.ImageURL,
            };
        }
        public static PostDetailSGPicWithCaption ToPostDetailSGPicWithCaptionFromCreateDTO(this CreatePostDetailSGPicWithCaptionRequestDto postDetailSGPicWithCaptionDto)
        {
            return new PostDetailSGPicWithCaption
            {
                PostID = postDetailSGPicWithCaptionDto.PostID,
                Content = postDetailSGPicWithCaptionDto.Content,
                HashTag = postDetailSGPicWithCaptionDto.HashTag,
                ImageURL = postDetailSGPicWithCaptionDto.ImageURL,
            };
        }
    }
}